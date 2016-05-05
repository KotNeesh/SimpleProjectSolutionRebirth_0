

namespace SimpleProject.Comm
{
    public interface IScenario
    {
        ICommand Get();
        void Set(ICommand command);
    }
}