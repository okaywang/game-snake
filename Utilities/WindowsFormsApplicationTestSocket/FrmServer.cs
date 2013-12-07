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

namespace WindowsFormsApplicationTestSocket
{
    public partial class FrmServer : Form
    {
        private TcpServerController _server;
        public FrmServer()
        {
            InitializeComponent();
            this.richTextBox1.ReadOnly = true;
            this.btnSend.Enabled = false;
            _server = new TcpServerController(7788, ClientDataReceivedHandler);
            _server.ClientConnected += ClientConnectedHandler;
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

        void ClientConnectedHandler(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                this.cmbClientList.Items.Add(e.IPEndPoint.ToString());
            }));
        }

        void ClientDataReceivedHandler(object sender, BasicLibrary.DataStructure.SocketMessageEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                var msg = System.Text.Encoding.ASCII.GetString(e.Buffer, 0, e.Size);
                var rm = new ReceivedMessageEntry(msg, e.EndPoint.ToString());
                RecordMessage(rm);
            }));
        }
    }
}
