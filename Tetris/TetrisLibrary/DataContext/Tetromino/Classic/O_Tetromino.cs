﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Drawing;

namespace TetrisLibrary.DataContext.Tetromino
{
    public class O_Tetromino : TetrominoBase
    {
        private bool[,] _data ={{true,true},
                             {true,true}};


        protected override bool[,] Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public override Color ForeColor
        {
            get { return Color.Blue; }
        }
    }
}
