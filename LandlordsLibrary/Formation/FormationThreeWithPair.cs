using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationThreeWithPair : IFormation, IComparable<FormationThreeWithPair>
    {
        private FormationThree _formationThree;
        private FormationPair _formationPair;

        public FormationThreeWithPair(FormationThree formationThree, FormationPair formationPair)
        {
            Guard.IsNotEqual(formationThree.Weight, formationPair.Weight);
            _formationThree = formationThree;
            _formationPair = formationPair;
        }

        public int Weight
        {
            get { return _formationThree.Weight; }
        }

        public string Name
        {
            get { return "三带一"; }
        }

        public int CompareTo(FormationThreeWithPair other)
        {
            return this.Weight - other.Weight;
        }
    }
}
