using System;
using System.Collections.Generic;
using System.IO;
using SimpleProject.Net;

namespace SimpleProject.Mess
{
    using SizePacket = UInt16;
    using TypeID = Byte;
    /**
    <summary> 
    Реестр всех упаковщиков сообщений.
    </summary>
    */
    public static class RegisterPacker
    {

        private static Dictionary<TypeID, IPacker> _dictionary = GetDictionary();
        private static Dictionary<TypeID, IPacker> GetDictionary()
        {
            var assemblyType = typeof(RegisterPacker);

            var packers = new Dictionary<TypeID, IPacker>();
            foreach (var type in assemblyType.Assembly.GetTypes())
            {
                if (!type.IsClass)
                    continue;

                if (type.IsAbstract)
                    continue;


                if (typeof(IPacker).IsAssignableFrom(type))
                {
                    IPacker p = Activator.CreateInstance(type) as IPacker;
                    packers.Add(p.Type, p);
                }
                    
            }

            return packers;
        }
        private static IPacker  Find(TypeID type)
        {
            if (_dictionary.ContainsKey(type))
                return _dictionary[type];
            return null;
        }
        public static void CreatePacket(ref Packet packet, IMessage message)
        {
            packet = null;
            using (MemoryStream stream = new MemoryStream())
            {
                SizePacket size = 0;
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(size); 
                    writer.Write(message.Type);
                    IPacker packer = Find(message.Type);
                    packer.CreatePacket(writer, message);
                    size = (SizePacket)(stream.Length - sizeof(SizePacket));
                    stream.Position = 0;
                    writer.Write(size);
                    packet =  new Packet(stream.ToArray());
                }
            }
        }
    }
}
