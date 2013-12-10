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
                _view.UserSitdownAction(msg.Seat.SeatNumber, msg.Seat.UserName);
            }
            else if (msg.MsgType == MessageType.QueryOccupiedSeats)
            {
                var os = msg.OccupiedSeats;
                foreach (var item in os)
                {
                    _view.UserSitdownAction(item.SeatNumber, item.UserName);
                }
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
