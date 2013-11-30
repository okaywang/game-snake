using BasicLibrary;
using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class DoubleForm : ICertification
    {
        public IFormation Parse(List<DataContext.Card> cards)
        {
            return new FormationPair(cards.ToArray());
        }

        public bool IsValid(List<DataContext.Card> cards)
        {
            return Identifier.BeSame<Card,int>(cards, p => p.WeightValue);
        }
    }
}
