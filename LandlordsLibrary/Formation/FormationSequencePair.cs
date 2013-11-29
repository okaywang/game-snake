using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationSequencePair : FormationSequence<FormationPair>
    {
        public FormationSequencePair(FormationPair[] pairs)
            : base(pairs, 3)
        {
        }

    }
}
