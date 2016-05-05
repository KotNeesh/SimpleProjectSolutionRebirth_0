using UnityEngine;

namespace SimpleProject.Sce
{
    public interface IObj2D
    {
        Vector2 GetPos();
        Vector2 GetPosSurface(Vector2 destination);
    }
}
