using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public class BarrierCrashedException : Exception
    {
        public BarrierCrashedException(string msg)
            : base(msg)
        {

        }
    }
}
