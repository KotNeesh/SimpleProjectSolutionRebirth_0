using UnityEngine;
using SimpleProject.Mess;
using SimpleProject.Net;
using SimpleProject.Comm;
using SimpleProject.Sce;

namespace SimpleProject
{
    public class Client : MonoBehaviour
    {
        public SceneClientMenu Menu;
        MessagesManager _messagesManager;
        NetworkClientMachine _network;
        ScenarioMachine _scenario;

        public void Start()
        {
            _messagesManager = new MessagesManager();
            _network = new NetworkClientMachine(_messagesManager);
            ParametersClient p = new ParametersClient(_messagesManager, Menu);
            _scenario = new ScenarioMachine(p);
            _scenario.AddScenario(_messagesManager);
            _scenario.AddScenario(Menu.GetScenario());
            _network.Start();
            _scenario.Start();
        }
        public void OnGUI()
        {
        }



        public void OnDestroy()
        {
            if (_network != null) _network.Close();
            if (_scenario != null) _scenario.Close();
        }
    }
}

