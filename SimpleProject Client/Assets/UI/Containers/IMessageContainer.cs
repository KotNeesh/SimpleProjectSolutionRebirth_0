
namespace SimpleProject.Mess
{
    public interface IMessageContainer
    {
        IMessage Get();
        void Set(IMessage message);
        bool IsEmpty { get; }
    }
}
