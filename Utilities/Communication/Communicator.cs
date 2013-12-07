using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationTcpClient
{
    public class Communicator
    {
        private TcpClient _tcpClient;
        private byte[] buffer = new Byte[256];
        public Communicator()
        {
            _tcpClient = new TcpClient();
        }

        public void Connect()
        {
            var hostName = System.Configuration.ConfigurationManager.AppSettings["ServerHostName"];
            var port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ServerPort"]);
            _tcpClient.Connect(hostName, port);
            ListenResponse();
        }

        public void ListenResponse()
        {
            while (true)
            {
                var ns = _tcpClient.GetStream();
                var realLength = ns.Read(buffer, 0, buffer.Length);
                var data = System.Text.Encoding.ASCII.GetString(buffer, 0, realLength);
                Trace.WriteLine(string.Format("Received:{0}", data));
            }
        }
         

        public void Send(byte[] bytes)
        {
            var ns = _tcpClient.GetStream();
            ns.Write(bytes, 0, bytes.Length);
        }
    }
}
