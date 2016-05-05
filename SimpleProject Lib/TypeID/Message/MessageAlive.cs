using System;


namespace SimpleProject.Mess
{
    using TypeID = Byte;
    public sealed class MessageAlive : MessageBase
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperTypeID.Alive;
            }
        }
    };
}
