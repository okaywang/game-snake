using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public class FloorUseupException: Exception
    {
        public FloorUseupException(string msg)
            : base(msg)
        {

        }
    } 
}
