using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class FlowThreeWithSole : ICertification
    {
        public Formation.IFormation Issue(List<DataContext.Poker> cards)
        {
            throw new NotImplementedException();
        }

        public bool ICertificate(List<DataContext.Poker> cards)
        {
            throw new NotImplementedException();
        }
    }
}
