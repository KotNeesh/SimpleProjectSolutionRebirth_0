using UnityEngine;
using UnityEngine.UI;
using SimpleProject.Mess;
using SimpleProject.Comm;

namespace SimpleProject.Sce
{
    public class GUISign : MonoBehaviour, IGUISign
    {
        public SceneClientMenu Menu;
        public IMessageContainer _container = new MessageContainer();

        private MessageAccount.StateType _state;

        public GameObject ObjEmail;
        public GameObject ObjPassword;
        public GameObject ObjNick;
        public GameObject ObjSign;
        public GameObject ObjInfo;
        public GameObject ObjOk;

        public ButtonSign BtnSign;

        public InputField InputEmail;
        public InputField InputNick;
        public InputField InputPassword;

        public Text TextInfo;
        public void SetState(MessageAccount.StateType state)
        {
            if (state == MessageAccount.StateType.SignIn)
            {
                SetStateSignIn();
            }
            else if (state == MessageAccount.StateType.SignUp)
            {
                SetStateSignUp();
            }
            else if (state == MessageAccount.StateType.SignOut)
            {
                SetStateSignOut();
            }
            else if (state == MessageAccount.StateType.ChangePassword)
            {
                SetStateChangePassword();
            }
        }
        private void SetStateSignIn()
        {
            _state = MessageAccount.StateType.SignIn;
            SetStateAllOff();
            ObjEmail.SetActive(true);
            ObjPassword.SetActive(true);
            BtnSign.SetState(_state);
            ObjSign.SetActive(true);
        }
        private void SetStateSignUp()
        {
            _state = MessageAccount.StateType.SignUp;
            SetStateAllOff();
            ObjEmail.SetActive(true);
            ObjPassword.SetActive(true);
            ObjNick.SetActive(true);
            BtnSign.SetState(_state);
            ObjSign.SetActive(true);
        }
        private void SetStateSignOut()
        {
            _state = MessageAccount.StateType.SignOut;
            SetStateAllOff();
            BtnSign.SetState(_state);
            ObjSign.SetActive(true);
            SendToServer();
        }
        private void SetStateChangePassword()
        {
            _state = MessageAccount.StateType.ChangePassword;
            SetStateAllOff();
            ObjPassword.SetActive(true);
            BtnSign.SetState(_state);
            ObjSign.SetActive(true);
        }

        private void SetStateAllOff()
        {
            ObjEmail.SetActive(false);
            ObjPassword.SetActive(false);
            ObjNick.SetActive(false);
            ObjSign.SetActive(false);
            ObjInfo.SetActive(false);
            ObjOk.SetActive(false);
        }
        public void Clear()
        {
            InputEmail.text = string.Empty;
            InputNick.text = string.Empty;
            InputPassword.text = string.Empty;
            TextInfo.text = string.Empty;
        }
        public void SendToServer()
        {
            IMessage m = new MessageAccount(_state, InputEmail.text, InputPassword.text, InputNick.text);
            TextInfo.text = "Wait...";
            ObjInfo.SetActive(true);
            ICommand c = new CommandSendMessageNetwork(m);
            IScenario s = Menu.GetScenario();
            s.Set(c);
        }
        public void Update()
        {
            if (_container.IsEmpty) return;
            MessageAccount m = _container.Get() as MessageAccount;

            if (m.State == _state)
            {
                if (m.Success)
                {
                    SetStateAllOff();
                    TextInfo.text = "Luck!";
                    ObjInfo.SetActive(true);
                    ObjOk.SetActive(true);
                    
                }
                else
                {
                    TextInfo.text = "Error, try again";
                }
            }
            if (m.State == MessageAccount.StateType.SignIn)
            {
                Menu.SetStateSignIn(m.Success);
            }
            else if(m.State == MessageAccount.StateType.SignOut)
            {
                Menu.SetStateSignIn(!m.Success);
            }
        }
        public void Set(MessageAccount message)
        {
            _container.Set(message);
        }
    }
}
