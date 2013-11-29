using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 贪吃蛇
{
    
    public partial class FormMain : Form
    {
        private Palette p;
        private int speedindex = 0;
         //定义画布大小,每个蛇块的大小
        private int width=15;
        private int height=15;
        private int size=30;
        private bool hasgone = false;//是否开始过游戏。之所以加上这个是因为，如果没有开始过游戏，改变速度会报错
                                      //  因为Palette  的 stop（）方法会释放资源，如果没有开始过游戏，就没有资源释放
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && p.Direction != Direction.Down)
            {
                p.Direction = Direction.Up;
            }
            if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && p.Direction != Direction.Up)
            {
                p.Direction = Direction.Down;
            }
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && p.Direction != Direction.Right)  
            {
                p.Direction = Direction.Left;
            }
            if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && p.Direction != Direction.Left)
            {
                p.Direction = Direction.Right;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
           
        }

        private void 新游戏toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hasgone = true;
            label1.Visible = false;
            //设定游戏窗口大小
            this.pictureBox1.Width = width * size;
            this.pictureBox1.Height = height * size;
            this.Width = pictureBox1.Width + 60;
            this.Height = pictureBox1.Height + 120;

            //定义一个新画布（宽度，高度，单位大小，背景色，绘图句柄，游戏等级)
            p = new Palette(width, height, size, this.pictureBox1.BackColor, Graphics.FromHwnd(this.pictureBox1.Handle), speedindex);

            //游戏开始
            p.start();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 慢ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            width = 15;
            height = 15;
            size = 30;
            慢ToolStripMenuItem1.Checked = true;
            一般ToolStripMenuItem.Checked = false;
            快ToolStripMenuItem.Checked = false;
            speedindex = 0;
            if (hasgone)
            {
                p.Stop();
            }
        }

        private void 一般ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            width = 20;
            height = 20;
            慢ToolStripMenuItem1.Checked = false;
            一般ToolStripMenuItem.Checked = true;
            快ToolStripMenuItem.Checked = false;
            speedindex = 1;
            if (hasgone)
            {
                p.Stop();
            }
        }

        private void 快ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            width = 25;
            height = 20;
            慢ToolStripMenuItem1.Checked = false;
            一般ToolStripMenuItem.Checked = false;
            快ToolStripMenuItem.Checked = true;
            speedindex = 2;
            if (hasgone)
            {
                p.Stop();
            }
        }

        private void 关于贪吃蛇ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("wsad或者方向键控制方向" + "\r\n" +"有3种难度选择", "不要撞墙哦", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }      

    }
}
