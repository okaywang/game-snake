using BasicLibrary;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public class FormationSequenceOfSingle : FormationSequence<FormationSingle>
    {
        public FormationSequenceOfSingle(FormationSingle[] formations)
            : base(formations, 5)
        {
        }

        public override string Name
        {
            get
            {
                return "顺子";
            }
        }
    }

    public class FormationSequenceOfPair : FormationSequence<FormationPair>
    {
        public FormationSequenceOfPair(FormationPair[] formations)
            : base(formations, 3)
        {
        }

        public override string Name
        {
            get
            {
                return "顺子2";
            }
        }
    }

    public class FormationSequenceofThree : FormationSequence<FormationThree>
    {
        public FormationSequenceofThree(FormationThree[] formations)
            : base(formations, 2)
        {
        }

        public override string Name
        {
            get
            {
                return "飞机";
            }
        }
    }
}
