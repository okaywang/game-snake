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
    public class FourWithTwoPair : ICertification
    {
        public Formation.IFormation Parse(List<DataContext.Card> cards)
        {
            cards.Sort((p1, p2) => p1.WeightValue - p2.WeightValue);
            for (int continuousThreeIndex = 0; continuousThreeIndex <= 4; continuousThreeIndex++)
            {
                if (Identifier.BeSame(cards, continuousThreeIndex, 4, p => p.WeightValue))
                {
                    return GetFormation(cards, continuousThreeIndex);
                }
            }
            return null;
        }

        private IFormation GetFormation(List<Card> cards, int continuousThreeIndex)
        {
            var tmp = new Dictionary<int, int[]>();
            tmp[0] = new int[] { 4, 5, 6, 7 };
            tmp[1] = new int[] { 0 };
            tmp[2] = new int[] { 0, 1, 6, 7 };
            tmp[3] = new int[] { 0 };
            tmp[4] = new int[] { 0, 1, 2, 3 };

            return new FormationFour(cards.GetRange(continuousThreeIndex, 4).ToArray(),
                new FormationPair(new Card[] { cards[tmp[continuousThreeIndex][0]], cards[tmp[continuousThreeIndex][1]] }),
                new FormationPair(new Card[] { cards[tmp[continuousThreeIndex][2]], cards[tmp[continuousThreeIndex][3]] }));
        }

        public bool IsValid(List<DataContext.Card> cards)
        {
            return cards.GroupBy(p => p.WeightValue).Count() == 3;
        }
    }
}
