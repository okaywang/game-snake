using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class J_Tetromino : TetrominoBase
    {
        private bool[,] _data ={{true,false,false},
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
            get { return Color.Blue; }
        }
    }
}
