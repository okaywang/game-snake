using BasicLibrary.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationTcpServer
{
    public class TcpClientListener
    {
        private TcpClient _tcpClient;
        private Thread _listenerThread;
        private byte[] buffer;

        public event EventHandler<SocketMessageEventArgs> ClientDataReceived;
        private EventHandler<SocketConnectedEventArgs> _ClientDisconnected;
        public TcpClientListener(TcpClient tcpClient, EventHandler<SocketConnectedEventArgs> clientDisconnected)
        {
            _tcpClient = tcpClient;
            _ClientDisconnected = clientDisconnected;
            buffer = new byte[2048];
        }

        public string HostName
        {
            get { return (_tcpClient.Client.RemoteEndPoint as IPEndPoint).Address.ToString(); }
        }

        public int Port
        {
            get { return (_tcpClient.Client.RemoteEndPoint as IPEndPoint).Port; }
        }

        public void StartSocketListener()
        {
            if (_tcpClient != null)
            {
                _listenerThread = new Thread(ListenClient);
                _listenerThread.Start();
            }
        } 

        internal void StopSocketListener()
        {
            _tcpClient.Client.Close();
        }

        public void SendMessage(byte[] bytes)
        {
            _tcpClient.Client.Send(bytes);
        }

        private void ListenClient(object obj)
        {
            while (true)
            {
                try
                {
                    var size = _tcpClient.Client.Receive(buffer);
                    OnClientDataReceived(buffer, size, _tcpClient.Client.RemoteEndPoint);
                }
                catch (SocketException)
                {
                    OnClientDisconnected(_tcpClient.Client.RemoteEndPoint as IPEndPoint);
                    break;
                }
            }
        }

        private void OnClientDisconnected(IPEndPoint ep)
        {
            if (_ClientDisconnected != null)
            {
                _ClientDisconnected(this, new SocketConnectedEventArgs(ep));
            }
        }

        private void OnClientDataReceived(byte[] buffer, int size, EndPoint ep)
        {
            if (ClientDataReceived != null)
            {
                ClientDataReceived(this, new SocketMessageEventArgs(buffer, size, ep));
            }
        }
    }
}
