using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace SimpleProject.Mess
{
    using SizePacket = UInt16;
    public interface IPacker : ITypeID
    {
        void CreatePacket(BinaryWriter writer, IMessage message);
    }
}
