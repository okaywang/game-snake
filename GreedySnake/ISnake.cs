using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfGreedySnake
{
    interface ISnake
    {
        void MoveForward();
        void Eat(Food food);
        void Crash();
    }
}
