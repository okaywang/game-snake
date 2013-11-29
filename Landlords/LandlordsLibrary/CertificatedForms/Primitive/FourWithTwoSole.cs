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
    //6
    public class FourWithTwoSole : ICertification
    {
        public IFormation Issue(List<Poker> cards)
        {
            cards.Sort((p1, p2) => p1.WeightValue - p2.WeightValue); 
            for (int continuousThreeIndex = 0; continuousThreeIndex <= 2; continuousThreeIndex++)
            {
                if (Identifier.BeSame(cards, continuousThreeIndex, 3, p => p.WeightValue))
                {
                    return GetFormation(cards, continuousThreeIndex);
                }
            }
            return null; 
        }

        private IFormation GetFormation(List<Poker> cards, int continuousFourIndex)
        {
            var tmp = new Dictionary<int, int[]>();
            tmp[0] = new int[] { 4, 5 };
            tmp[1] = new int[] { 0, 5 };
            tmp[2] = new int[] { 0, 1 };
            return new Formation.FormationFour(cards.GetRange(continuousFourIndex, 4).ToArray(), new Formation.FormationSingle(cards[tmp[continuousFourIndex][0]]), new Formation.FormationSingle(cards[tmp[continuousFourIndex][1]]));
        }

        public bool ICertificate(List<DataContext.Poker> cards)
        {
            var groups = cards.GroupBy(p => p.WeightValue);
            if (groups.Count() != 3)
            {
                return false;
            }
            foreach (var group in groups)
            {
                if (group.Count() !=1 && group.Count () !=4)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
