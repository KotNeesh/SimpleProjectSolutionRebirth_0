using UnityEngine;
using SimpleProject.Comm;

namespace SimpleProject.Sce
{
    public class SceneGame : MonoBehaviour
    {
        private IScenario _scenario = new Scenario();

        public IScenario GetScenario()
        {
            return _scenario;
        }
    }
}
