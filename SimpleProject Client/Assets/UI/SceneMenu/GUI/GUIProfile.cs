using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleProject.Mess;
using SimpleProject.Use;

namespace SimpleProject.Sce
{
    public class GUIProfile : MonoBehaviour
    {
        public GameObject ObjNick;
        public GameObject ObjHonor;
        public Text TextNick;
        public Text TextHonor;

        public IMessageContainer _container = new MessageContainer();

        private IUserProfile _profile;


        public void Set(MessageProfile message)
        {
            _container.Set(message);

        }

        void Update()
        {
            if (!_container.IsEmpty)
            {
                MessageProfile m = _container.Get() as MessageProfile;
                IUserProfile p = new UserProfile();
                p.Nick = m.Nick;
                UpdateProfile(p);
            }
        }

        public void SetStateSignIn(bool isSignIn)
        {
            if (isSignIn)
            {
                SetOnState();
            }
            else
            {
                SetOffState();
            }
        }

        public void UpdateProfile(IUserProfile profile)
        {
            if (profile != null)
            {
                _profile = profile; _profile = profile;
            }
            TextNick.text = _profile.Nick;
        }
        
        private void SetOnState()
        {
            ObjNick.SetActive(true);
        }
        private void SetOffState()
        {
            ObjNick.SetActive(false);
            TextNick.text = string.Empty;
        }
        
    }
}
