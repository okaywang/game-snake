using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class T_Tetromino : TetrominoBase
    {
        private bool[,] _data ={{false,true,false},
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
            get { return Color.Pink; }
        }
    }
}
