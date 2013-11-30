using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class ThreeWithSole : ICertification
    {
        public Formation.IFormation Issue(List<DataContext.Poker> cards)
        {
            if (cards[0].WeightValue == cards[1].WeightValue)
            {
                return new Formation.FormationThree(cards.GetRange(0, 3).ToArray(), new Formation.FormationSingle(cards[3]));
            }
            else
            {
                return new Formation.FormationThree(cards.GetRange(1, 3).ToArray(), new Formation.FormationSingle(cards[0]));
            }
        }

        public bool ICertificate(List<DataContext.Poker> cards)
        {
            return cards.GroupBy(p => p.WeightValue).Count() == 2;
        }
    }
}
