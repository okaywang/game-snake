using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class FlowThreeForm : ICertification
    {
        public Formation.IFormation Parse(List<DataContext.Card> cards)
        {
            var threes = new Formation.FormationThree[cards.Count / 3];
            for (int i = 0; i < threes.Length; i++)
            {
                threes[i] = new Formation.FormationThree(cards[3 * i], cards[3 * i + 1], cards[3 * i + 2]);
            }
            return new Formation.FormationSequenceofThree(threes);
        }

        public bool IsValid(List<DataContext.Card> cards)
        {
            var cards1 = new List<Card>();
            var cards2 = new List<Card>();
            var cards3 = new List<Card>();
            for (int i = 0; i < cards.Count; i += 3)
            {
                cards1.Add(cards[i]);
                cards2.Add(cards[i + 1]);
                cards3.Add(cards[i + 2]);
            }

            var isFlow = Identifier.Increase(cards1, 1, p => p.WeightValue);
            if (!isFlow)
            {
                return false;
            }
            var isSame = Identifier.BeSame<Card, int>(cards1, cards2, p => p.WeightValue);
            if (!isSame)
            {
                return false;
            }
            return Identifier.BeSame<Card, int>(cards1, cards3, p => p.WeightValue);
        }
    }
}
