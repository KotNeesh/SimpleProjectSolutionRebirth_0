using System;
using System.IO;

namespace SimpleProject.Mess
{
    using SizePacket = UInt16;
    using TypeID = Byte;
    public class UnpackerChat : IUnpacker
    {
        TypeID ITypeID.Type
        {
            get
            {
                return (TypeID)HelperTypeID.Chat;
            }
        }
        public PacketState CreateMessage(ref IMessage message, BinaryReader reader, SizePacket size)
        {
            String line = reader.ReadString();
            if (reader.BaseStream.Position != size) return PacketState.SizeOut;
            message = new MessageChat(line);
            return PacketState.Ok;
        }

        
    }
}