using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.DataStructure
{
    public class SocketConnectedEventArgs : EventArgs
    {
        private IPEndPoint _IPEndPoint;
        public SocketConnectedEventArgs(IPEndPoint ep)
        {
            _IPEndPoint = ep;
        }

        public IPEndPoint IPEndPoint
        {
            get { return _IPEndPoint; }
        }
    }
}
