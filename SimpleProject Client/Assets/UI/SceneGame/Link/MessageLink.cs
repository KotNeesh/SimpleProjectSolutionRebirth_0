using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleProject.Sce
{
    public class MessageLink
    {
        private Simplus _source;
        private Simplus _destination;
        public Simplus Source
        {
            get
            {
                return _source;
            }
        }
        public Simplus Destination
        {
            get
            {
                return _destination;
            }
        }
        public MessageLink(LinkInfo info)
        {
            _source = info.Source;
            info.Source = null;
            _destination = info.Destination;
            info.Destination = null;
        }
    }
}
