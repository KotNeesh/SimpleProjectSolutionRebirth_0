using System;
using System.Collections.Generic;
using SimpleProject.Mess;
using SimpleProject.Comm;
using SimpleProject.Use;
using SimpleProject.Data;

namespace SimpleProject.Sce
{
    /**
    <summary> 
    Обрабатывает события в меню.
    </summary>
    */
    class SceneServerMenu : IScenario, ISceneMenuMessages
    {
        Scenario _scenario;
        DataSet _data;
        public SceneServerMenu()
        {
            _scenario = new Scenario();
            _data = new DataSet();
        }
        public ICommand Get()
        {
            return ((IScenario)_scenario).Get();
        }

        public void Set(ICommand command)
        {
            ((IScenario)_scenario).Set(command);
        }

        void ISceneMenuMessages.Set(MessageChat message)
        {
            IUserProfile user = message.Users[0] as IUserProfile;
            //if (user.Nick == String.Empty) return;
            
            message.Line = DateTime.Now.ToString("T") + "  <<" + user.Nick + ">>:  " + message.Line;
            message.Users.Clear();
            ICommand c = new CommandSendMessageNetwork(message);
            _scenario.Set(c);
        }

        void ISceneMenuMessages.Set(MessageAccount message)
        {
            MessageAccount m;
            bool success = false;
            User user = message.Users[0] as User;
            if (message.State == MessageAccount.StateType.SignUp)
            {
                success = _data.SignUp(message.Email, message.Password, message.Nick);
                
            }
            else if (message.State == MessageAccount.StateType.SignIn)
            {
                IUserProfile p = _data.SignIn(message.Email, message.Password);
                if (p != null)
                {
                    success = true;
                    user.UpdateProfile(p);

                    MessageProfile mm = new MessageProfile(user.Nick, 0);
                    mm.Users.Add(message.Users[0]);
                    ICommand cc = new CommandSendMessageNetwork(mm);
                    _scenario.Set(cc);
                }
            }
            else if (message.State == MessageAccount.StateType.SignOut)
            {
                success = true;
                user.Nick = string.Empty;
            }
            else if (message.State == MessageAccount.StateType.ChangePassword)
            {
                if (user.Nick != null)
                {
                    _data.UpdatePassword(user.Nick, message.Password);
                    success = true;
                }
            }
            m = new MessageAccount(message.State, success);
            m.Users.Add(message.Users[0]);
            ICommand c = new CommandSendMessageNetwork(m);
            _scenario.Set(c);
        }
        void ISceneMenuMessages.Set(MessageProfile message)
        {
            //nothing
        }

        

        
    }
}
