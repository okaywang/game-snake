using BasicLibrary.DataStructure;
using LandlordsLibrary.CertificatedForms;
using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
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

        private void RenderCards(List<Card> pokers)
        {
            this.pnoMe.Controls.Clear();
            _selectedCards.Clear();

            var left = 10;
            foreach (var item in pokers)
            {
                var pic = new CardBox();
                pic.CardCode = item.Code;
                pic.Image = Image.FromFile(@"D:\development\mygame\Landlords\LandlordsLibrary\Resources\" + (item.Code + 1) + ".jpg");
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

            var pokes = x.Select(i => CardCarton.Get(i)).ToList();
            pokes.Sort((p1,p2)=>p1.WeightValue - p2.WeightValue);
            var dicts = new Dictionary<int, IEnumerable<ICertification>>();

            dicts.Add(1, new List<ICertification>() { new SoleForm() });
            dicts.Add(2, new List<ICertification>() { new DoubleForm(), new BombKingForm() });
            dicts.Add(3, new List<ICertification>() { new ThreeForm() });
            dicts.Add(4, new List<ICertification>() { new ThreeWithSole(), new BombCivilianForm() });
            dicts.Add(5, new List<ICertification>() { new FlowSingleForm(), new ThreeWithDouble() });
            dicts.Add(6, new List<ICertification>() { new FlowSingleForm(), new FourWithTwoSoleForm(), new FlowPairForm(), new FlowThreeForm() });
            dicts.Add(7, new List<ICertification>() { new FlowSingleForm() });
            dicts.Add(8, new List<ICertification>() { new FlowSingleForm(), new FourWithTwoPair(), new FlowPairForm(), new FlowThreeWithSole() });
            dicts.Add(9, new List<ICertification>() { new FlowSingleForm(), new FlowThreeForm() });
            dicts.Add(10, new List<ICertification>() { new FlowSingleForm(), new FlowPairForm(), new FlowThreeWithPair() });
            dicts.Add(11, new List<ICertification>() { new FlowSingleForm() });
            dicts.Add(12, new List<ICertification>() { new FlowSingleForm(), new FlowPairForm(), new FlowThreeWithSole() });
            //dicts.Add(13, null);
            dicts.Add(14, new List<ICertification>() { new FlowPairForm() });
            dicts.Add(15, new List<ICertification>() { new FlowThreeForm(), new FlowThreeWithPair() });
            dicts.Add(16, new List<ICertification>() { new FlowPairForm(), new FlowThreeWithSole() });
            //dicts.Add(17, null);
            dicts.Add(18, new List<ICertification>() { new FlowPairForm(), new FlowThreeForm() });
            //dicts.Add(19, null);
            dicts.Add(20, new List<ICertification>() { new FlowPairForm(), new FlowThreeWithSole(), new FlowThreeWithPair() });

            if (!dicts.ContainsKey(x.Count))
            {
                MessageBox.Show("invalid");
                return;
            }
            IFormation type = null;
            var certs = dicts[x.Count];
            foreach (var item in certs)
            {
                if (item.IsValid(pokes))
                {
                    type = item.Parse(pokes);
                    break;
                }
            }

            if (type == null)
            {
                MessageBox.Show("invalid");
            }
            else
            {
                MessageBox.Show(type.Name);
            }

        }


    }
}
