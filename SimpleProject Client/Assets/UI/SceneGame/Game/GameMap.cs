using UnityEngine;
using System.Collections.Generic;

namespace SimpleProject.Sce
{
    public class GameMap
    {
        List<Simplus> _simpluses;
        public GameMap(GameController controller)
        {
            Texture2D texture = Resources.Load<Texture2D>("TextureSimpluses");
            _simpluses = new List<Simplus>();
            _simpluses.Add(new Simplus(controller, texture, new Vector2(300, 150)));

            _simpluses.Add(new Simplus(controller, texture, new Vector2(1000, 400)));
        }
        public Simplus FindFocusSimplus()
        {
            foreach (Simplus simplus in _simpluses)
            {
                if (simplus.IsFocus())
                {
                    return simplus;
                }
            }
            return null;
        }
        public void Draw()
        {
            foreach (Simplus simplus in _simpluses)
            {
                simplus.Draw();
            }
            
        }
        public void SetMessage(MessageLink message)
        {
            if (message == null) return;
            foreach (Simplus simplus in _simpluses)
            {
                if (simplus == message.Source)
                {
                    simplus.SetLink(message.Destination);
                }
            }
        }
    }
}
