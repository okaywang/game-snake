﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace GreedySnakeLibrary
{
    public interface ISnakeGameView:SimpleGame.IGameView
    {
        //void RenderMap(int rowCount,int columnCount);
        void RenderSnake(Snake snake);
        void RenderFood(Food food);
        void ClearObjects();
    }
}
