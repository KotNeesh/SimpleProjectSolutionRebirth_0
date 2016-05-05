using System.Net.Sockets;
using System;
using SimpleProject.Use;

namespace SimpleProject.Net
{
    using SizePacket = UInt16;
    /**
    <summary> 
    Обертка на уровне пакетов над TCP протоколом. 
    </summary>
    */
    public static class Network
    {
        public static void Send(IUserNetwork user)
        {
            if (!user.Socket.Connected) return;
            try
            {
                NetworkStream stream = user.Socket.GetStream();
                if (!stream.CanWrite) throw new SystemException("haha");
                while (user.PacketsSend.Count != 0)
                {
                    Packet packet = user.PacketsSend.Dequeue();
                    stream.Write(packet.GetData(), 0, packet.Size);
                }
            }
            catch(Exception ex)
            {

            }
        }
        public static void Receive(IUserNetwork user)
        {
            if (!user.Socket.Connected) return;
            try
            {
                NetworkStream stream = user.Socket.GetStream();
                if (!stream.CanRead) throw new SystemException("haha");
                if (!stream.DataAvailable) return;
                Packet packet = user.PacketReceive;
                if (!packet.SizeReady)
                {
                    Byte[] buf = BitConverter.GetBytes(packet.Size);
                    packet.Pos += (SizePacket)stream.Read(buf, packet.Pos, sizeof(SizePacket) - packet.Pos);
                    packet.Size = BitConverter.ToUInt16(buf, 0);
                    if (packet.Pos == sizeof(SizePacket))
                    {
                        packet.SizeReady = true;
                        packet.Pos = 0;
                    }
                }
                if (packet.SizeReady)
                {
                    packet.Pos += (SizePacket)stream.Read(packet.GetData(), packet.Pos, packet.Size - packet.Pos);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
