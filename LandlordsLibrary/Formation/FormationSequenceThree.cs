using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationSequenceThree : FormationSequence<FormationPair>
    {
        public FormationSequenceThree(FormationThree[] three)
            : base(three, 2)
        {
        }

    }
}
