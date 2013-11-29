using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace 斗地主
{
    public partial class Form3 : Form
    {
       
        public Form3()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        const int AW_HOR_POSITIVE = 0x0001;
        const int AW_HOR_NEGATIVE = 0x0002;
        const int AW_VER_POSITIVE = 0x0004;
        const int AW_VER_NEGATIVE = 0x0008;
        const int AW_CENTER = 0x0010;
        const int AW_HIDE = 0x10000;
        const int AW_ACTIVATE = 0x20000;//5%1%a%s%p%x
        const int AW_SLIDE = 0x40000;
        const int AW_BLEND = 0x80000;		
        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath MYPATH = new GraphicsPath();
            // 将椭圆添加到路径对象中
            MYPATH.AddEllipse(20, 30, this.Width - 30, this.Height - 40);
            //使用韩国椭圆构造一个区域,并将此区域作为程序窗体区域
            this.Region = new Region(MYPATH);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 3000, AW_CENTER | AW_ACTIVATE);
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {

            //屏掉alt+f4  

            if ((e.KeyCode == Keys.F4) && (e.Alt == true))
            {

                e.Handled = true;

            }  
        }
        
    }
}