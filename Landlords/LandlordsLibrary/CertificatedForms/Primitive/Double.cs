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
    public class Double : ICertification
    {
        public IFormation Issue(List<DataContext.Poker> cards)
        {
            return new FormationPair(cards.ToArray());
        }

        public bool ICertificate(List<DataContext.Poker> cards)
        {
            return Identifier.BeSame<Poker>(cards, p => p.WeightValue);
        }
    }
}
