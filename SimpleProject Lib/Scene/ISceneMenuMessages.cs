using SimpleProject.Mess;

namespace SimpleProject.Sce
{
    /**
    <summary>
    Интерфейс обработки сообщений меню сценой
    </summary>
    */
    public interface ISceneMenuMessages
    {
        void Set(MessageChat message);
        void Set(MessageAccount message);
        void Set(MessageProfile message);
    }
}
