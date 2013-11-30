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
        public List<Card> _pokers;

        public Player(string playName)
        {
            _playName = playName;
            _pokers = new List<Card>();
        }

        public void ReviewCards()
        {
            _pokers.Sort(new Comparison<Card>((p1, p2) => LandlordsLibraryRules.Compare_SingleCard(p1, p2)));
        }

        public void DrawPokers(Card poker)
        {
            _pokers.Add(poker);
        }

        public void DrawPokers(List<Card> pokers)
        {
            _pokers.AddRange(pokers);
        }

        public void Passby()
        {
            throw new NotImplementedException();
        }

        public void Fight(List<Card> pokers)
        {
            throw new NotImplementedException();
        }

        public void ActLandlords(List<Card> pokers)
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
