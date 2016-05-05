using UnityEngine;

namespace SimpleProject.Sce
{
    public class DragInfo
    {
        private IObj2D _source;
        private IObj2D _destination;
        public void SetSource(IObj2D source)
        {
            _source = source;
        }
        public void SetDestination(IObj2D destination)
        {
            _destination = destination;
        }
        public Vector2 GetPosSource()
        {
            if (_source == null || _destination == null)
            {
                return new Vector2();
            }
            return _source.GetPosSurface(_destination.GetPos());
        }
        public Vector2 GetPosDestination()
        {
            if (_source == null || _destination == null)
            {
                return new Vector2();
            }
            return _destination.GetPosSurface(_source.GetPos());
        }
    }
}
