using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public class SnakeGameModel : IDataModel
    {
        public Snake Snake { get; set; }
        public Food Food { get; set; }
    }
}
