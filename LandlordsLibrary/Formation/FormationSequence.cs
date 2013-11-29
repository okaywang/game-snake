using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationSequence<T> : IFormation, IComparable<FormationSequence<T>>
    {
        private IFormation[] _pokers;

        public FormationSequence(IFormation[] pokers, int minLength)
        {
            Guard.ArrayLengthGreatThanOrEqual(pokers, minLength);
            Array.Sort(pokers, (p1, p2) => p1.Weight - p2.Weight);
            Guard.Increase(pokers, 1, p => p.Weight);
            _pokers = pokers;
        }

        public int Length
        {
            get { return _pokers.Length; }
        }

        public int Weight
        {
            get { return _pokers[0].Weight; }
        }

        public string Name
        {
            get { return "单张"; }
        }

        public int CompareTo(FormationSequence<T> other)
        {
            if (this.Length != other.Length)
            {
                throw new InvalidOperationException("the compare is illegal");
            }
            return this.Weight - other.Weight;
        }
    }
}
