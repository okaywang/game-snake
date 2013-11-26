using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public class InvalidCrowdResidenceException : Exception
    {
        public InvalidCrowdResidenceException(string msg)
            : base(msg)
        {

        }
    }
}
