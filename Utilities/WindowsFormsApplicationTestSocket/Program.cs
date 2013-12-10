using CommunicationTcpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationTestSocket
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             
            var frmSeat = new FrmSeats();
            var controller = new SeatController(frmSeat);
            frmSeat.UserSitdown += controller.UserSitdownHandler;
            frmSeat.Show();

            Application.Run(); 
        }
    }

    public class SeatController
    {
        private string host = "127.0.0.1";
        private int port = 7788;
        private TcpClientController _client;
        private FrmSeats _view;
        public SeatController(FrmSeats view)
        {
            _view = view;
            _client = new TcpClientController(host, port);
            _client.Connect();
        }

        public void UserSitdownHandler(object sender, UserEventArgs e)
        {
            _view.UserSitdownAction(sender, e.UserName);
        }

    }


    public class UserEventArgs : EventArgs
    {
        private string _userName;
        public UserEventArgs(string username)
        {
            _userName = username;
        }
        public string UserName
        {
            get
            { return _userName; }
        }
    }
}
