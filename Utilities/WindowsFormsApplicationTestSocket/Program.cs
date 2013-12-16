using BasicLibrary.DataStructure;
using CommunicationTcpClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplicationTestSocketLibrary;

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
            var frmClient = new FrmClient();
            var controller = new SeatController(frmSeat, frmClient);
            frmSeat.UserSitdown += controller.UserSitdownHandler;
            frmSeat.UserLeave += controller.UserLeaveHandler;
            frmClient.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                frmSeat.OnUserLeave();
            };
            Application.Run(frmSeat);
        }
    }

    public class SeatController
    {
        private string host = "127.0.0.1";
        private int port = 7788;
        private TcpClientController _client;
        private FrmSeats _viewSeat;
        private FrmClient _viewClient;
        public SeatController(FrmSeats view, FrmClient viewClient)
        {
            _viewSeat = view;
            _viewClient = viewClient;
            _client = new TcpClientController(host, port);
            _client.Connect();
            _client.ServerDataReceived += ServerDataReceivedHandler;

            QueryOccupiedSeats();
        }

        private void QueryOccupiedSeats()
        {
            var msg = new MessageConvention();
            msg.MsgType = MessageType.QueryOccupiedSeats;
            var bytes = MyHelper.BinarySerializeObject<MessageConvention>(msg);
            _client.Send(bytes);
        }

        private void ServerDataReceivedHandler(object sender, SocketMessageEventArgs e)
        {
            var msg = MyHelper.BinaryDeserializeObject<MessageConvention>(e.Buffer);

            if (msg.MsgType == MessageType.OccupySeat)
            {
                _viewSeat.UserSitdownAction(msg.Seat.SeatNumber, msg.Seat.UserName);
            }
            else if (msg.MsgType == MessageType.QueryOccupiedSeats)
            {
                var os = msg.OccupiedSeats;
                foreach (var item in os)
                {
                    _viewSeat.UserSitdownAction(item.SeatNumber, item.UserName);
                }
            }
            else if (msg.MsgType == MessageType.UserLeave)
            {
                _viewSeat.UserStandupAction(msg.Seat.SeatNumber, msg.Seat.UserName);
            }
        }

        public void UserSitdownHandler(object sender, OccupySeatEventArgs e)
        {
            var msg = new MessageConvention();
            msg.MsgType = MessageType.OccupySeat;
            msg.Seat = new Seat()
            {
                UserName = e.UserName,
                SeatNumber = e.SeatNumber
            };
            var bytes = MyHelper.BinarySerializeObject<MessageConvention>(msg);
            _client.Send(bytes);

            _viewClient.Show();
        }

        public void UserLeaveHandler(object sender, EventArgs e)
        {
            _client.Disconnect();
        }
    }


    public class OccupySeatEventArgs : EventArgs
    {
        private string _userName;
        private int _seatNumber;
        public OccupySeatEventArgs(string username, int seatNumber)
        {
            _userName = username;
            _seatNumber = seatNumber;
        }
        public string UserName
        {
            get
            { return _userName; }
        }
        public int SeatNumber
        {
            get
            { return _seatNumber; }
        }
    }

}
