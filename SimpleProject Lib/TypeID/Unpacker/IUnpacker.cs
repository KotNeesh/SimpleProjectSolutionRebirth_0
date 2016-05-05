using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace SimpleProject.Mess
{
    using SizePacket = UInt16;
    public enum PacketState : Byte
    {
        Ok = 0,
        NotReady = 1,
        NotFoundType = 2,
        SizeOut = 3,
        NotParse = 4
    }
    public interface IUnpacker : ITypeID
    {
        PacketState CreateMessage(ref IMessage message, BinaryReader reader, SizePacket size);
    }
}
