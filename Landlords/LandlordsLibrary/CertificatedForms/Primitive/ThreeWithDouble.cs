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
        public Formation.IFormation Issue(List<DataContext.Poker> cards)
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

        private IFormation GetFormation(List<Poker> cards, int continuousThreeIndex)
        {
            var tmp = new Dictionary<int, int[]>();
            tmp[0] = new int[] { 3, 4 };
            tmp[1] = new int[] { 0, 4 };
            tmp[2] = new int[] { 0, 1 };
            return new Formation.FormationFour(cards.GetRange(continuousThreeIndex, 4).ToArray(), new Formation.FormationSingle(cards[tmp[continuousThreeIndex][0]]), new Formation.FormationSingle(cards[tmp[continuousThreeIndex][1]]));
        }

        public bool ICertificate(List<DataContext.Poker> cards)
        {
            return cards.GroupBy(p => p.WeightValue).Count() == 2;
        }
    }
}
