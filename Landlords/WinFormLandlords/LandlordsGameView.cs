using BasicLibrary.DataStructure;
using LandlordsLibrary;
using LandlordsLibrary.CertificatedForms;
using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using LandlordsLibrary.Participant;
using LandlordsLibrary.Participant.Robot;
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
    public partial class LandlordsGameView : Form, ILandlordsGameView
    {

        public EventHandler<PlayerEventArgs> UserPrepared;
        public EventHandler<PlayerEventArgs> PlayerPassby;
        public EventHandler<PlayerEventArgs> PlayerCardGone;
        //public EventHandler<PlayerTakeoutFormationEventArgs> PlayerFollowed;
        public EventHandler<PlayerEventArgs> PlayerDesireLandlords;
        public EventHandler NoPlayerDesireLandlords;
        public EventHandler<PlayerTakeoutFormationEventArgs> PlayerTakeoutFormation;

        private Dictionary<CircularlyLinkedNode<IPlayer>, PlayerControl> _playerControls;
        private CircularlyLinkedNode<IPlayer> _headPlayer;

        private RoundInfo _currentRound;
        public LandlordsGameView()
        {
            InitializeComponent();
        }

        public void Init(CircularlyLinkedNode<IPlayer> currentPlayer)
        {
            _headPlayer = currentPlayer;
            _playerControls = new Dictionary<CircularlyLinkedNode<IPlayer>, PlayerControl>();
            _playerControls.Add(currentPlayer, new PlayerControl()
            {
                PrepareButton = this.btnCurrentPrepare,
                ShoutButton = this.btnCurrentShout,
                SilenceButton = this.btnCurrentSilence,
                TakeOutButton = this.btnCurrentTakeOut,
                PassButton = this.btnCurrentPassby,
                CardBoxContainer = this.pnlCurrent,
                LblName = this.lblCurrentName,
            });
            _playerControls.Add(currentPlayer.Previous, new PlayerControl()
            {
                PrepareButton = this.btnLeftPrepare,
                ShoutButton = this.btnLeftShout,
                SilenceButton = this.btnLeftSilence,
                TakeOutButton = this.btnLeftTakeOut,
                PassButton = this.btnLeftPass,
                CardBoxContainer = this.pnlLeft,
                LblName = this.lblLeftName
            });
            _playerControls.Add(currentPlayer.Next, new PlayerControl()
            {
                PrepareButton = this.btnRightPrepare,
                ShoutButton = this.btnRightShout,
                SilenceButton = this.btnRightSilence,
                TakeOutButton = this.btnRightTakeOut,
                PassButton = this.btnRightPassby,
                CardBoxContainer = this.pnlRight,
                LblName = this.lblRightName
            });
            InitPlayerControls();
        }

        private void InitPlayerControls()
        {
            foreach (var item in _playerControls)
            {
                item.Value.PrepareButton.Click += BtnPrepare_Click;
                item.Value.PrepareButton.Tag = item.Key;
                //item.Value.PrepareButton.Enabled = false;
                item.Value.LblName.Text = item.Key.Value.Name;

                item.Value.ShoutButton.Click += BtnShout_Click;
                item.Value.ShoutButton.Tag = item.Key;
                item.Value.ShoutButton.Enabled = false;

                item.Value.SilenceButton.Click += BtnSilence_Click;
                item.Value.SilenceButton.Tag = item.Key;
                item.Value.SilenceButton.Enabled = false;

                item.Value.TakeOutButton.Click += BtnTakeOut_Click;
                item.Value.TakeOutButton.Tag = item.Key;
                item.Value.TakeOutButton.Enabled = false;

                item.Value.PassButton.Click += PassButton_Click;
                item.Value.PassButton.Tag = item.Key;
                item.Value.PassButton.Enabled = false;

                item.Value.LblName.Text = item.Key.Value.Name;
            }
        }


        private void BtnSilence_Click(object sender, EventArgs e)
        {
            var player = (sender as Button).Tag as CircularlyLinkedNode<IPlayer>;

            _playerControls[player].ShoutButton.Enabled = false;
            _playerControls[player].SilenceButton.Enabled = false;

            if (player == _headPlayer.Previous)
            {
                OnNoPlayerDesireLandlords();
                return;
            }
            _playerControls[player.Next].ShoutButton.Enabled = true;
            _playerControls[player.Next].SilenceButton.Enabled = true;
        }

        private void BtnShout_Click(object sender, EventArgs e)
        {
            var player = (sender as Button).Tag as CircularlyLinkedNode<IPlayer>;
            _playerControls[player].ShoutButton.Enabled = _playerControls[player].SilenceButton.Enabled = false;
            OnPlayerDesireLandlords(player);
        }

        public void RepresentDistributeCards(CircularlyLinkedNode<IPlayer> currentPlayer)
        {
            _playerControls[currentPlayer].CardBoxContainer.CardBoxLeftToRight = true;
            _playerControls[currentPlayer.Previous].CardBoxContainer.CardBoxLeftToRight = false;
            _playerControls[currentPlayer.Next].CardBoxContainer.CardBoxLeftToRight = false;

            var cards1 = currentPlayer.Previous.Value.Cards;
            cards1.Sort((p1, p2) => p2.WeightValue - p1.WeightValue);
            this.pnlLeft.CardBoxes = cards1.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(p.Code) }).ToList();

            var cards2 = currentPlayer.Value.Cards;
            cards2.Sort((p1, p2) => p2.WeightValue - p1.WeightValue);
            this.pnlCurrent.CardBoxes = cards2.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(p.Code) }).ToList();

            var cards3 = currentPlayer.Next.Value.Cards;
            cards3.Sort((p1, p2) => p2.WeightValue - p1.WeightValue);
            this.pnlRight.CardBoxes = cards3.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(p.Code) }).ToList();
        }

        public void DesireLandlords(CircularlyLinkedNode<IPlayer> player)
        {
            this.btnCurrentShout.Enabled = this.btnCurrentSilence.Enabled = true;
        }

        public void TakeOutCardsCommand(CircularlyLinkedNode<IPlayer> player)
        {
            _currentRound = null;
            if (player.Value is IRobot)
            {
                var robot = player.Value as  IRobot;
                var formation = robot.TakeOut();
                TakeOutFormation(player, formation);
            }
            else
            {
                _playerControls[player].TakeOutButton.Enabled = true;
            }
        }

        public void FollowCardsCommand(CircularlyLinkedNode<IPlayer> player, RoundInfo roundInfo)
        {
            _currentRound = roundInfo;
            if (player.Value is IRobot)
            {
                var robot = player.Value as IRobot;
                var formation = robot.Follow(roundInfo);
                if (formation !=null)
                {
                    TakeOutFormation(player, formation);
                }
                else
                {
                    OnPlayerPassby(player);
                }
            }
            else
            { 
                _playerControls[player].TakeOutButton.Enabled = true;
                _playerControls[player].PassButton.Enabled = true;
            }
        }

        public void RepresentLandlords(CircularlyLinkedNode<IPlayer> player)
        {
            var cards1 = player.Value.Cards;
            cards1.Sort((p1, p2) => p2.WeightValue - p1.WeightValue);
            _playerControls[player].CardBoxContainer.CardBoxes = cards1.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(p.Code) }).ToList();
        }

        public void PlayerGone(CircularlyLinkedNode<IPlayer> player)
        {
            if (player.Value.IsLandlords)
            {
                MessageBox.Show("landlords win");
            }
            else
            {
                MessageBox.Show("landlords failed");
            }
        }


        private void PassButton_Click(object sender, EventArgs e)
        {
            var player = (sender as Button).Tag as CircularlyLinkedNode<IPlayer>;
            _playerControls[player].TakeOutButton.Enabled = false;
            _playerControls[player].PassButton.Enabled = false;
            OnPlayerPassby(player);
        }

        private void BtnTakeOut_Click(object sender, EventArgs e)
        {
            var player = (sender as Button).Tag as CircularlyLinkedNode<IPlayer>;
            if (_playerControls[player].CardBoxContainer.SelectedCardBoxes.Count == 0)
            {
                MessageBox.Show("Plz select cards");
                return;
            }
            var selectedCards = _playerControls[player].CardBoxContainer.SelectedCardBoxes.Select(p => CardCarton.Get(p.CardCode)).ToList();
            selectedCards.Sort((p1, p2) => p1.WeightValue - p2.WeightValue);
            var formation = FormParser.Parse(selectedCards);

            if (formation == null)
            {
                MessageBox.Show("invalid formation");
                return;
            }

            TakeOutFormation(player, formation);
        }

        private void TakeOutFormation(CircularlyLinkedNode<IPlayer> player, IFormation formation)
        {
            if (_currentRound != null)
            {
                if (formation.Signature != _currentRound.Formation.Signature
                || formation.Cards.Length != _currentRound.Formation.Cards.Length
                    || formation.Weight < _currentRound.Formation.Weight)
                {
                    MessageBox.Show("violate rules");
                    return;
                }
            }
            this.pnlDesk.CardBoxes = formation.Cards.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(p.Code) }).ToList();
            _playerControls[player].TakeOutButton.Enabled = false;
            _playerControls[player].PassButton.Enabled = false;
            //_playerControls[player].CardBoxContainer.RemoveSelectedCardBoxes();
            _playerControls[player].CardBoxContainer.RemoveCardBoxes(c => formation.Cards.Any(p => p.Code == c.CardCode));

            OnUserTakeoutFormation(player, formation);
        }

        private void BtnPrepare_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Enabled = false;
            OnUserPrepared(btn.Tag as CircularlyLinkedNode<IPlayer>);
        }

        private void OnUserPrepared(CircularlyLinkedNode<IPlayer> player)
        {
            if (UserPrepared != null)
            {
                UserPrepared(this, new PlayerEventArgs(player));
            }
        }
        private void OnUserTakeoutFormation(CircularlyLinkedNode<IPlayer> player, IFormation formation)
        {
            if (UserPrepared != null)
            {
                PlayerTakeoutFormation(this, new PlayerTakeoutFormationEventArgs(player, formation));
            }
        }
        private void OnPlayerDesireLandlords(CircularlyLinkedNode<IPlayer> player)
        {
            if (UserPrepared != null)
            {
                PlayerDesireLandlords(this, new PlayerEventArgs(player));
            }
        }
        private void OnNoPlayerDesireLandlords()
        {
            if (UserPrepared != null)
            {
                NoPlayerDesireLandlords(this, EventArgs.Empty);
            }
        }

        private void OnPlayerPassby(CircularlyLinkedNode<IPlayer> player)
        {
            if (PlayerPassby != null)
            {
                PlayerPassby(this, new PlayerEventArgs(player));
            }
        }


        //private void OnPlayerFollowed(CircularlyLinkedNode<IPlayer> player, IFormation formation)
        //{
        //    if (PlayerFollowed != null)
        //    {
        //        PlayerFollowed(this, new PlayerTakeoutFormationEventArgs(player, formation));
        //    }
        //}

        class PlayerControl
        {
            public Button PrepareButton { get; set; }
            public Button ShoutButton { get; set; }
            public Button SilenceButton { get; set; }
            public Button TipButton { get; set; }
            public Button TakeOutButton { get; set; }
            public Button PassButton { get; set; }
            public CardBoxContainer CardBoxContainer { get; set; }
            public Label LblName { get; set; }
        }


        private string GetImgLocation(int code)
        {
            return string.Format(@"D:\development\mygame\Landlords\LandlordsLibrary\Resources\{0}.jpg", (code + 1).ToString());
        }

    }
}
