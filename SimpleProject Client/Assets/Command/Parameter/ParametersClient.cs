using SimpleProject.Sce;
using SimpleProject.Mess;

namespace SimpleProject.Comm
{

    /**
    <summary> 
    Хранит все необходимые параметры для исполнения команд.
    </summary>
    */
    class ParametersClient : IParameters,
        IParametersSceneMenuMessages,
        IParametersMessagesManagerScenario
    {
        MessagesManager _messagesManager;
        SceneClientMenu _scene;
        public ParametersClient(MessagesManager messagesManager, SceneClientMenu scene)
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
