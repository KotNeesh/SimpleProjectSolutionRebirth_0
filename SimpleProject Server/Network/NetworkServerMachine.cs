using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using SimpleProject.Mess;
using SimpleProject.Sys;
using SimpleProject.Use;

namespace SimpleProject.Net
{
    /**
    <summary> 
    Получает сообщения от менеджера сообщений и отправляет их по назначению.
    <para/>
    Получает сообщения от клиента, складывает в менеджер сообщений, указывая от кого пришло данное сообщение.
    </summary>
    */
    sealed class NetworkServerMachine : StateMachine
    {
        private TcpListener _listener;
        private List<IUserNetwork> _clients;
        private IMessagesManagerNetwork _messagesManager;

        public NetworkServerMachine(IMessagesManagerNetwork messagesManager)
        {
            _messagesManager = messagesManager;
            _clients = new List<IUserNetwork>();
        }
        protected override bool Init()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            _listener = new TcpListener(ip, 30);
            _listener.Start();
            return true;
        }
        protected override void Deinit()
        {
            _listener.Stop();
            foreach (IUserNetwork cl in _clients)
            {
                cl.Socket.Close();
            }
        }
        protected override bool DoAnything()
        {
            AddClients();
            SendAll();
            ReceiveAll();
            Thread.Sleep(100);
            return true;
        }
        private void AddClients()
        {
            while (_listener.Pending())
            {
                IUserNetwork cl = new User(_listener.AcceptTcpClient());
                cl.Socket.SendBufferSize = 1024;
                cl.Socket.ReceiveBufferSize = 1024;
                _clients.Add(cl);
            }
        }
        private void SendAll()
        {
            while (true)
            {
                IMessage m = _messagesManager.Get();
                if (m == null) break;
                Packet p = null;
                RegisterPacker.CreatePacket(ref p, m);
                MessageBase mm = (MessageBase)m;
                if (mm.Users.Count != 0)
                {
                    foreach (IUserNetwork user in mm.Users)
                    {
                        user.PacketsSend.Enqueue(p);
                    }
                }
                else
                {
                    foreach (IUserNetwork user in _clients)
                    {
                        user.PacketsSend.Enqueue(p);
                    }
                }
            }

            foreach (IUserNetwork user in _clients)
            {
                Network.Send(user);
            }
            
        }
        private void ReceiveAll()
        {

            foreach (IUserNetwork user in _clients)
            {
                while (true)
                {
                    Network.Receive(user);
                    IMessage m = null;
                    Packet p = user.PacketReceive;
                    PacketState s = RegisterUnpacker.CreateMessage(ref m, p);
                    if (s == PacketState.Ok)
                    {
                        ((MessageBase)m).Users.Add(user);
                        _messagesManager.Set(m);
                        user.PacketReceive.Clear();
                    }
                    else if (s == PacketState.NotReady) break;
                    else
                    {
                        throw new System.SystemException("hoho");
                    }
                }
            }
        }
    }
}
