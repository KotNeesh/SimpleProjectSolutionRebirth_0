using UnityEngine;

namespace SimpleProject.Sce
{
    public enum HelperMouseState
    {
        Nope,
        Down,
        Pressed,
        Up
    }
    public class MouseButtonState
    {
        HelperMouseState _state;
        public void Set(bool isPressed)
        {
            if (isPressed)
            {
                switch (_state)
                {
                    case HelperMouseState.Pressed:
                        break;
                    case HelperMouseState.Down:
                        _state = HelperMouseState.Pressed;
                        break;
                    case HelperMouseState.Nope:
                        _state = HelperMouseState.Down;
                        break;
                    case HelperMouseState.Up:
                        _state = HelperMouseState.Down;
                        break;
                }
            }
            else
            {
                switch (_state)
                {
                    case HelperMouseState.Nope:
                        break;
                    case HelperMouseState.Up:
                        _state = HelperMouseState.Nope;
                        break;
                    case HelperMouseState.Pressed:
                        _state = HelperMouseState.Up;
                        break;
                    case HelperMouseState.Down:
                        _state = HelperMouseState.Up;
                        break;
                }
            }
        }
        public HelperMouseState Get()
        {
            return _state;
        }
    }
    public class MouseInfo
    {
        public Vector2 Pos;
        public MouseButtonState State = new MouseButtonState();
    }
}
