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
        private Poker[] _pokers;

        public FormationPair(Poker poker1, Poker poker2)
            : this(new Poker[] { poker1, poker2 })
        {

        }

        public FormationPair(Poker[] pokers)
        {
            Guard.ArrayLengthEqual(pokers, 2);
            Guard.IsEqual(pokers[0].WeightValue, pokers[1].WeightValue);

            _pokers = pokers;
        }

        public int Weight
        {
            get { return _pokers[0].WeightValue; }
        }

        public string Name
        {
            get { return "对"; }
        }

        public int CompareTo(FormationPair other)
        {
            return this.Weight - other.Weight;
        }
    }
}
