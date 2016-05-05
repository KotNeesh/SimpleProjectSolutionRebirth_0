using System.Collections.Generic;
using SimpleProject.Use;

namespace SimpleProject.Mess
{
    /**
    <summary>
    Хранит список юзеров от кого отправлено\кому отправить сообщение.
    </summary>
    */
    public abstract class MessageBase : IMessage
    {
        public abstract byte Type { get; }
        public List<IUserNetwork> Users;
        protected MessageBase()
        {
            Users = new List<IUserNetwork>();
        }

        
    }
}


 

