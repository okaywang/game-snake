using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public class EliminateRowsEventArgs : EventArgs
    {
        public int EliminateRowsCount { get; set; }
    }
}
