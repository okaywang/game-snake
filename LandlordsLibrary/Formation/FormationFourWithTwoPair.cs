using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationFourWithTwoPair : IFormation, IComparable<FormationFourWithTwoPair>
    {
        private FormationFour _formationFour;

        public FormationFourWithTwoPair(FormationFour fFour, FormationPair fPair1, FormationSingle fPair2)
        {
            Guard.IsNotEqual(fPair1.Weight, fPair1.Weight);

            _formationFour = fFour;
        }

        public int Weight
        {
            get { return _formationFour.Weight; }
        }

        public string Name
        {
            get { return "四带二对"; }
        }

        public int CompareTo(FormationFourWithTwoPair other)
        {
            return this.Weight - other.Weight;
        }
    }
}
