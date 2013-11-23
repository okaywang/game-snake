using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    public class GameSettingsBase
    {
        public int TimerInterval { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
    }
}
