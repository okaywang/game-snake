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
        public event EventHandler<GameViewEventArgs> PlayerPrepared;
        public event EventHandler<GameViewEventArgs> PlayerPassby;
        public event EventHandler<GameViewEventArgs> PlayerDesireLandlords;
        public event EventHandler<GameViewEventArgs> PlayerDiscardLandlords;
        public event EventHandler<GameViewTakeoutFormationEventArgs> PlayerTakeoutFormation;
        public event EventHandler<GameViewEventArgs> PlayerActLandlordsTimeout;
        public event EventHandler<GameViewEventArgs> PlayerBringFormationTimeout;
        public event EventHandler<GameViewEventArgs> PlayerFollowFormationTimeout;

        private Action _timeoutAction;
        private RoundInfo _currentRound;
        private Timer _timer;
        private IPlayer _player;
        private IPlayer _playerLeft;
        private IPlayer _playerRight;

        private Label _lblActiveCountDown;

        public LandlordsGameView(IPlayer playerLeft, IPlayer playerCurrent, IPlayer playerRight)
        {
            InitializeComponent();

            _player = playerCurrent;
            _playerLeft = playerLeft;
            _playerRight = playerRight;

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;

            this.lblRightPass.Visible = this.lblLeftPass.Visible = this.lblCurrentState.Visible = false;
        }

        public IPlayer Player
        {
            get { return _player; }
        }
        public IPlayer PlayerLeft
        {
            get { return _playerLeft; }
        }
        public IPlayer PlayerRight
        {
            get { return _playerRight; }
        }
        public void Init()
        {
            this.btnCurrentPrepare.Click += BtnPrepare_Click;

            this.lblCurrentName.Text = _player.Name;
            this.lblLeftName.Text = _playerLeft.Name;
            this.lblRightName.Text = _playerRight.Name;

            this.lblCurrentCountdown.Visible = lblLeftCountdown.Visible = lblRightCountdown.Visible = false;

            this.btnCurrentShout.Click += BtnShout_Click;

            this.btnCurrentShout.Enabled = false;

            this.btnCurrentSilence.Click += BtnSilence_Click;
            this.btnCurrentSilence.Enabled = false;

            this.btnCurrentTakeOut.Click += BtnTakeOut_Click;
            this.btnCurrentTakeOut.Enabled = false;

            this.btnCurrentPassby.Click += PassButton_Click;
            this.btnCurrentPassby.Enabled = false;
        }
        public void RepresentDistributeCards()
        {
            this.pnlCurrent.CardBoxLeftToRight = true;
            this.pnlLeft.CardBoxLeftToRight = false;
            this.pnlRight.CardBoxLeftToRight = false;


            var cards1 = _playerLeft.Cards;
            cards1.Sort((p1, p2) => p2.WeightValue - p1.WeightValue);
            this.pnlLeft.CardBoxes = cards1.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(-1) }).ToList();

            var cards2 = _player.Cards;
            cards2.Sort((p1, p2) => p2.WeightValue - p1.WeightValue);
            this.pnlCurrent.CardBoxes = cards2.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(p.Code) }).ToList();

            var cards3 = _playerRight.Cards;
            cards3.Sort((p1, p2) => p2.WeightValue - p1.WeightValue);
            this.pnlRight.CardBoxes = cards3.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(-1) }).ToList();
        }
        public void ArrangeActLandlordsActionPrelude(IPlayer specifiedPlayer)
        {
            if (specifiedPlayer == this.Player)
            {
                this.btnCurrentShout.Enabled = true;
                this.btnCurrentSilence.Enabled = true;
                StartCountDown(this.lblCurrentCountdown, OnPlayerActLandlordsTimeout);
            }
            else if (specifiedPlayer == this.PlayerLeft)
            {
                StartCountDown(this.lblLeftCountdown);
            }
            else if (specifiedPlayer == this.PlayerRight)
            {
                StartCountDown(this.lblRightCountdown);
            }
        }
        public void DiscardLandlordsAction()
        {
            this.btnCurrentShout.Enabled = false;
            this.btnCurrentSilence.Enabled = false;
            EndCountDown();
        }
        public void ActLandlordsAction()
        {
            EndCountDown();
            OnPlayerDesireLandlords();
        }
        public void ArrangeActLandlordsActionPostlude(IPlayer specifiedPlayer, Card card1, Card card2, Card card3)
        {
            EndCountDown();
            this.pnlCardHome.CardBoxes = new List<CardBox>() {
                new CardBox() { CardCode = card1.Code, ImageLocation = GetImgLocation(card1.Code) },
                new CardBox() { CardCode = card2.Code, ImageLocation = GetImgLocation(card2.Code) },
                new CardBox() { CardCode = card3.Code, ImageLocation = GetImgLocation(card3.Code) },
            };

            var publicCards = new List<Card>() { card1, card2, card3 };

            if (specifiedPlayer == this.Player)
            {
                _player.Cards.AddRange(publicCards);
                _player.Cards.Sort((p1, p2) => p2.WeightValue - p1.WeightValue);
                this.pnlCurrent.CardBoxes = _player.Cards.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(p.Code) }).ToList();
            }
            else if (specifiedPlayer == this.PlayerLeft)
            {
                _playerLeft.Cards.AddRange(publicCards);
                _playerLeft.Cards.Sort((p1, p2) => p2.WeightValue - p1.WeightValue);
                this.pnlLeft.CardBoxes = _playerLeft.Cards.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(-1) }).ToList();
            }
            else
            {
                _playerRight.Cards.AddRange(publicCards);
                _playerRight.Cards.Sort((p1, p2) => p2.WeightValue - p1.WeightValue);
                this.pnlRight.CardBoxes = _playerRight.Cards.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(-1) }).ToList();
            }

        }
        public void ThrowFormationAction(IPlayer specifiedPlayer, IFormation formation)
        {
            EndCountDown();

            if (specifiedPlayer == this.Player)
            {
                this.pnlCurrentDesk.CardBoxes = formation.Cards.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(p.Code) }).ToList();
                this.btnCurrentTakeOut.Enabled = false;
                this.btnCurrentPassby.Enabled = false;
                this.pnlCurrent.RemoveCardBoxes(c => formation.Cards.Any(p => p.Code == c.CardCode));
                this.pnlRightDesk.RemoveCardBoxes(c => true);
                this.lblCurrentState.Hide();
                this.lblRightPass.Hide();
            }
            else if (specifiedPlayer == this.PlayerLeft)
            {
                this.pnlLeftDesk.CardBoxes = formation.Cards.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(p.Code) }).ToList();
                this.pnlCurrentDesk.RemoveCardBoxes(c => true);
                this.lblLeftPass.Hide();
                this.lblCurrentState.Hide();
            }
            else if (specifiedPlayer == this.PlayerRight)
            {
                this.pnlRightDesk.CardBoxes = formation.Cards.Select(p => new CardBox() { CardCode = p.Code, ImageLocation = GetImgLocation(p.Code) }).ToList();
                this.pnlLeftDesk.RemoveCardBoxes(c => true);
                this.lblRightPass.Hide();
                this.lblLeftPass.Hide();
            }
        }
        public void ArrangleBringFormationPrelude(IPlayer specifiedPlayer)
        {
            if (specifiedPlayer == this.Player)
            {
                _currentRound = null;
                StartCountDown(this.lblCurrentCountdown, OnPlayerBringFormationTimeout);
                this.btnCurrentTakeOut.Enabled = true;
            }
            else if (specifiedPlayer == this.PlayerLeft)
            {
                StartCountDown(this.lblLeftCountdown);
            }
            else if (specifiedPlayer == this.PlayerRight)
            {
                StartCountDown(this.lblRightCountdown);
            }
        }
        public void ArrangeFollowFormationPrelude(IPlayer specifiedPlayer, RoundInfo roundInfo)
        {
            EndCountDown();
            if (specifiedPlayer == this.Player)
            {
                _currentRound = roundInfo;
                this.btnCurrentTakeOut.Enabled = true;
                this.btnCurrentPassby.Enabled = true;
                StartCountDown(this.lblCurrentCountdown, OnPlayerFollowFormationTimeout);
            }
            else if (specifiedPlayer == this.PlayerLeft)
            {
                StartCountDown(this.lblLeftCountdown);
            }
            else if (specifiedPlayer == this.PlayerRight)
            {
                StartCountDown(this.lblRightCountdown);
            }
        }
        public void ArrangeFormationRoundPostlude(IPlayer specifiedPlayer)
        {
            //if (player.Value.IsLandlords)
            //{
            //    MessageBox.Show("landlords win");
            //}
            //else
            //{
            //    MessageBox.Show("landlords failed");
            //}
        }
        public void PlayerPassbyAction(IPlayer specifiedPlayer)
        {
            EndCountDown();
            if (specifiedPlayer == this.Player)
            {
                this.btnCurrentTakeOut.Enabled = false;
                this.btnCurrentPassby.Enabled = false;
                this.lblCurrentState.Show();
            }
            else if (specifiedPlayer == this.PlayerLeft)
            {
                this.lblLeftPass.Show();
            }
            else if (specifiedPlayer == this.PlayerRight)
            {
                this.lblRightPass.Show();
            }
        }

        private void BtnSilence_Click(object sender, EventArgs e)
        {
            var player = (sender as Button).Tag as CircularlyLinkedNode<IPlayer>;

            DiscardLandlordsAction();
        }
        private void BtnShout_Click(object sender, EventArgs e)
        {
            this.btnCurrentShout.Enabled = this.btnCurrentSilence.Enabled = false;
            ActLandlordsAction();
        }
        private void PassButton_Click(object sender, EventArgs e)
        {
            OnPlayerPassby();

        }
        private void BtnTakeOut_Click(object sender, EventArgs e)
        {
            var player = (sender as Button).Tag as CircularlyLinkedNode<IPlayer>;
            if (this.pnlCurrent.SelectedCardBoxes.Count == 0)
            {
                MessageBox.Show("Plz select cards");
                return;
            }
            var selectedCards = this.pnlCurrent.SelectedCardBoxes.Select(p => CardCarton.Get(p.CardCode)).ToList();
            selectedCards.Sort((p1, p2) => p1.WeightValue - p2.WeightValue);
            var formation = FormParser.Parse(selectedCards);

            if (formation == null)
            {
                MessageBox.Show("invalid formation");
                return;
            }

            if (_currentRound != null)
            {
                if (formation.Signature != _currentRound.Formation.Signature || formation.Cards.Length != _currentRound.Formation.Cards.Length || formation.Weight < _currentRound.Formation.Weight)
                {
                    MessageBox.Show("violate rules");
                    return;
                }
            }

            OnUserTakeoutFormation(formation);
        }
        private void BtnPrepare_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Enabled = false;
            OnUserPrepared();
        }

        private void OnUserPrepared()
        {
            if (PlayerPrepared != null)
            {
                PlayerPrepared(this, new GameViewEventArgs(this));
            }
        }
        private void OnUserTakeoutFormation(IFormation formation)
        {
            if (PlayerPrepared != null)
            {
                var e = new GameViewTakeoutFormationEventArgs(this, formation);
                PlayerTakeoutFormation(this, e);
            }
        }
        private void OnPlayerDesireLandlords()
        {
            if (PlayerPrepared != null)
            {
                PlayerDesireLandlords(this, new GameViewEventArgs(this));
            }
        }
        private void OnPlayerDiscardLandlords()
        {
            if (PlayerPrepared != null)
            {
                PlayerDiscardLandlords(this, new GameViewEventArgs(this));
            }
        }
        private void OnPlayerPassby()
        {
            if (PlayerPassby != null)
            {
                PlayerPassby(this, new GameViewEventArgs(this));
            }
        }
        private void OnPlayerActLandlordsTimeout()
        {
            if (PlayerActLandlordsTimeout != null)
            {
                PlayerActLandlordsTimeout(this, new GameViewEventArgs(this));
            }
        }
        private void OnPlayerBringFormationTimeout()
        {
            if (PlayerBringFormationTimeout != null)
            {
                PlayerBringFormationTimeout(this, new GameViewEventArgs(this));
            }
        }
        private void OnPlayerFollowFormationTimeout()
        {
            if (PlayerFollowFormationTimeout != null)
            {
                PlayerFollowFormationTimeout(this, new GameViewEventArgs(this));
            }
        }
        private string GetImgLocation(int code)
        {
            return string.Format(@"D:\development\mygame\Landlords\LandlordsLibrary\Resources\{0}.jpg", (code + 1).ToString());
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var seconds = Int32.Parse(_lblActiveCountDown.Text);
            seconds -= 1;
            _lblActiveCountDown.Text = seconds.ToString();
            if (seconds == 0)
            {
                EndCountDown();
                lblCurrentCountdown.Text = "Time out";
                if (_timeoutAction != null)
                {
                    _timeoutAction();
                }
            }
        }
        private void EndCountDown()
        {
            _lblActiveCountDown.Visible = false;
            _timer.Stop();
        }
        private void StartCountDown(Label lblActive, Action timeoutAction)
        {
            _timeoutAction = timeoutAction;
            _lblActiveCountDown = lblActive;

            _lblActiveCountDown.Visible = true;
            _lblActiveCountDown.Text = "20";
            _timer.Start();
        }
        private void StartCountDown(Label lblActive)
        {
            StartCountDown(lblActive, null);
        }
    }
}
