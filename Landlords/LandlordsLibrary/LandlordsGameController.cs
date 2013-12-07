using BasicLibrary.DataStructure;
using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using LandlordsLibrary.Participant;
using LandlordsLibrary.Participant.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary
{
    public class LandlordsGameController
    {
        private CircularlyLinkedNode<IPlayer> _landlords;
        private CircularlyLinkedNode<ILandlordsGameView> _bankerView;
        private CircularlyLinkedList<ILandlordsGameView> _views;
        private Card[] _cards;

        public LandlordsGameController(CircularlyLinkedList<ILandlordsGameView> views)
        {
            _bankerView = views.Current;
            _cards = new Card[54];

            _views = views;
        }

        public void Initiallize()
        {
            _views.Each(v => v.Value.Init());
        }

        private void DistributeCards()
        {
            Servant.Shuffle(_cards);
            Servant.DistributeCards(_cards, _bankerView);
            _views.Each(v => v.Value.RepresentDistributeCards());
            _views.Each(v => v.Value.ArrangeActLandlordsActionPrelude(_views.Current.Value.Player));
        }

        public void PlayerPreparedHandler(object sender, GameViewEventArgs e)
        {
            e.View.Player.IsPrepared = true;
            if (_views[e.View].Previous.Value.Player.IsPrepared && _views[e.View].Next.Value.Player.IsPrepared)
            {
                DistributeCards();
            }
        }
        public void PlayerDesireLandlordsHandler(object sender, GameViewEventArgs e)
        {
            e.View.Player.GainBonus(_cards[51], _cards[52], _cards[53]);

            _views.Each(v => v.Value.ArrangeActLandlordsActionPostlude(e.View.Player, _cards[51], _cards[52], _cards[53]));
            _views.Each(v => v.Value.ArrangleBringFormationPrelude(e.View.Player));
        }

        public void PlayerTakeoutFormationHandler(object sender, GameViewTakeoutFormationEventArgs e)
        {
            e.View.Player.ExpelFormation(e.Formation);
            _views.Each(v => v.Value.ThrowFormationAction(e.View.Player, e.Formation));

            var round = new RoundInfo(e.View.Player, e.Formation);
            RoundRecorder.Add(round);
            if (e.View.Player.Cards.Count == 0)
            {
                _views.Each(v => v.Value.ArrangeFormationRoundPostlude(e.View.Player));
            }
            else
            {
                var nextView = _views[e.View].Next.Value;
                if (nextView.Player is IRobot)
                {
                    var robot = nextView.Player as IRobot;
                    var formation = robot.FollowFormation(round);
                    if (formation == null)
                    {
                        _views.Each(v => v.Value.PlayerPassbyAction(nextView.Player));
                    }
                    else
                    {
                        _views.Each(v => v.Value.ThrowFormationAction(nextView.Player, formation));
                    }
                }
                else
                {
                    _views.Each(v => v.Value.ArrangeFollowFormationPrelude(nextView.Player, RoundRecorder.ImmediateRound));
                }
            }
        }
        public void PlayerPassbyHandler(object sender, GameViewEventArgs e)
        {
            var nextView = _views[e.View].Next.Value;
            _views.Each(v => v.Value.PlayerPassbyAction(e.View.Player));

            if (nextView.Player == RoundRecorder.ImmediateRound.Player)
            {
                if (nextView.Player is IRobot)
                {
                    _views.Each(v => v.Value.ThrowFormationAction(nextView.Player, (nextView.Player as IRobot).BringFormation()));
                }
                else
                {
                    _views.Each(v => v.Value.ArrangleBringFormationPrelude(nextView.Player));
                }
            }
            else
            {
                if (nextView.Player is IRobot)
                {
                    var robot = nextView.Player as IRobot;
                    var formation = robot.FollowFormation(RoundRecorder.ImmediateRound);
                    if (formation == null)
                    {
                        _views.Each(v => v.Value.PlayerPassbyAction(nextView.Player));
                    }
                    else
                    {
                        _views.Each(v => v.Value.ThrowFormationAction(nextView.Player, formation));
                    }
                }
                else
                {

                    _views.Each(v => v.Value.ArrangeFollowFormationPrelude(nextView.Player, RoundRecorder.ImmediateRound));
                }
            }
        }
        public void PlayerActLandlordsTimeoutHandler(object sender, GameViewEventArgs e)
        {
            e.View.DiscardLandlordsAction();
            var nextView = _views[e.View].Next.Value;
            if (nextView.Player is IRobot)
            {
                nextView.ActLandlordsAction();
            }
            else
            {
                _views.Each(v => v.Value.ArrangeActLandlordsActionPrelude(_views.Current.Next.Value.Player));
            }
        }
        public void PlayerBringFormationTimeoutHandler(object sender, GameViewEventArgs e)
        {
            _views.Each(v => v.Value.ThrowFormationAction(e.View.Player, RobotJunior.BringFormation(e.View.Player.Cards)));
        }
        public void PlayerFollowFormationTimeoutHandler(object sender, GameViewEventArgs e)
        {
            _views.Each(v => v.Value.PlayerPassbyAction(e.View.Player));
        }

        public void PlayerDiscardLandlordsHandler(object sender, GameViewEventArgs e)
        {
            if (e.View == _bankerView)
            {
                DistributeCards();
            }
            else
            {
                _views.Each(v => v.Value.ArrangeActLandlordsActionPrelude(_views.Current.Value.Player));
            }
        }

    }
}
