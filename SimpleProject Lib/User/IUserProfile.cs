using System;


namespace SimpleProject.Use
{
    public interface IUserProfile
    {
        String Nick { get; set; }
        bool IsSignIn { get; }
    }
}
