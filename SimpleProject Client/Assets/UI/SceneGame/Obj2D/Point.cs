using UnityEngine;

namespace SimpleProject.Sce
{
    public class Point : IObj2D
    {
        private Vector2 _pos;
        Point(Vector2 pos)
        {
            _pos = pos;
        }
        public Vector2 GetPos()
        {
            return _pos;
        }

        public Vector2 GetPosSurface(Vector2 destination)
        {
            return _pos;
        }
    }
}
