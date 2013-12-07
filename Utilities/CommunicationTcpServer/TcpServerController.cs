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

namespace CommunicationTcpServer
{
    public class TcpServerController
    {
        private TcpListener _tcpListener;
        private List<TcpClientListener> _tcpClientListeners;
        private Thread _clientThread;

        private EventHandler<SocketMessageEventArgs> _dataReceivedhandler;
        public EventHandler<ClientConnectedEventArgs> ClientConnected;
        public TcpServerController(int port,EventHandler<SocketMessageEventArgs> dataReceivedHandler)
        {
            _tcpListener = new TcpListener(IPAddress.Loopback, port);
            _tcpClientListeners = new List<TcpClientListener>();
            _dataReceivedhandler = dataReceivedHandler;
        }

        public void Start()
        {
            _tcpListener.Start(); 

            _clientThread = new Thread(ListenClient);
            _clientThread.Start();
        }


        private void ListenClient(object obj)
        {
            TcpClientListener listener = null;
            while (true)
            {
                var tcpClient = _tcpListener.AcceptTcpClient(); 
                listener = new TcpClientListener(tcpClient);
                _tcpClientListeners.Add(listener);
                listener.ClientDataReceived += _dataReceivedhandler;
                listener.StartSocketListener();

                OnClientConnected(tcpClient.Client.RemoteEndPoint as IPEndPoint);
            }
        }

        private void OnClientConnected(IPEndPoint ep)
        {
            if (ClientConnected !=null)
            {
                ClientConnected(this, new ClientConnectedEventArgs(ep));
            }
        }

        public void SendMessage(byte[] bytes, string hostName, int port)
        {
            var listener = _tcpClientListeners.Find(i => i.HostName == hostName && i.Port == port);
            listener.SendMessage(bytes);
        }
    }
}
