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
        private Card[] _pokers;
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
            _pokers = pokers;
            _appendix = appendix;
        }

        public int Weight
        {
            get { return _pokers[0].WeightValue; }
        }

        public string Name
        {
            get { return "三个"; }
        }

        public int CompareTo(FormationThree other)
        {
            return this.Weight - other.Weight;
        }
    }
}
