using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationPair : IFormation, IComparable<FormationPair>, IAppendix
    {
        private Card[] _cards;

        public FormationPair(Card card1, Card card2)
            : this(new Card[] { card1, card2 })
        {

        }

        public FormationPair(Card[] cards)
        {
            Guard.ArrayLengthEqual(cards, 2);
            Guard.IsEqual(cards[0].WeightValue, cards[1].WeightValue);

            _cards = cards;
        }
         
        public Card[] Cards
        {
            get { return _cards; }
        }

        public int Weight
        {
            get { return _cards[0].WeightValue; }
        }

        public string Signature
        {
            get { return "对子"; }
        }

        public int CompareTo(FormationPair other)
        {
            return this.Weight - other.Weight;
        }

    }
}
