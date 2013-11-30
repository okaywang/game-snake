using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class FlowPair : ICertification
    {
        public Formation.IFormation Issue(List<DataContext.Poker> cards)
        {
            var pairs = new Formation.FormationPair[cards.Count / 2];
            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new Formation.FormationPair(cards[2 * i], cards[2 * i + 1]);
            }
            return new Formation.FormationSequenceOfPair(pairs);
        }

        public bool ICertificate(List<DataContext.Poker> cards)
        {
            int i = 0;
            var evenCards = cards.TakeWhile(p => { return i++ % 2 == 0; }).ToList();
            i = 0;
            var oddCards = cards.TakeWhile(p => { return i++ % 2 != 0; }).ToList();

            var isFlow = Identifier.Increase(evenCards, 1, p => p.WeightValue);
            if (!isFlow)
            {
                return false;
            }
            return Identifier.BeSame<Poker, int>(evenCards, oddCards, p => p.WeightValue);
        }
    }
}
