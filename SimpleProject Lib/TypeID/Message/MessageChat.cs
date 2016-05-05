using System;


namespace SimpleProject.Mess
{
    using TypeID = Byte;
    public sealed class MessageChat : MessageBase
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperTypeID.Chat;
            }
        }

        public string Line;
        public MessageChat(String line)
        {
            Line = line;
        }
    };
}