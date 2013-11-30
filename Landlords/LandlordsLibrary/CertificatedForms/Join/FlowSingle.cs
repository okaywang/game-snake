using BasicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class FlowSingle : ICertification
    {
        public Formation.IFormation Issue(List<DataContext.Poker> cards)
        {
            var singles = cards.Select(p=> new Formation.FormationSingle(p)).ToList();
            return new Formation.FormationSequenceOfSingle(singles.ToArray());
        }

        public bool ICertificate(List<DataContext.Poker> cards)
        {
            return Identifier.Increase(cards, 1, p => p.WeightValue);
        }
    }
}
