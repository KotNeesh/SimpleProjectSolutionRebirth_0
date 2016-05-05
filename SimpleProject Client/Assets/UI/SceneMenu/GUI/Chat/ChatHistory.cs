using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleProject.Mess;

namespace SimpleProject.Sce
{
    class ChatHistory
    {
        public ChatHistory(int maxSize)
        {
            _container = new List<MessageChat>();
            _maxSize = maxSize;
        }

        private int _maxSize;

        List<MessageChat> _container;

        private bool _isChanged;

        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
        }

        public void Set(MessageChat msg)
        {
            lock(_container)
            {
                if (_container.Count > _maxSize)
                {
                    _container.RemoveRange(0, _maxSize / 2);
                }
                _container.Add(msg);
                _isChanged = true;
            }
        }

        public override String ToString()
        {
            string str = "";
            lock (_container)
            {
                foreach (MessageChat msg in _container)
                {
                    str += '\n';
                    str += msg.Line;
                }
                _isChanged = false;
            }
            return str;
        }

    }
}
