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
    public partial class FrmSeats : Form
    {
        private Dictionary<int, Button> seats;

        public EventHandler<OccupySeatEventArgs> UserSitdown;
        public FrmSeats()
        {
            InitializeComponent();
            seats = new Dictionary<int, Button>();
            seats.Add(1, btnLeft);
            seats.Add(2, btnRight);
            seats.Add(3, btnBottom);

            this.btnLeft.Click += BtnSeatClick;
            this.btnRight.Click += BtnSeatClick;
            this.btnBottom.Click += BtnSeatClick;
        }

        public void UserSitdownAction(int seatNumber, string userName)
        {
            var button = seats[seatNumber];
            button.Text = userName;
            button.Enabled = false;
        }

        private void BtnSeatClick(object sender, EventArgs e)
        {
            var name = DateTime.Now.ToString("ss");
            var no = Int32.Parse((sender as Button).Tag.ToString());
            UserSitdownAction(no, name);
            (sender as Button).BackColor = Color.Green;
            this.btnLeft.Enabled = this.btnRight.Enabled = this.btnBottom.Enabled = false;
            OnUserSitdown(name, no);
        }

        private void OnUserSitdown(string name, int seatNumber)
        {
            if (UserSitdown != null)
            {
                UserSitdown(null, new OccupySeatEventArgs(name, seatNumber));
            }
        }
    }

}
