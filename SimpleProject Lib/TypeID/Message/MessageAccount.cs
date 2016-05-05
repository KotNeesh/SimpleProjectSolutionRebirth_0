using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace SimpleProject.Mess
{
    using TypeID = Byte;
    public sealed class MessageAccount : MessageBase
    {
        public override TypeID Type
        {
            get
            {
                return (TypeID)HelperTypeID.Account;
            }
        }
        public enum StateType : Byte
        {
            SignUp = 0,
            SignIn = 1,
            SignOut = 2,
            ChangePassword = 3
        }
        /*
        private struct _Flags
        {
            [BitfieldLength(2)]
            public Byte Type;
            [BitfieldLength(1)]
            public bool Success;
        };

        [StructLayout(LayoutKind.Explicit)]
        private struct _State
        {
            [FieldOffset(0)]
            public Byte Value;
            [FieldOffset(0)]
            public _Flags Flags;
        }
        */
        private bool _success;
        private byte _state;
        //private _State _state;
        private String _email;
        private String _password;
        private String _nick;
        
        //unpacker
        public MessageAccount(String email, String password, String nick, bool success, byte type)//Byte value)
        {
            _email = email;
            _nick = nick;
            _password = password;
            _success = success;
            _state = type;
            //_state.Value = value;
        }
        
        //client
        public MessageAccount(StateType type, String email, String password, String nick = "")
        {
            _email = email;
            _nick = nick;
            _password = password;
            _state = (Byte)type;
            //_state.Flags.Type = (Byte)type;
        }
        //server
        public MessageAccount(StateType type, bool success = true, String nick = "")
        {
            _nick = nick;
            _email = String.Empty;
            _password = String.Empty;
            _state = (Byte)type;
            _success = success;
            //_state.Flags.Type = (Byte)type;
            //_state.Flags.Success = success;
        }
        /*
        public Byte StateValue
        {
            get
            {
                return _state.Value;
            }
            set
            {
                _state.Value = value;
            }
        }
        */
        public StateType State
        {
            get
            {
                //return (StateType)_state.Flags.Type;
                return (StateType)_state;
            }
            set
            {
                //_state.Flags.Type = (Byte)value;
                _state = (Byte)value;
            }
        }
        public bool Success
        {
            get
            {
                return _success;
                //return _state.Flags.Success;
            }
            set
            {
                _success = value;
                //_state.Flags.Success = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string Nick
        {
            get
            {
                return _nick;
            }
            set
            {
                _nick = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
    }
}
