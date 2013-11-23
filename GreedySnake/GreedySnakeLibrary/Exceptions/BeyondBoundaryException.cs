using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public class BeyondBoundaryException : Exception
    {
        public BeyondBoundaryException(string msg)
            : base(msg)
        {

        }
    }
}
