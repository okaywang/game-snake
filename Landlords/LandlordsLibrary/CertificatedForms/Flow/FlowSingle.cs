using BasicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class FlowSingleForm : ICertification
    {
        public Formation.IFormation Parse(List<DataContext.Card> cards)
        {
            var singles = cards.Select(p=> new Formation.FormationSingle(p)).ToList();
            return new Formation.FormationSequenceOfSingle(singles.ToArray());
        }

        public bool IsValid(List<DataContext.Card> cards)
        {
            return Identifier.Increase(cards, 1, p => p.WeightValue);
        }
    }
}
