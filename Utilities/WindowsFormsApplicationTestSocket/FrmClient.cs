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
        private string _host = "127.0.0.1";
        private int _port = 7788;
        private TcpClientController _client;
        public FrmClient()
        {
            InitializeComponent();
            this.btnSend.Enabled = false;
            this.richTextBox1.ReadOnly = true;
            _client = new TcpClientController(_host, _port);
            _client.ServerDataReceived += ServerDataReceivedHandler;
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
            var sm = new SendingMessageEntry(this.textBox1.Text, _host + ":" + _port);
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

        private void FrmClient_Load(object sender, EventArgs e)
        {

        }
    }
}
