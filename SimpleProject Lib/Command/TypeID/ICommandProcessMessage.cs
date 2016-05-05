using SimpleProject.Mess;

namespace SimpleProject.Comm
{
    public interface ICommandProcessMessage : ITypeID
    {
        void Do(IParameters parameters, IMessage message);
    }
}
