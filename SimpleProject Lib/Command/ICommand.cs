
namespace SimpleProject.Comm
{
    /**
    <summary>
    Команда исполняющая сценарную операцию.
    </summary>
    */
    public interface ICommand
    {

        void Do(IParameters parameters);
    }
}
