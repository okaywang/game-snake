using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 斗地主
{
    public partial class YiChuPai : Form
    {
        
        public YiChuPai(string[] nickName,List<Image> list1, List<Image> list2,List<Image> list3)
        {
            InitializeComponent();
            showImageBox(nickName,list1, list2, list3);
        }

        private void showImageBox(string[] nickName, List<Image> list1, List<Image> list2, List<Image> list3)
        {
            this.label1.Text = nickName[0];
            this.label2.Text = nickName[1];
            this.label3.Text = nickName[2];
            PictureBox[] pic1 = new PictureBox[20];
            PictureBox[] pic2 = new PictureBox[20];
            PictureBox[] pic3 = new PictureBox[20];
            int a = list1.Count * 12 + 85;
            for (int i = list1.Count-1; i >= 0; i--)
            {
                pic1[i] = new PictureBox();
                pic1[i].SetBounds(a, 15, 60, 90);
                pic1[i].BackgroundImage = list1[i];
                pic1[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.Controls.Add(pic1[i]);
                a -= 12;
            }
            a = list2.Count * 12 + 85;
            for (int i = list2.Count - 1; i >= 0; i--)
            {
                pic2[i] = new PictureBox();
                pic2[i].SetBounds(a, 110, 60, 90);//5~1-a-s-p-x
                pic2[i].BackgroundImage = list2[i];
                pic2[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.Controls.Add(pic2[i]);
                a -= 12;
            }
            a = list3.Count * 12 + 85;
            for (int i = list3.Count - 1; i >= 0; i--)
            {
                pic3[i] = new PictureBox();
                pic3[i].SetBounds(a, 205, 60, 90);
                pic3[i].BackgroundImage = list3[i];
                pic3[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.Controls.Add(pic3[i]);
                a -= 12;
            }
        }

    }
}