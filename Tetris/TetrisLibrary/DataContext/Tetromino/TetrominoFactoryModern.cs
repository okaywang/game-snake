using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary.DataContext.Tetromino
{
    public class TetrominoFactoryModern : TetrominoFactoryBase
    {
        public override TetrominoBase GetRandomTetromino()
        {
            var index = base.RandomIndex;
            switch (index)
            {
                case 0:
                    return new Tetromino1();
                case 1:
                    return new Tetromino2();
                case 2:
                    return new Tetromino3();
                case 3:
                    return new Tetromino4();
                default:
                    return null;
            }
        }

        protected override int Count
        {
            get { return 4; }
        }
    }
}
