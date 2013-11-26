using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public class InvalidResidenceException : Exception
    {
        public InvalidResidenceException(string msg)
            : base(msg)
        {

        }
    }
}
