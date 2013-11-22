using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfGreedySnake
{
   public  interface IMoveable
    {
        void Move(Direction direction);
    }
}
