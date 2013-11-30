using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class ThreeForm : ICertification
    {
        public Formation.IFormation Parse(List<DataContext.Card> cards)
        {
            return new Formation.FormationThree(cards.ToArray(), null);
        }

        public bool IsValid(List<DataContext.Card> cards)
        {
            return Identifier.BeSame<Card,int>(cards, p => p.WeightValue);
        }
    }
}
