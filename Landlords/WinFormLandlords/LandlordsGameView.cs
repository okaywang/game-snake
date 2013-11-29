using BasicLibrary.DataStructure;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormControls;

namespace WinFormLandlords
{
    public partial class LandlordsGameView : Form
    {
        private List<int> _selectedCards;
        public LandlordsGameView()
        {
            InitializeComponent();
            _selectedCards = new List<int>();
        }

        private void btnPrepare_Click(object sender, EventArgs e)
        {
            var p1 = new Player("张衡");
            var p2 = new Player("刘志伟");
            var p3 = new Player("王国君");
            var players = new CircularlyLinkedList<IPlayer>(p1, p2, p3);

            var referee = new Referee(players);
            referee.Shuffle();
            referee.DistributeCards();

            p1.ReviewCards();
            p2.ReviewCards();
            p3.ReviewCards();

            RenderCards(p1._pokers);
        }

        private void RenderCards(List<Poker> pokers)
        {
            var left = 10;
            foreach (var item in pokers)
            {
                var pic = new CardBox();
                pic.CardCode = item.Code;
                pic.Image = Image.FromFile(@"D:\test2\MyGame\game-snake\LandlordsLibrary\Resources\" + (item.Code + 1) + ".jpg");
                pic.Click += pic_Click;
                pic.DragOver += pic_DragOver;
                pic.Top = 20;
                pic.Left = left;
                pic.Width = 105;
                pic.Height = 150;
                this.pnoMe.Controls.Add(pic);
                pic.BringToFront();
                left += 25;
            }
        }

        void pic_DragOver(object sender, DragEventArgs e)
        {
            pic_Click(sender, null);
        }

        void pic_Click(object sender, EventArgs e)
        {
            var pic = sender as CardBox;
            pic.IsSelected = !pic.IsSelected;
            if (pic.IsSelected)
            { 
                pic.Top -= 20;
                _selectedCards.Add(pic.CardCode);
            }
            else
            {
                pic.Top += 20;
                _selectedCards.Remove(pic.CardCode);
            }
        }

        private void btnTakeOut_Click(object sender, EventArgs e)
        {
            var x = _selectedCards;


        }
    }
}
