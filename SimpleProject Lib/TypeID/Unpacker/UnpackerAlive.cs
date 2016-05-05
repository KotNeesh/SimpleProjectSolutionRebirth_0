using System;
using System.IO;

namespace SimpleProject.Mess
{
    using SizePacket = UInt16;
    using TypeID = Byte;
    public class UnpackerAlive : IUnpacker
    {
        TypeID ITypeID.Type
        {
            get
            {
                return (TypeID)HelperTypeID.Alive;
            }
        }
        public PacketState CreateMessage(ref IMessage message, BinaryReader reader, SizePacket size)
        {
            if (size != 1) return PacketState.SizeOut;
            message = new MessageAlive();
            return PacketState.Ok;
        }

        
    }
}
