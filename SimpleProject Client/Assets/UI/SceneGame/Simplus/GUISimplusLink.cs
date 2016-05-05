using UnityEngine;

namespace SimpleProject.Sce
{
    public class GUISimplusLink
    {
        private SimplusLink _myObj;

        private Texture2D _texture;
        private Rect _texPos;

        private Vector2 _size;
        private Vector2 _pos;
        private Rect _buffRect = new Rect();
        public GUISimplusLink(SimplusLink myObj, Texture2D texture)
        {
            _myObj = myObj;
            _texture = texture;

            _texPos = new Rect(0, 0, 1f / 4, 1f / 1);

            _pos = myObj.Destination.Pos;
            _size = new Vector2(30f, 30f);
            _buffRect.size = _size;
        }
        public void Draw()
        {
            Vector2 v = (_myObj.Source.Pos - _myObj.Destination.Pos)/50;
            float count = v.magnitude;
            v = v.normalized * 50;
            _buffRect.center = _pos;
            for (int i = 0; i < count; i ++)
            {
                GUI.DrawTextureWithTexCoords(_buffRect, _texture, _texPos);
                _buffRect.center += v;
            }
        }
    }
}
