using UnityEngine;

namespace SimpleProject.Sce
{
    public class Circle : IObj2D
    {
        protected Vector2 _pos;
        protected float _radius;
        Circle(Vector2 pos, float radius)
        {
            _pos = pos;
            _radius = radius;
        }
        void SetRadius(float radius)
        {
            _radius = radius;
        }

        public Vector2 GetPos()
        {
            return _pos;
        }

        public Vector2 GetPosSurface(Vector2 destination)
        {
            Vector2 v = destination - _pos;
            v = v.normalized;
            return _pos + v*_radius;
        }
    }
}

