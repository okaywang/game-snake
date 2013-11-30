using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Participant
{
    public class Player : IPlayer
    {
        private string _name;
        private List<Card> _cards;
        private IFormation _feedback;
        private bool _isBanker;

        public Player(string name)
        {
            _name = name;
            _cards = new List<Card>();
        }

        public List<Card> Cards
        {
            get { return _cards; }
        }

        public string Name
        {
            get { return _name; }
        }

        public bool IsBanker
        {
            get
            {
                return _isBanker;
            }
        }

        public void DrawCard(Card card)
        {
            _cards.Add(card);
        }

        public void DrawCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        public void GainBonus(Card card1, Card card2, Card card3)
        {
            _cards.Add(card1);
            _cards.Add(card2);
            _cards.Add(card3);

            _isBanker = true;
        }

        public void TakeOff(IFormation set)
        {
            _cards.RemoveAll(c => set.Cards.Any(s => s.Code == c.Code));
        }

        public IFormation NewRound_TakeOut()
        {
            IFormation formation = null;
            while (formation == null)
            {
                formation = _feedback;
            }

            _feedback = null;
            _cards.RemoveAll(c => formation.Cards.Any(s => s.Code == c.Code));
            return formation;
        }

        public IFormation Track(IFormation cards, IPlayer player)
        {
            IFormation formation = null;
            while (formation == null)
            {
                formation = _feedback;
            }

            _feedback = null;
            _cards.RemoveAll(c => formation.Cards.Any(s => s.Code == c.Code));
            return formation;
        }

        public void Passby()
        {
            throw new NotImplementedException();
        }

        public bool ActAsLandlords()
        {
            return true;
        }

        public void Review()
        {
        }

        public void SetFeedback(IFormation feedback)
        {
            _feedback = feedback;
        }

        public bool IsPrepared { get; set; }



        public void ExpelFormation(IFormation formation)
        {
            _cards.RemoveAll(p => formation.Cards.Any(f => f.Code == p.Code));
        }
    }
}
