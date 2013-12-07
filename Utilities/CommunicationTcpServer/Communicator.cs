using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommunicationTcpServer
{
    public class Communicator
    {
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;
        public Communicator(int port)
        {
            _tcpListener = new TcpListener(IPAddress.Loopback, port);
            _tcpClient = new TcpClient();
        }

        public void AcceptClient()
        {
            _tcpListener.Start();
            Trace.WriteLine(string.Format("Listening at {0}:", _tcpListener.LocalEndpoint.ToString()));

            _tcpClient = _tcpListener.AcceptTcpClient();
            Trace.WriteLine(string.Format("client accepted: {0}", _tcpClient.Client.RemoteEndPoint.ToString()));
        }


        public void SendMessage(byte[] bytes)
        {
            var ns = _tcpClient.GetStream();
            ns.Write(bytes, 0, bytes.Length);
        }


    }
}
