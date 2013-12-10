using BasicLibrary.DataStructure;
using CommunicationTcpClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationTestSocket
{
    public partial class FrmClient : Form
    {
        private TcpClientController _client;
        public FrmClient(TcpClientController client)
        {
            InitializeComponent();
            _client = client;
            _client.ServerDataReceived += ServerDataReceivedHandler;
            this.btnSend.Enabled = false;
            this.richTextBox1.ReadOnly = true;
        }

        private void ServerDataReceivedHandler(object sender, SocketMessageEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                var msg = System.Text.Encoding.ASCII.GetString(e.Buffer, 0, e.Size);
                var rm = new ReceivedMessageEntry(msg, e.EndPoint.ToString());
                RecordMessage(rm);
            }));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var sm = new SendingMessageEntry(this.textBox1.Text, _client.LocalEndPoint.ToString());
            _client.Send(System.Text.Encoding.ASCII.GetBytes(sm.Message));
            RecordMessage(sm);
        }

        private void RecordMessage(MessageEntry me)
        {
            this.richTextBox1.AppendText(me.ToString());
            this.richTextBox1.AppendText("\n\n");

            this.textBox1.ResetText();
            this.textBox1.Focus();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            _client.Connect();
            this.btnSend.Enabled = true;
            this.btnJoin.Enabled = false;
        }

        private void FrmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Disconnect();
        }
    }
}
