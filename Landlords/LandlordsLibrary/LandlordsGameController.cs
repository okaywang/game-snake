using BasicLibrary.DataStructure;
using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using LandlordsLibrary.Participant;
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
        private ILandlordsGameView _view;
        private Card[] _cards;

        public LandlordsGameController(CircularlyLinkedList<IPlayer> players, ILandlordsGameView view)
        {
            _players = players;
            _cards = new Card[54];

            _view = view; 
        } 

        public void Initiallize()
        {
            _view.Init(_players.Current);
        }

        private void DistributeCards()
        {
            Servant.Shuffle(_cards);
            Servant.DistributeCards(_cards, _players.Current);
            _view.RepresentDistributeCards(_players.Current);
            _view.DesireLandlords(_players.Current);
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
            
            _view.TakeOutCardsCommand(e.Player);
        }

        public void PlayerTakeoutFormationHandler(object sender, PlayerTakeoutFormationEventArgs e)
        {
            e.Player.Value.ExpelFormation(e.Formation);
            RoundRecorder.Add(e.Player.Value, e.Formation);
            _view.FollowCardsCommand(e.Player.Next, RoundRecorder.ImmediateRound);
        }
        public void PlayerPassbyHandler(object sender, PlayerEventArgs e)
        {
            if (e.Player.Next.Value == RoundRecorder.ImmediateRound.Player)
            {
                _view.TakeOutCardsCommand(e.Player.Next);
            }
            else
            {
                _view.FollowCardsCommand(e.Player.Next, RoundRecorder.ImmediateRound);
            }
        }
        public void NoPlayerDesireLandlordsHandler(object sender, EventArgs e)
        {
            DistributeCards();
        }

    }
}
