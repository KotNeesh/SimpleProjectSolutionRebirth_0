using UnityEngine;

namespace SimpleProject.Sce
{
    public class SimplusLink
    {
        private GUISimplusLink _GUI;
        private Simplus _source;
        private Simplus _destination;
        public Simplus Source
        {
            get
            {
                return _source;
            }
        }
        public Simplus Destination
        {
            get
            {
                return _destination;
            }
        }
        public SimplusLink(Simplus source, Simplus destination, Texture2D texture)
        {
            _source = source;
            _destination = destination;
            _GUI = new GUISimplusLink(this, texture);
        }
        public void Draw()
        {
            _GUI.Draw();
        }
    }
}
