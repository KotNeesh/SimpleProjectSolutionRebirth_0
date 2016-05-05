using UnityEngine;
using UnityEngine.UI;
using SimpleProject.Mess;
using SimpleProject.Comm;

namespace SimpleProject.Sce
{
    public class GUIChat : MonoBehaviour
    {
        public SceneClientMenu Menu;
        public Button ButtonSend;
        public InputField InputChat;
        public Text OutputChat;
        public IMessageContainer _container = new MessageContainer();
        // Use this for initialization
        void Start()
        {

        }
        public void SetStateSignIn(bool isSignIn)
        {
            ButtonSend.interactable = isSignIn;
            InputChat.interactable = isSignIn;
        }
        // Update is called once per frame
        void Update()
        {
            if (!_container.IsEmpty)
            {
                MessageChat m = _container.Get() as MessageChat;
                OutputChat.text += "\n" + m.Line;
            }
        }
        public void SendToChat()
        {
            //OutputChat.text += "\n" + InputChat.text;
            IMessage msg = new MessageChat(InputChat.text);
            InputChat.text = string.Empty;
            ICommand cmd = new CommandSendMessageNetwork(msg);
            Menu.GetScenario().Set(cmd);
        }
        public void Set(MessageChat message)
        {
            _container.Set(message);
        }
    }
}

