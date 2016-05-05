using UnityEngine;

namespace SimpleProject.Sce
{
    
    public class ShearsInfo
    {
        public Vector2 Source;
        public Vector2 Destination;
    }

    public class GameController
    {
        LinkInfo _link = new LinkInfo();
        ShearsInfo _shears = new ShearsInfo();
        MouseInfo _mouse = new MouseInfo();
        
        public LinkInfo GetLink()
        {
            return _link;
        }
        public ShearsInfo GetShears()
        {
            return _shears;
        }
        public MouseInfo GetMouse()
        {
            return _mouse;
        }
        public void SetMouse(Vector2 pos, bool isPressed)
        {
            _mouse.Pos = pos;
            _mouse.State.Set(isPressed);
        }
    }
}
