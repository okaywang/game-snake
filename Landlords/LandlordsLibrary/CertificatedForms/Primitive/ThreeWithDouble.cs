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
    public class ThreeWithDouble : ICertification
    {
        public Formation.IFormation Parse(List<DataContext.Card> cards)
        {
            var continuousThreeIndex = 0;

            cards.Sort((p1, p2) => p1.WeightValue - p2.WeightValue);
            if (Identifier.BeSame(cards, 0, 3, p => p.WeightValue))
            {
                continuousThreeIndex = 0;
            }
            else if (Identifier.BeSame(cards, 1, 3, p => p.WeightValue))
            {
                continuousThreeIndex = 1;
            }
            else if (Identifier.BeSame(cards, 2, 3, p => p.WeightValue))
            {
                continuousThreeIndex = 2;
            }
            return GetFormation(cards, continuousThreeIndex);
        }

        private IFormation GetFormation(List<Card> cards, int continuousThreeIndex)
        {
            var tmp = new Dictionary<int, int[]>();
            tmp[0] = new int[] { 3, 4 };
            tmp[1] = new int[] { 0, 4 };
            tmp[2] = new int[] { 0, 1 };

            var pair = new Formation.FormationPair(cards[tmp[continuousThreeIndex][0]], cards[tmp[continuousThreeIndex][1]]);
            return new Formation.FormationThree(cards.GetRange(continuousThreeIndex, 3).ToArray(), pair);
        }

        public bool IsValid(List<DataContext.Card> cards)
        {
            var groups = cards.GroupBy(p => p.WeightValue);
            if (groups.Count() != 2)
            {
                return false;
            }

            return groups.All(g => g.ToList().Count() == 2 || g.ToList().Count == 3);
        }
    }
}
