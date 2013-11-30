using BasicLibrary;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class FlowThreeWithSole : ICertification
    {
        public Formation.IFormation Parse(List<DataContext.Card> cards)
        {

            var groups = cards.GroupBy(c => c.WeightValue).OrderBy(g => g.Count());

            var singles = groups.Where(g => g.Count() == 1).Select(i => i.First());
             
            var threes = groups.Where(g => g.Count() == 3).Select(p => p.ToList());

            var formationThrees = new FormationThree[singles.Count()];
            for (int i = 0; i < formationThrees.Length; i++)
            {
                formationThrees[i] = new FormationThree(threes.ElementAt(i).ToArray(), new FormationSingle(singles.ElementAt(i)));
            }

            return new Formation.FormationSequenceofThree(formationThrees);
        }

        public bool IsValid(List<DataContext.Card> cards)
        {
            if (cards.Count % 4 != 0)
            {
                return false;
            }

            var continuousCount = cards.Count / 4;
            if (continuousCount <= 1)
            {
                return false;
            }
             
            var groups = cards.GroupBy(c => c.WeightValue).OrderBy(g => g.Count());

            var singles = groups.Where(g => g.Count() == 1).Select(i => i.First());
            if (singles.Count() != continuousCount)
            {
                return false;
            }
            if (singles.Distinct().Count() != singles.Count())
            {
                return false;
            }

            var threes = groups.Where(g => g.Count() == 3).Select(i => i.First());
            return Identifier.Increase(threes.ToList(), 1, p => p.WeightValue);
        }
    }
}
