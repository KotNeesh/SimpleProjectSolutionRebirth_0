using System.Collections.Generic;
using System.Net.Sockets;
using SimpleProject.Net;

namespace SimpleProject.Use
{
    /**
    <summary> 
    Хранит данные интернета и данные профиля.
    </summary>
    */
    public class User : IUserNetwork, IUserProfile
    {
        private IUserNetwork _network;
        private IUserProfile _profile;

        public User(TcpClient client = null)
        {
            _network = new UserNetwork(client);
            _profile = new UserProfile();
        }
        public void UpdateProfile(IUserProfile profile)
        {
            _profile = profile;
        }
        public void UpdateNetwork(IUserNetwork network)
        {
            _network = network;
        }
        //Network
        public TcpClient Socket
        {
            get
            {
                return _network.Socket;
            }

            set
            {
                _network.Socket = value;
            }
        }

        public Queue<Packet> PacketsSend
        {
            get
            {
                return _network.PacketsSend;
            }
        }

        public Packet PacketReceive
        {
            get
            {
                return _network.PacketReceive;
            }
        }
        //Scene
        public string Nick
        {
            get
            {
                return _profile.Nick;
            }

            set
            {
                _profile.Nick = value;
            }
        }

        public bool IsSignIn
        {
            get
            {
                return _profile.IsSignIn;
            }
        }
    }
}
