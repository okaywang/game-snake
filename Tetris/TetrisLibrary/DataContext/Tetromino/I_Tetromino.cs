using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Drawing;
using CommonHelper;

namespace TetrisLibrary.DataContext.Tetromino
{
    public class I_Tetromino : TetrominoBase
    {
        private bool[,] _data;
        private bool[,] _dataVertical ={{false,true,false,false},
                             {false,true,false,false},
                             {false,true,false,false},
                             {false,true,false,false}};
        private bool[,] _dataHorizontal ={{false,false,false,false},
                             {false,false,false,false},
                             {true,true,true,true},
                             {false,false,false,false}};
        public I_Tetromino()
        {
            _isVertical = true;
            _data = _dataVertical;
        }

        private bool _isVertical = true;
        public override void Transform()
        {
            if (_isVertical)
            {
                _isVertical = false;
                _data = _dataHorizontal;
            }
            else
            {
                _isVertical = true;
                _data = _dataVertical;
            }
        }

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
            get { return Color.Cyan; }
        }
    }
}
