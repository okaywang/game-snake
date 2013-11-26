using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TetrisLibrary.DataContext.Tetromino
{
    public class L_Tetromino : TetrominoBase
    {
        private bool[,] _data ={{false,false,true},
                             {true,true,true},
                             {false,false,false}};


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
            get { return Color.LightYellow; }
        }
    }
}
