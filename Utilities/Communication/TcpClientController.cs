using BasicLibrary.DataStructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationTcpClient
{
    public class TcpClientController
    {
        private TcpClient _tcpClient;
        private byte[] buffer = new Byte[1024];
        private string _serverHostName;
        private int _serverPort;
         
        private Thread _monitorThread;
        public event EventHandler<SocketMessageEventArgs> ServerDataReceived;
        public TcpClientController(string hostName,int port)
        {
            _serverHostName = hostName;
            _serverPort = port;
            _tcpClient = new TcpClient();
        }

        public void Connect()
        {
            _tcpClient.Connect(_serverHostName, _serverPort);
            _monitorThread = new Thread(ListenServer);
            _monitorThread.Start();
        }

        private void ListenServer(object obj)
        {
            while (true)
            {
                var size = _tcpClient.Client.Receive(buffer);
                OnServerDataReceived(buffer, size, _tcpClient.Client.RemoteEndPoint);
            }
        }
         

        public void Send(byte[] bytes)
        {
            _tcpClient.Client.Send(bytes);
        }

        private void OnServerDataReceived(byte[] buffer, int size, EndPoint ep)
        {
            if (ServerDataReceived != null)
            {
                ServerDataReceived(this, new SocketMessageEventArgs(buffer, size, ep));
            }
        }
    }
}
