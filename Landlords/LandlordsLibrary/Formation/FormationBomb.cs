using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationBomb : IFormation, IComparable<FormationBomb>
    {
        private int _weight;
        private Card[] _cards;
        public FormationBomb(FormationFour fFour)
        {
            _weight = fFour.Weight;
            _cards = fFour.Cards;
        }
        public FormationBomb()
        {
            _weight = (int)CardWeights.Queen;
            _cards = new Card[] { CardCarton.Get(52), CardCarton.Get(53) };
        }


        public Card[] Cards
        {
            get { return _cards; }
        }

        public string Name
        {
            get { return "炸弹"; }
        }

        public int Weight
        {
            get { return _weight; }
        }

        public int CompareTo(FormationBomb other)
        {
            return this.Weight - other.Weight;
        }

    }
}
