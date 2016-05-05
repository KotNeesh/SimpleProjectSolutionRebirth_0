using System;


namespace SimpleProject.Mess
{
    using TypeID = Byte;
    /**
    <summary>
    Интерфейс определения ID класса.
    </summary>
    */
    public interface ITypeID
    {
        TypeID Type { get; }
    }
}
