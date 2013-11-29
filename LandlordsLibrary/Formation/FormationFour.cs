using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationFour : IFormation,IComparable<FormationThree>
    {
        private Poker[] _pokers;

        public FormationFour(Poker[] pokers)
        {
            Guard.ArrayLengthEqual(pokers, 4);
            Guard.IsEqual(pokers[0].WeightValue, pokers[1].WeightValue, pokers[2].WeightValue, pokers[3].WeightValue);
            _pokers = pokers;
        }

        public int Weight
        {
            get { return _pokers[0].WeightValue; }
        }

        public string Name
        {
            get { return "四个"; }
        }

        public int CompareTo(FormationThree other)
        {
            return this.Weight - other.Weight;
        }
    }
}
