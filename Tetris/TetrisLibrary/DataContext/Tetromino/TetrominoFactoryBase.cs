using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary.DataContext.Tetromino
{
    public abstract class TetrominoFactoryBase
    {
        protected abstract int Count { get; }

        protected int RandomIndex
        {
            get
            {
                return new Random().Next(0, this.Count);
            }
        }

        public abstract TetrominoBase GetRandomTetromino();
    }
}
