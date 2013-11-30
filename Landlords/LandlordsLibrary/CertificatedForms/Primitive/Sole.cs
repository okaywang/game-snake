using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class Sole : ICertification
    { 
        public IFormation Issue(List<Poker> cards)
        {
            return new FormationSingle(cards.First());
        }

        public bool ICertificate(List<Poker> cards)
        {
            return cards.Count == 1;
        }
    }
}
