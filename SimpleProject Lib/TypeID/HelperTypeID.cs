using System;


namespace SimpleProject.Mess
{
    using TypeID = Byte;
    /**
    <summary> 
    Реестр всех типов сообщений.
    </summary>
    */
    public enum HelperTypeID : TypeID
    {
        Account,
        Chat,
        Alive,
        Profile
    }
}
