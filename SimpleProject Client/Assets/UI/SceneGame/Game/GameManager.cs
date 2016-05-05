using UnityEngine;

namespace SimpleProject.Sce
{
    public class GameManager : MonoBehaviour
    {
        GameMap _map;
        public GUIArrow Arrow;
        GameController _controller = new GameController();
        void Start()
        {
            _map = new GameMap(_controller);
        }
       
        private Vector2 GetMousePos()
        {
            Vector2 pos;
            pos = Input.mousePosition;
            pos.y = Screen.height - pos.y;
            return pos;
        }
        public void OnGUI()
        {

            _controller.GetMouse().Pos = GetMousePos();
            _controller.GetMouse().State.Set(Input.GetMouseButton(0));

            _controller.GetLink().Focus = _map.FindFocusSimplus();
            _controller.GetLink().Update(_controller.GetMouse().State.Get());



            _map.Draw();

            MessageLink msg = _controller.GetLink().GetMessage();
            _map.SetMessage(msg);

            if (_controller.GetLink().Source != null && _controller.GetLink().Focus != _controller.GetLink().Source && _controller.GetLink().Destination == null)
            {
                Arrow.SetSource(_controller.GetLink().Source);

                Arrow.SetDestination(GetMousePos());

                Arrow.SetActive(true);
            }
            else
            {
                Arrow.SetActive(false);
            }
            
        }
    }
}
