using System;
using System.Collections.Generic;
using System.IO;
using SimpleProject.Net;

namespace SimpleProject.Mess
{
    using TypeID = Byte;
    /**
    <summary> 
    Реестр всех распааковщиков пакетов.
    </summary>
    */
    public static class RegisterUnpacker
    {
        private static Dictionary<TypeID, IUnpacker> _dictionary = GetDictionary();
        private static Dictionary<TypeID, IUnpacker> GetDictionary()
        {
            var assemblyType = typeof(RegisterUnpacker);

            var packers = new Dictionary<TypeID, IUnpacker>();
            foreach (var type in assemblyType.Assembly.GetTypes())
            {
                if (!type.IsClass)
                    continue;

                if (type.IsAbstract)
                    continue;


                if (typeof(IUnpacker).IsAssignableFrom(type))
                {
                    IUnpacker p = Activator.CreateInstance(type) as IUnpacker;
                    packers.Add(p.Type, p);
                }

            }

            return packers;
        }
        private static IUnpacker Find(TypeID type)
        {
            if (_dictionary.ContainsKey(type))
                return _dictionary[type];
            return null;
        }

        public static PacketState CreateMessage(ref IMessage message, Packet packet)
        {
            message = null;
            if (!packet.IsReady) return PacketState.NotReady;
            if (packet.Size < sizeof(TypeID)) return PacketState.SizeOut;
            using (MemoryStream stream = new MemoryStream(packet.GetData()))
            {
                if (!stream.CanRead) throw new SystemException("haha");
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    TypeID type = reader.ReadByte();
                    IUnpacker unpacker = Find(type);
                    return unpacker.CreateMessage(ref message, reader, packet.Size);
                }
            }
        }
    }
}
