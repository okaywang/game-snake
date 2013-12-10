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
        private Button _activeButton;
        public EventHandler<UserEventArgs> UserSitdown;
        public FrmSeats()
        {
            InitializeComponent(); 

            this.btnLeft.Click += BtnSeatClick;
            this.btnRight.Click += BtnSeatClick;
            this.btnBottom.Click += BtnSeatClick;
        } 

        public void UserSitdownAction(object posTag, string userName)
        {
            var button = posTag as Button;
            button.Text = userName;
            button.Enabled = false;

            if (button == _activeButton)
            {
                //new FrmClient().Show();
                this.btnLeft.Enabled = this.btnRight.Enabled = this.btnBottom.Enabled = false;
            }
        }

        private void BtnSeatClick(object sender, EventArgs e)
        {
            _activeButton = sender as Button;
            OnUserSitdown(_activeButton, "wgj");
        }

        private void OnUserSitdown(Button btn, string name)
        {
            if (UserSitdown != null)
            {
                UserSitdown(btn, new UserEventArgs(name));
            }
        }
    }

}
