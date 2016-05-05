using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;


namespace SimpleProject.Mess
{
    using TypeID = Byte;
    public class PackerAccount : IPacker
    {
        TypeID ITypeID.Type
        {
            get
            {
                return (TypeID)HelperTypeID.Account;
            }
        }
        public void CreatePacket(BinaryWriter writer, IMessage message)
        {
            MessageAccount m = (MessageAccount)message;
            //writer.Write(m.StateValue);
            writer.Write(m.Success);
            writer.Write((Byte)m.State);
            writer.Write(m.Email);
            writer.Write(m.Password);
            writer.Write(m.Nick);
        }
        
    }
}
