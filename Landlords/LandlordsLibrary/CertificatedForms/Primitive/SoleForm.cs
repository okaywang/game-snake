using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class SoleForm : ICertification
    { 
        public IFormation Parse(List<Card> cards)
        {
            return new FormationSingle(cards.First());
        }

        public bool IsValid(List<Card> cards)
        {
            return cards.Count == 1;
        }
    }
}
