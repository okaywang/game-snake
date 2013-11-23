using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public class SelfCrashedException : Exception
    {
        public SelfCrashedException(string msg)
            : base(msg)
        {

        }
    }
}
