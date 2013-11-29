using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationBomb : IFormation, IComparable<FormationBomb>
    {
        private int _weight;
        public FormationBomb(FormationFour fFour)
        {
            _weight = fFour.Weight;
        }
        public FormationBomb()
        {
            _weight = (int)CardWeights.Queen;
        }

        public string Name
        {
            get { return "炸弹"; }
        }

        public int Weight
        {
            get { return _weight; }
        }

        public int CompareTo(FormationBomb other)
        {
            return this.Weight - other.Weight;
        }
    }
}
