using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationThree : IFormation, IComparable<FormationThree>, IExpandable
    {
        private Card[] _cards;
        private IAppendix _appendix;

        public FormationThree(Card poker1, Card poker2, Card poker3)
            : this(new Card[] { poker1, poker2, poker3 }, null)
        {

        }
        public FormationThree(Card[] pokers, IAppendix appendix)
        {
            Guard.ArrayLengthEqual(pokers, 3);
            Guard.IsEqual(pokers[0].WeightValue, pokers[1].WeightValue, pokers[2].WeightValue);
            if (appendix != null)
            {
                Guard.IsNotEqual(pokers[0].WeightValue, appendix.Weight);
            }
            _cards = pokers;
            _appendix = appendix;
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
            get
            {
                if (_cards.Length % 3 == 0)
                {
                    return "三个";
                }
                else if (_cards.Length % 3 == 1)
                {
                    return "三带一";
                }
                else
                {
                    return "三带一对";
                }
            }
        }

        public int CompareTo(FormationThree other)
        {
            return this.Weight - other.Weight;
        }


    }
}
