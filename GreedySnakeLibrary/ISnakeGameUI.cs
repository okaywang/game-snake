using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace GreedySnakeLibrary
{
    public interface ISnakeGameUI
    {
        void PaintMap(int rowCount,int columnCount);
        void PaintSnake(Snake snake);
        void PaintFood(Food food);
        void ClearObjects();
    }
}
