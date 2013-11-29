using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationThreeWithOne :IFormation, IComparable<FormationThreeWithOne>
    {
        private FormationThree _formationThree;
        private FormationSingle _formationSingle;
         
        public FormationThreeWithOne(FormationThree fThree, FormationSingle fSingle)
        {
            Guard.IsNotEqual(fThree.Weight, fSingle.Weight);
            _formationThree = fThree;
            _formationSingle = fSingle;
        }

        public int Weight
        {
            get { return _formationThree.Weight; }
        }

        public string Name
        {
            get { return "三带一"; }
        }

        public int CompareTo(FormationThreeWithOne other)
        {
            return this.Weight - other.Weight;
        }
    }
}
