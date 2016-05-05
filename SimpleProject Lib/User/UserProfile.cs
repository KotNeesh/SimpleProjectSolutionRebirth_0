using System;


namespace SimpleProject.Use
{
    /**
    <summary> 
    Хранит все игровые данные пользователя.
    </summary>
    */
    public class UserProfile : IUserProfile
    {
        public String Nick { get; set; }
        public bool IsSignIn
        {
            get
            {
                return Nick != string.Empty;
            }
        }
    }
}
