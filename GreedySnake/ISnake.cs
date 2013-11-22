using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfGreedySnake
{
    public interface ISnake
    {
        void Eat(Food food);
        void Crash();
    }
}
