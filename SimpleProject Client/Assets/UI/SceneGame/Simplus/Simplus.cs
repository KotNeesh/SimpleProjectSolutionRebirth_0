using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimpleProject.Sce
{
    public class Simplus
    {
        private SimplusLink _link;
        private GUISimplus _GUI;
        Texture2D _texture;
        public Simplus(GameController controller, Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            _GUI = new GUISimplus(this, controller, texture, pos);
        }
        public bool IsFocus()
        {
            return _GUI.IsContains();
        }
        public void Draw()
        {
            _GUI.Draw();
            if (_link != null)
            {
                _link.Draw();
            }
        }
        public Vector2 Pos
        {
            get
            {
                return _GUI.Pos;
            }
        }
        public void SetLink(Simplus destination)
        {
            _link = new SimplusLink(this, destination, _texture);
        }
    }
}
