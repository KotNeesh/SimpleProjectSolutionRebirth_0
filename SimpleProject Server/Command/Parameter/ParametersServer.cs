using SimpleProject.Mess;
using SimpleProject.Sce;

namespace SimpleProject.Comm
{
    /**
    <summary> 
    Хранит все необходимые параметры для исполнения команд.
    </summary>
    */
    class ParametersServer : IParameters,
        IParametersSceneMenuMessages,
        IParametersMessagesManagerScenario
    {
        MessagesManager _messagesManager;
        SceneServerMenu _scene;
        public ParametersServer(MessagesManager messagesManager, SceneServerMenu scene)
        {
            _messagesManager = messagesManager;
            _scene = scene;
        }
        ISceneMenuMessages IParametersSceneMenuMessages.Get()
        {
            return _scene;
        }

        IMessagesManagerScenario IParametersMessagesManagerScenario.Get()
        {
            return _messagesManager;
        }
    }
}
