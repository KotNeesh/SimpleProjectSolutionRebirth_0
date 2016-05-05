using System;
using System.Collections.Generic;

namespace SimpleProject.Comm
{
    using TypeID = Byte;
    /**
    <summary>
    Реестр всех команд обрабатывающих сообщения из интернета.
    </summary>
    */
    public static class RegisterCommandProcessMessage
    {
        private static Dictionary<TypeID, ICommandProcessMessage> _dictionary = GetDictionary();
        private static Dictionary<TypeID, ICommandProcessMessage> GetDictionary()
        {
            var assemblyType = typeof(RegisterCommandProcessMessage);

            var packers = new Dictionary<TypeID, ICommandProcessMessage>();
            foreach (var type in assemblyType.Assembly.GetTypes())
            {
                if (!type.IsClass)
                    continue;

                if (type.IsAbstract)
                    continue;


                if (typeof(ICommandProcessMessage).IsAssignableFrom(type))
                {
                    ICommandProcessMessage p = Activator.CreateInstance(type) as ICommandProcessMessage;
                    packers.Add(p.Type, p);
                }

            }

            return packers;
        }
        public static ICommandProcessMessage Find(TypeID type)
        {
            if (_dictionary.ContainsKey(type))
                return _dictionary[type];
            return null;
        }
    }
}
