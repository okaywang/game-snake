using BasicLibrary;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class FlowThreeWithPair : ICertification
    {
        public Formation.IFormation Parse(List<DataContext.Card> cards)
        {

            var groups = cards.GroupBy(c => c.WeightValue).OrderBy(g => g.Count());

            var pairs = groups.Where(g => g.Count() == 2).Select(i => i.ToList());

            var threes = groups.Where(g => g.Count() == 3).Select(p => p.ToList());

            var formationThrees = new FormationThree[pairs.Count()];
            for (int i = 0; i < formationThrees.Length; i++)
            {
                formationThrees[i] = new FormationThree(threes.ElementAt(i).ToArray(), new FormationPair(pairs.ElementAt(i).ToArray()));
            }

            return new Formation.FormationSequenceofThree(formationThrees);
        }

        public bool IsValid(List<DataContext.Card> cards)
        {
            if (cards.Count % 5 != 0)
            {
                return false;
            }

            var continuousCount = cards.Count / 5;
            if (continuousCount <= 1)
            {
                return false;
            }

            var groups = cards.GroupBy(c => c.WeightValue).OrderBy(g => g.Count());

            var pairs = groups.Where(g => g.Count() == 2).Select(i => i.First());
            if (pairs.Count() != continuousCount)
            {
                return false;
            }
            if (pairs.Distinct().Count() != pairs.Count())
            {
                return false;
            }

            var threes = groups.Where(g => g.Count() == 3).Select(i => i.First());
            return Identifier.Increase(threes.ToList(), 1, p => p.WeightValue);
        }
    }
}
