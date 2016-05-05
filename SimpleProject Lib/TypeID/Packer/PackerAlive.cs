using System;
using System.IO;



namespace SimpleProject.Mess
{
    using TypeID = Byte;
    public class PackerAlive : IPacker
    {
        TypeID ITypeID.Type
        {
            get
            {
                return (TypeID)HelperTypeID.Alive;
            }
        }
        public void CreatePacket(BinaryWriter writer, IMessage message)
        {
            MessageChat m = (MessageChat)message;
            writer.Write(m.Line);
        }
        
    }
}
