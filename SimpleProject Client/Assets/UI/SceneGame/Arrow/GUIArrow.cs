using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleProject.Sce
{
    public class GUIArrow : MonoBehaviour
    {
        public GameObject _myObj;
        public Image _myImage;
        private Simplus _source;
        private float _angle;
        private Vector2 _scale;
        void Start()
        {
            _scale = new Vector2(1f, 1f);
            _myImage.sprite = Resources.Load<Sprite>("Arrow");
            
        }

        public void SetActive(bool value)
        {
            _myObj.SetActive(value);
        }
        public void Update()
        {

        }
        public void SetSource(Simplus simplus)
        {
            if (simplus != null)
            {
                _source = simplus;

                Vector2 v = new Vector2();
                v.x = 1;
                v.y = 0;
                v *= 50;
                
                Vector3 axis = new Vector3(0f, 0f, 1f);
                Vector2 point =  _source.Pos;
                point.y = Screen.height - point.y;
                _myObj.transform.Rotate(_myObj.transform.eulerAngles * (-1));
                _myObj.transform.position = point + v;
                _myObj.transform.RotateAround(point, axis, _angle);
                _myObj.transform.localScale = _scale;
            }
        }
        public void SetDestination(Vector2 mousePos)
        {
            if (_source != null)
            {
                Vector2 nor = new Vector2();
                nor.x = 1;
                nor.y = 0;
                Vector2 vec = mousePos - _source.Pos;
                _angle = Vector2.Angle(nor, vec);
                Vector3 cross = Vector3.Cross(nor, vec);
                if (cross.z > 0)
                {
                    _angle = 360 - _angle;
                }
                float length = vec.magnitude - 50;
                _scale.x = length / 110;
            }
        }
        public void SetDestination(Simplus simplus)
        {
            if (_source != null)
            {
                Vector2 nor = new Vector2();
                nor.x = 1;
                nor.y = 0;
                Vector2 vec = -_source.Pos;// + mousePos -;
                _angle = Vector2.Angle(nor, vec);
                Vector3 cross = Vector3.Cross(nor, vec);
                if (cross.z > 0)
                {
                    _angle = 360 - _angle;
                }
                float length = vec.magnitude - 50;
                _scale.x = length / 110;
            }
            //MyObj.transform.forward = mousePos - (Vector2)MyObj.transform.position;
        }
    }
}
