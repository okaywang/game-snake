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
        private CircularlyLinkedList<IPlayer> _players;
        private CircularlyLinkedNode<IPlayer> _landlords;
        private CircularlyLinkedNode<IPlayer> _banker;
        private ILandlordsGameView _view;
        private Card[] _cards;

        public LandlordsGameController(CircularlyLinkedList<IPlayer> players, ILandlordsGameView view)
        {
            _players = players;
            _banker = _players.Current;
            _cards = new Card[54];

            _view = view;
        }

        public void Initiallize()
        {
            _view.Init(_banker);
        }

        private void DistributeCards()
        {
            Servant.Shuffle(_cards);
            Servant.DistributeCards(_cards, _banker);
            _view.RepresentDistributeCards(_banker);
            _view.ArrangeActLandlordsActionPrelude(_banker);
        }

        public void UserPreparedHandler(object sender, PlayerEventArgs e)
        {
            e.Player.Value.IsPrepared = true;
            if (e.Player.Previous.Value.IsPrepared && e.Player.Next.Value.IsPrepared)
            {
                DistributeCards();
            }
        }
        public void PlayerDesireLandlordsHandler(object sender, PlayerEventArgs e)
        {
            e.Player.Value.GainBonus(_cards[51], _cards[52], _cards[53]);
            _view.ArrangeActLandlordsActionPostlude(e.Player, _cards[51], _cards[52], _cards[53]);
            _view.ArrangleBringFormationPrelude(e.Player);
        }

        public void PlayerTakeoutFormationHandler(object sender, PlayerTakeoutFormationEventArgs e)
        {
            e.Player.Value.ExpelFormation(e.Formation);
            var round = new RoundInfo(e.Player.Value, e.Formation);
            RoundRecorder.Add(round);
            if (e.Player.Value.Cards.Count == 0)
            {
                _view.ArrangeFormationRoundPostlude(e.Player);
            }
            else
            {
                if (e.Player.Next.Value is IRobot)
                {
                    var robot = e.Player.Next.Value as IRobot;
                    var formation = robot.FollowFormation(round);
                    if (formation == null)
                    {
                        _view.PlayerPassbyAction(e.Player.Next);
                    }
                    else
                    {
                        _view.ThrowSelectedFormationAction(e.Player.Next, formation);
                    }
                }
                else
                {
                    _view.ArrangeFollowFormationPrelude(e.Player.Next, RoundRecorder.ImmediateRound);
                }
            }
        }
        public void PlayerPassbyHandler(object sender, PlayerEventArgs e)
        {
            if (e.Player.Next.Value == RoundRecorder.ImmediateRound.Player)
            {
                if (e.Player.Next.Value is IRobot)
                {
                    _view.ThrowSelectedFormationAction(e.Player.Next, (e.Player.Next.Value as IRobot).BringFormation());
                }
                else
                {
                    _view.ArrangleBringFormationPrelude(e.Player.Next);
                }
            }
            else
            {
                if (e.Player.Next.Value is IRobot)
                {
                    var robot = e.Player.Next.Value as IRobot;
                    var formation = robot.FollowFormation(RoundRecorder.ImmediateRound);
                    if (formation == null)
                    {
                        _view.PlayerPassbyAction(e.Player.Next);
                    }
                    else
                    {
                        _view.ThrowSelectedFormationAction(e.Player.Next, formation);
                    }
                }
                else
                {

                    _view.ArrangeFollowFormationPrelude(e.Player.Next, RoundRecorder.ImmediateRound);
                }
            }
        }
        public void PlayerActLandlordsTimeoutHandler(object sender, PlayerEventArgs e)
        {
            _view.DiscardLandlordsAction(e.Player);
            if (e.Player.Next.Value is IRobot)
            {
                _view.ActLandlordsAction(e.Player.Next);
            }
            else
            {
                _view.ArrangeActLandlordsActionPrelude(e.Player.Next);
            }
        }
        public void PlayerBringFormationTimeoutHandler(object sender, PlayerEventArgs e)
        {
            _view.ThrowSelectedFormationAction(e.Player, RobotJunior.BringFormation(e.Player.Value.Cards));
        }
        public void PlayerFollowFormationTimeoutHandler(object sender, PlayerEventArgs e)
        {
            _view.PlayerPassbyAction(e.Player);
        }

        public void PlayerDiscardLandlordsHandler(object sender, PlayerEventArgs e)
        {
            if (e.Player == _banker)
            {
                DistributeCards();
            }
            else
            {
                _view.ArrangeActLandlordsActionPrelude(_banker);
            }
        }

    }
}
