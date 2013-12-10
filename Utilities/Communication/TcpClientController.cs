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
        public event EventHandler<SocketConnectedEventArgs> ServerConnected;
        public TcpClientController(string hostName, int port)
        {
            _serverHostName = hostName;
            _serverPort = port;
            _tcpClient = new TcpClient();
        }

        public IPEndPoint LocalEndPoint
        {
            get { return _tcpClient.Client.LocalEndPoint as IPEndPoint; }
        }

        public void Connect()
        {
            _tcpClient.Connect(_serverHostName, _serverPort);
            OnServerConnected(_tcpClient.Client.RemoteEndPoint as IPEndPoint);

            _monitorThread = new Thread(ListenServer);
            _monitorThread.Start();
        }

        public void Disconnect()
        {
            _tcpClient.Client.Close();
            //_tcpClient.Close();
        }

        public void Send(byte[] bytes)
        {
            _tcpClient.Client.Send(bytes);
        }


        private void ListenServer(object obj)
        {
            while (true)
            {
                try
                {
                    var size = _tcpClient.Client.Receive(buffer);
                    OnServerDataReceived(buffer, size, _tcpClient.Client.RemoteEndPoint);
                }
                catch (SocketException)
                {
                    break;
                }
            }
        }

        private void OnServerDataReceived(byte[] buffer, int size, EndPoint ep)
        {
            if (ServerDataReceived != null)
            {
                ServerDataReceived(this, new SocketMessageEventArgs(buffer, size, ep));
            }
        }

        private void OnServerConnected(IPEndPoint ep)
        {
            if (ServerConnected != null)
            {
                ServerConnected(this, new SocketConnectedEventArgs(ep));
            }
        }
    }
}
