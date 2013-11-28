using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TetrisLibrary.DataContext.Tetromino
{
    public class Tetromino3 : TetrominoBase
    {
        private bool[,] _data ={{true,true,true},
                             {true,false,true},
                             {true,false,true}};


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
