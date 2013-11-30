using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class FlowPairForm : ICertification
    {
        public Formation.IFormation Parse(List<DataContext.Card> cards)
        {
            var pairs = new Formation.FormationPair[cards.Count / 2];
            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new Formation.FormationPair(cards[2 * i], cards[2 * i + 1]);
            }
            return new Formation.FormationSequenceOfPair(pairs);
        }

        public bool IsValid(List<DataContext.Card> cards)
        { 
            var evenCards = new List<Card>(); 
            var oddCards = new List<Card>();
            for (int i = 0; i < cards.Count; i += 2)
            {
                evenCards.Add(cards[i]);
                oddCards.Add(cards[i + 1]);
            }


            var isFlow = Identifier.Increase(evenCards, 1, p => p.WeightValue);
            if (!isFlow)
            {
                return false;
            }
            return Identifier.BeSame<Card, int>(evenCards, oddCards, p => p.WeightValue);
        }
    }
}
