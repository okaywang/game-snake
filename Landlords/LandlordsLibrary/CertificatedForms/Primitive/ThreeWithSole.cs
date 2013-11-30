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
        public Formation.IFormation Parse(List<DataContext.Card> cards)
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

        public bool IsValid(List<DataContext.Card> cards)
        {
            var groups = cards.GroupBy(p => p.WeightValue);
            if (groups.Count() != 2)
            {
                return false;
            }

            if (groups.Where(i => i.Count() == 3).Count() != 1)
            {
                return false;
            }
            return true;
        }
    }
}
