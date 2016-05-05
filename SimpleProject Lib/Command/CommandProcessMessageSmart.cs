using SimpleProject.Mess;

namespace SimpleProject.Comm
{
    /**
    <summary>
    Команда для обработки сообщения из интернета.
    </summary>
    */
    public class CommandProcessMessageSmart : ICommand
    {
        private ICommandProcessMessage _command;
        private IMessage _message;
        public CommandProcessMessageSmart(ICommandProcessMessage command, IMessage message)
        {
            _command = command;
            _message = message;
        }

        void ICommand.Do(IParameters parameters)
        {
            _command.Do(parameters, _message);
        }
    }
}
