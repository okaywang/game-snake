using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Z_Tetromino : TetrominoBase
    {
        private bool[,] _data ={{true,true,false},
                             {false,true,true},
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
            get { return Color.Red; }
        }
    }
}
