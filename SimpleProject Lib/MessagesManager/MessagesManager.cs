using System.Collections.Generic;
using SimpleProject.Comm;

namespace SimpleProject.Mess
{
    /**
    <summary> 
    Хранит очередь сообщений для отправки в интернет. 
    <para/>
    Хранит очередь доставленных из сети сообщений,
    для которых находит команду для исполнения сеценарной машиной. 
    </summary>
    */
    public class MessagesManager : IScenario, IMessagesManagerNetwork, IMessagesManagerScenario
    {
        private Scenario _scenario;
        private Queue<IMessage> _messagesNetwork;
	    public MessagesManager()
        {
            _scenario = new Scenario();
            _messagesNetwork = new Queue<IMessage>();
        }

        void IMessagesManagerNetwork.Set(IMessage message)
        {
            
            if (message != null)
            {
                ICommandProcessMessage c = RegisterCommandProcessMessage.Find(message.Type);
                if (c != null)
                {
                    ICommand cs = new CommandProcessMessageSmart(c, message);
                    this.Set(cs);
                }
            }
        }

        IMessage IMessagesManagerNetwork.Get()
        {
            if (_messagesNetwork.Count == 0) return null;
            else
            {
                IMessage m = null;
                lock (_messagesNetwork)
                {
                    m = _messagesNetwork.Dequeue();
                }
                return m;
            }
        }

        void IMessagesManagerScenario.Set(IMessage message)
        {
            if (message != null)
            {
                lock (_messagesNetwork)
                {
                    _messagesNetwork.Enqueue(message);
                }
            }
        }

        public ICommand Get()
        {
            return ((IScenario)_scenario).Get();
        }

        public void Set(ICommand command)
        {
            ((IScenario)_scenario).Set(command);
        }
    }

}
