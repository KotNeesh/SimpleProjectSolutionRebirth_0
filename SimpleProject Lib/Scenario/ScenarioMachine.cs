using System.Collections.Generic;
using System.Threading;
using SimpleProject.Sys;

namespace SimpleProject.Comm
{

    /**
    *<summary>
    Исполняет сценарии, вызывая по очереди команды.
    <para/>
    Для того чтобы он исполнял сценарий, ему надо его добавить.
    <para/>
    Хранит все необходимые параметры для исполнения команд.
    </summary>
    */
    public class ScenarioMachine : StateMachine
    {
        IParameters _parameters;
        List<IScenario> _scenarios;
        public ScenarioMachine(IParameters parameters)
        {
            _parameters = parameters;
            _scenarios = new List<IScenario>();
        }
        public void AddScenario(IScenario scenario)
        {
            _scenarios.Add(scenario);
        }
        protected override bool Init()
        {
            return true;
        }
        protected override void Deinit()
        {
            _scenarios = null;
        }

        protected override bool DoAnything()
        {
            foreach(IScenario s in _scenarios)
            {
                while (true)
                {
                    ICommand c = s.Get();
                    if (c == null) break;
                    c.Do(_parameters);
                }
            }
            Thread.Sleep(100);
            return true;
        }
    }
}
