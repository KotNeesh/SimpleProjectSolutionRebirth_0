using UnityEngine;
using SimpleProject.Mess;

namespace SimpleProject.Sce
{
    public class GUIAccount : MonoBehaviour
    {
        public GUISign Sign;
        public Case CaseSign;

        public GameObject ObjSignIn;
        public GameObject ObjSignUp;
        public GameObject ObjSignOut;
        public GameObject ObjChangePassword;

        public void SetStateSignIn(bool isSignIn)
        {
            SetStateAllOff();
            if (isSignIn)
            {
                ObjSignOut.SetActive(true);
                ObjChangePassword.SetActive(true);
            }
            else
            {
                ObjSignIn.SetActive(true);
                ObjSignUp.SetActive(true);
            }
        }

        private void SetStateAllOff()
        {
            ObjSignIn.SetActive(false);
            ObjSignUp.SetActive(false);
            ObjSignOut.SetActive(false);
            ObjChangePassword.SetActive(false);
        }
        private void OpenWindow(MessageAccount.StateType state)
        {
            Sign.SetState(state);
            Sign.Clear();
            CaseSign.Open();
        }
        public void OpenSignIn()
        {
            OpenWindow(MessageAccount.StateType.SignIn);
        }
        public void OpenSignUp()
        {
            OpenWindow(MessageAccount.StateType.SignUp);
        }
        public void OpenSignOut()
        {
            OpenWindow(MessageAccount.StateType.SignOut);
        }
        public void OpenChangePassword()
        {
            OpenWindow(MessageAccount.StateType.ChangePassword);
        }
    }
}

