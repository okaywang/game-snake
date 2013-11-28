using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TetrisLibrary.DataContext.Tetromino
{
    public class Tetromino2 : TetrominoBase
    {
        private bool[,] _data ={{false,false,true,false},
                             {false,false,true,false},
                             {true,true,true,false},
                               {false,false,false,false}};


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
            get { return Color.Pink; }
        }
    }
}
