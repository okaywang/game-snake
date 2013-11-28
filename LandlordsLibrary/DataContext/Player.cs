using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.DataContext
{
    public class Player : IPlayer
    {
        private string _playName;
        public List<Poker> _pokers;

        public Player(string playName)
        {
            _playName = playName;
            _pokers = new List<Poker>();
        }

        public void ReviewCards()
        {
            _pokers.Sort(new Comparison<Poker>((p1, p2) => LandlordsLibraryRules.Compare_SingleCard(p1, p2)));
        }

        public void DrawPokers(Poker poker)
        {
            _pokers.Add(poker);
        }

        public void DrawPokers(List<Poker> pokers)
        {
            _pokers.AddRange(pokers);
        }

        public void Passby()
        {
            throw new NotImplementedException();
        }

        public void Fight(List<Poker> pokers)
        {
            throw new NotImplementedException();
        }

        public void ActLandlords(List<Poker> pokers)
        {
            throw new NotImplementedException();
        }

        private bool _isBanker;
        public bool IsBanker
        {
            get
            {
                return _isBanker;
            }
            set
            {
                _isBanker = value;
            }
        }

        public string Name
        {
            get { return _playName; }
        }
    }
}
