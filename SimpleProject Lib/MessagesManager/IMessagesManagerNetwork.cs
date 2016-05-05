namespace SimpleProject.Mess
{
    /**
    <summary> 
    Периферия для интернета.
    </summary>
    */
    public interface IMessagesManagerNetwork
    {
        void Set(IMessage message);
        IMessage Get();
    }
}
