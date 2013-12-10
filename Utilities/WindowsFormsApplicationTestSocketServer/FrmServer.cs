using BasicLibrary.DataStructure;
using CommunicationTcpServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplicationTestSocketLibrary;

namespace WindowsFormsApplicationTestSocketServer
{
    public partial class FrmServer : Form
    {
        private List<Seat> seats = new List<Seat>();
        private TcpServerController _server;
        public FrmServer()
        {
            InitializeComponent();
            this.richTextBox1.ReadOnly = true;
            this.btnSend.Enabled = false;
            _server = new TcpServerController(7788, ClientDataReceivedHandler);
            _server.ClientConnected += ClientConnectedHandler;
            _server.ClientDisconnected += ClientDisconnectedHandler;
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            if (this.cmbClientList.Text == string.Empty)
            {
                MessageBox.Show("plz choose a client");
                return;
            }
            var sm = new SendingMessageEntry(this.textBox1.Text, this.cmbClientList.Text);
            var ep = this.cmbClientList.Text.Split(':');
            _server.SendMessage(System.Text.Encoding.ASCII.GetBytes(sm.Message), ep[0], Int32.Parse(ep[1]));
            RecordMessage(sm);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _server.Start();
            this.btnSend.Enabled = true;
            this.btnStart.Enabled = false;
        }

        private void RecordMessage(MessageEntry me)
        {
            this.richTextBox1.AppendText(me.ToString());
            this.richTextBox1.AppendText("\n\n");

            this.textBox1.ResetText();
            this.textBox1.Focus();
        }

        private void ClientConnectedHandler(object sender, SocketConnectedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                this.cmbClientList.Items.Add(e.IPEndPoint.ToString());
            }));
        }
        private void ClientDisconnectedHandler(object sender, SocketConnectedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                
                this.cmbClientList.Items.Remove(e.IPEndPoint.ToString());
            }));
        }
        private void ClientDataReceivedHandler(object sender, BasicLibrary.DataStructure.SocketMessageEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                var bytes = new byte[e.Size];
                Array.Copy(e.Buffer, bytes, e.Size);

                var currentEP = e.EndPoint as IPEndPoint;
                var convention = MyHelper.BinaryDeserializeObject<MessageConvention>(bytes);
                if (convention.MsgType == MessageType.OccupySeat)
                {
                    var clients = _server.TcpClientListeners;
                    seats.Add(new Seat() { SeatNumber = convention.Seat.SeatNumber, UserName = convention.Seat.UserName });
                    foreach (var client in clients)
                    {
                        if (client.HostName == currentEP.Address.ToString() && client.Port == currentEP.Port)
                        {
                            continue;
                        }
                        client.SendMessage(bytes);
                    }
                }
                else if (convention.MsgType == MessageType.QueryOccupiedSeats)
                {
                    var ss = new MessageConvention();
                    ss.MsgType = MessageType.QueryOccupiedSeats;
                    ss.OccupiedSeats = seats;
                    var bs = MyHelper.BinarySerializeObject<MessageConvention>(ss);
                    _server.SendMessage(bs, currentEP.Address.ToString(), currentEP.Port);
                }
                else if (convention.MsgType == MessageType.Talk)
                {

                    var msg = System.Text.Encoding.ASCII.GetString(bytes);
                    var rm = new ReceivedMessageEntry(msg, e.EndPoint.ToString());
                    RecordMessage(rm);
                }


            }));
        }

        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server.Stop();
        }
    }
}
