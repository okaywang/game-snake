using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormGreedySnake
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pl = new WinFormControls.GridPanel();
            pl.Size = new Size(100, 100);
            this.Controls.Add(pl);
        }
    }
}
