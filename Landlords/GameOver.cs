using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 斗地主
{
    public partial class GameOver : Form
    {
        public GameOver(string[] name,int[] score)
        {
            InitializeComponent();
            this.label1.Text = name[0];
            this.label2.Text = name[1];
            this.label3.Text = name[2];
            this.label4.Text = score[0]+"";
            this.label5.Text = score[1]+"";
            this.label6.Text = score[2]+"";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}