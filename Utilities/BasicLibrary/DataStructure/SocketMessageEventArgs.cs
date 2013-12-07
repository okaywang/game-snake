using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.DataStructure
{
    public class SocketMessageEventArgs : EventArgs
    {
        private byte[] _buffer;
        private int _size;
        private EndPoint _ep;
        public SocketMessageEventArgs(byte[] buffer, int size, EndPoint ep)
        {
            _buffer = buffer;
            _size = size;
            _ep = ep;
        }
        public byte[] Buffer
        {
            get { return _buffer; }
        }
        public int Size
        {
            get { return _size; }
        }
        public EndPoint EndPoint
        {
            get { return _ep; }
        }
    }
}
