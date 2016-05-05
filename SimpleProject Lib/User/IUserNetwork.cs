using System.Collections.Generic;
using System.Net.Sockets;
using SimpleProject.Net;

namespace SimpleProject.Use
{
    public interface IUserNetwork
    {
        TcpClient Socket { get; set; }
        Queue<Packet> PacketsSend { get; }
        Packet PacketReceive { get; }
    }
}
