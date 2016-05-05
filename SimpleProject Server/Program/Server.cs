using System.Threading;
using SimpleProject.Mess;
using SimpleProject.Comm;
using SimpleProject.Net;
using SimpleProject.Sys;
using SimpleProject.Sce;

namespace SimpleProject
{
    /**
    <summary> 
    Управление сервером.
    </summary>
    */
    sealed class Server
    {
        MessagesManager _messagesManager;
        SceneServerMenu _scene;
        NetworkServerMachine _network;
        ScenarioMachine _scenario;
        ConsoleCtrl cc;
        public Server()
        {
            _scene = new SceneServerMenu();
           _messagesManager = new MessagesManager();
            _network = new NetworkServerMachine(_messagesManager);
            cc = new ConsoleCtrl();
            ParametersServer p = new ParametersServer(_messagesManager, _scene);
            _scenario = new ScenarioMachine(p);
            _scenario.AddScenario(_messagesManager);
            _scenario.AddScenario(_scene);
        }
        public void Start()
        {
            cc.ControlEvent += new ConsoleCtrl.ControlEventHandler(this.Close);
            Go();
        }
        private void Close(ConsoleCtrl.ConsoleEvent consoleEvent)
        {
            if (consoleEvent == ConsoleCtrl.ConsoleEvent.CtrlClose)
            {
                _network.Stop();
                _scenario.Stop();
                _network.Close();
                _scenario.Close();
                _network = null;
                System.Environment.Exit(-1);
            }
        }

        private void Go()
        {
            _network.Start();
            _scenario.Start();
            while (true)
            {
                Thread.Sleep(int.MaxValue);
            }
        }
    }
}

