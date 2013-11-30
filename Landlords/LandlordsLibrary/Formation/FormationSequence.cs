using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public abstract class FormationSequence<T> : IFormation, IComparable<FormationSequence<T>>
    {
        private IFormation[] _formations;

        public FormationSequence(IFormation[] formations, int minLength)
        {
            Guard.ArrayLengthGreatThanOrEqual(formations, minLength);
            Array.Sort(formations, (p1, p2) => p1.Weight - p2.Weight);
            Guard.Increase(formations, 1, p => p.Weight);
            _formations = formations;
        }



        public Card[] Cards
        {
            get { return _formations.SelectMany(p => p.Cards).ToArray(); }
        }

        public int Length
        {
            get { return _formations.Length; }
        }

        public int Weight
        {
            get { return _formations[0].Weight; }
        }

        public abstract string Signature
        {
            get;
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
