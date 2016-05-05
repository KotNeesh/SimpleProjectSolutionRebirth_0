using System.Collections.Generic;
using System.Net.Sockets;
using SimpleProject.Net;

namespace SimpleProject.Use
{
    /**
    <summary> 
    Хранит все данные для интернет протокола.
    </summary>
    */
    public class UserNetwork : IUserNetwork
    {
        public TcpClient Socket { get; set; }
        public Queue<Packet> PacketsSend { get; }
        public Packet PacketReceive { get; }

        public UserNetwork(TcpClient client = null)
        {
            PacketsSend = new Queue<Packet>();
            PacketReceive = new Packet();
            if (client == null)
            {
                Socket = new TcpClient();
            }
            else
            {
                Socket = client;
            }
        }
            
    }
}
