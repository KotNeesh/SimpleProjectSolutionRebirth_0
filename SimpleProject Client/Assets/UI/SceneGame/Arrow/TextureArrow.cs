using UnityEngine;
using UnityEngine.UI;

/*
namespace SimpleProject.Sce
{
    public class TextureArrow : MonoBehaviour
    {
        public GameObject _myObj;
        public Image _myImage;
        public DragInfo _drag;
        void Start()
        {
            _myImage.sprite = Resources.Load<Sprite>("Arrow");
            _myObj.transform.
        }

        public void Update()
        {
            Rescale();
        }

        private void Rescale()
        {
            Vector2 _scale = new Vector2(1f, 1f);

            Vector2 nor = new Vector2();
            nor.x = 1;
            nor.y = 0;
            Vector2 vec = _drag._destination - _drag._source;
            float _angle = Vector2.Angle(nor, vec);
            Vector3 cross = Vector3.Cross(nor, vec);
            if (cross.z > 0)
            {
                _angle = 360 - _angle;
            }

            float length = vec.magnitude;
            _scale.x = length / 110;

            Vector3 axis = new Vector3(0f, 0f, 1f);


            _myObj.transform.Rotate(_myObj.transform.eulerAngles * (-1));
            //_myObj.transform.position = _drag._source;
            
            //_myObj.transform.RotateAround(_drag._source, axis, _angle);
            _myObj.transform.localScale = _scale;
        }

    }
}
*/