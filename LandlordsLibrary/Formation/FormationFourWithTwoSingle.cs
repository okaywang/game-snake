using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationFourWithTwoSingle : IFormation, IComparable<FormationFourWithTwoSingle>
    {
        private FormationFour _formationFour;

        public FormationFourWithTwoSingle(FormationFour fFour, FormationSingle fSingle1, FormationSingle fSingle2)
        {
            Guard.IsNotEqual(fSingle1.Weight, fSingle2.Weight);

            _formationFour = fFour;
        }

        public int Weight
        {
            get { return _formationFour.Weight; }
        }

        public string Name
        {
            get { return "四个"; }
        }

        public int CompareTo(FormationFourWithTwoSingle other)
        {
            return this.Weight - other.Weight;
        }
    }
}
