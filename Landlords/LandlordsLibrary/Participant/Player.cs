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
        private bool _isLandlords;

        public Player()
            : this("Anonymity")
        { }
        public Player(string name)
        {
            _name = name;
            _cards = new List<Card>();
        }

        public List<Card> Cards
        {
            get { return _cards; }
            protected set { _cards = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public bool IsLandlords
        {
            get
            {
                return _isLandlords;
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

            _isLandlords = true;
        }

        public bool IsPrepared { get; set; }


        public void ExpelFormation(IFormation formation)
        {
            _cards.RemoveAll(p => formation.Cards.Any(f => f.Code == p.Code));
        }
    }
}
