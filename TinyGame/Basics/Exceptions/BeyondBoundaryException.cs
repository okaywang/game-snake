using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
    public class BeyondBoundaryException : Exception
    {
        public BeyondBoundaryException(string msg)
            : base(msg)
        {

        }
    }
}
