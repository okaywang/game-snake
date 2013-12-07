using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationTestSocket
{
    public abstract class MessageEntry
    {
        private string _msg;
        private string _host;
        public MessageEntry(string msg, string host)
        {
            _msg = msg;
            _host = host;
        }
        public string Message { get { return _msg; } }
        public string Host { get { return _host; } }
    }

    public class SendingMessageEntry : MessageEntry
    {
        public SendingMessageEntry(string msg, string host)
            : base(msg, host)
        {

        }
        public override string ToString()
        {
            return string.Format("send to pc({0}):\t{1}", this.Host, this.Message);
        }
    }
    public class ReceivedMessageEntry : MessageEntry
    {
        public ReceivedMessageEntry(string msg, string host)
            : base(msg, host)
        {

        }
        public override string ToString()
        {
            return string.Format("from pc({0}):\t{1}", this.Host, this.Message);
        }
    }
}
