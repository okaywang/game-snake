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
        public EventHandler<SocketConnectedEventArgs> ClientConnected;
        public EventHandler<SocketConnectedEventArgs> ClientDisconnected;
        public TcpServerController(int port, EventHandler<SocketMessageEventArgs> dataReceivedHandler)
        {
            _tcpListener = new TcpListener(IPAddress.Loopback, port);
            _tcpClientListeners = new List<TcpClientListener>();
            _dataReceivedhandler = dataReceivedHandler;
            ClientDisconnected += ClientDisconnectedHandler;
        }

        public List<TcpClientListener> TcpClientListeners
        {
            get { return _tcpClientListeners; }
        }

        public void Start()
        {
            _tcpListener.Start();

            _clientThread = new Thread(ListenClient);
            _clientThread.Start();
        }

        public void Stop()
        {
            _tcpListener.Stop();
            //foreach (var clientListener in _tcpClientListeners)
            //{
            //    clientListener.StopSocketListener();
            //}
        }

        private void ListenClient(object obj)
        {
            TcpClientListener listener = null;
            while (true)
            {
                try
                {
                    var tcpClient = _tcpListener.AcceptTcpClient();
                    listener = new TcpClientListener(tcpClient, ClientDisconnected);
                    _tcpClientListeners.Add(listener);
                    listener.ClientDataReceived += _dataReceivedhandler;
                    listener.StartSocketListener();

                    OnClientConnected(tcpClient.Client.RemoteEndPoint as IPEndPoint);
                }
                catch (SocketException ex)
                {
                    EventLog.WriteEntry("Application", ex.Message);
                    break;
                }
            }
        }


        private void ClientDisconnectedHandler(object sender, SocketConnectedEventArgs e)
        {
            _tcpClientListeners.RemoveAll(p => p.HostName == e.IPEndPoint.Address.ToString() && p.Port == e.IPEndPoint.Port);
        }

        private void OnClientConnected(IPEndPoint ep)
        {
            if (ClientConnected != null)
            {
                ClientConnected(this, new SocketConnectedEventArgs(ep));
            }
        }

        public void SendMessage(byte[] bytes, string hostName, int port)
        {
            var listener = _tcpClientListeners.Find(i => i.HostName == hostName && i.Port == port);
            SendMessage(bytes, listener);
        }

        public void SendMessage(byte[] bytes, TcpClientListener clientListener)
        {
            clientListener.SendMessage(bytes);
        }
    }
}
