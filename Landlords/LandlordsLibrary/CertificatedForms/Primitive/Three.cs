using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class Three : ICertification
    {
        public Formation.IFormation Issue(List<DataContext.Poker> cards)
        {
            return new Formation.FormationThree(cards.ToArray(), null);
        }

        public bool ICertificate(List<DataContext.Poker> cards)
        {
            return Identifier.BeSame<Poker>(cards, p => p.WeightValue);
        }
    }
}
