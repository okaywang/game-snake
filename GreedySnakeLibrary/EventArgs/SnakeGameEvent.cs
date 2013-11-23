using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public class SnakeGameEvent:  EventArgs
    {
        public string Message { get; set; }
    }
}
