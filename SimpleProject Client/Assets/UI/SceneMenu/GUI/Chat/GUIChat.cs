using UnityEngine;
using UnityEngine.UI;
using SimpleProject.Mess;
using SimpleProject.Comm;
using System.Collections;

namespace SimpleProject.Sce
{
    public class GUIChat : MonoBehaviour
    {
        public SceneClientMenu Menu;
        public Button ButtonSend;
        public InputField InputChat;
        public Text OutputChat;
        //public IMessageContainer _container = new MessageContainer();
        public Scrollbar Scrollbar;
        private ChatHistory _history = new ChatHistory(64);
        private bool _isFixed = true;
        private bool _isZeroed = true;
        private bool _isZeroing = false;

        void Start()
        {

        }

        public void SetStateSignIn(bool isSignIn)
        {
            //ButtonSend.interactable = isSignIn;
            //InputChat.interactable = isSignIn;

            ButtonSend.interactable = true;
            InputChat.interactable = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (_history.IsChanged)
            {
                Scrollbar.size = 0.3f;
                Scrollbar.value = 0.0f;
                OutputChat.text = _history.ToString();
            }
        }

        public void SendToChat()
        {
            //OutputChat.text += "\n" + InputChat.text;
            IMessage msg = new MessageChat(InputChat.text);
            InputChat.text = string.Empty;
            ICommand cmd = new CommandSendMessageNetwork(msg);
            //Menu.GetScenario().Set(cmd);
            Set(msg as MessageChat);
            FixAtTheBottom();
        }

        public void Set(MessageChat message)
        {
            _history.Set(message);
        }

        private void FixAtTheBottom()
        {
            _isFixed = true;
            _isZeroed = false;
            _isZeroing = true;
        }
    }
}

