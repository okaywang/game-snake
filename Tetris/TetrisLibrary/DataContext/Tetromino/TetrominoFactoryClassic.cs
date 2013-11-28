using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary.DataContext.Tetromino
{
    public class TetrominoFactoryClassic : TetrominoFactoryBase
    {
        public override TetrominoBase GetRandomTetromino()
        {
            var index = base.RandomIndex;
            switch (index)
            {
                case 0:
                    return new I_Tetromino();
                case 1:
                    return new J_Tetromino();
                case 2:
                    return new L_Tetromino();
                case 3:
                    return new O_Tetromino();
                case 4:
                    return new S_Tetromino();
                case 5:
                    return new T_Tetromino();
                case 6:
                    return new Z_Tetromino();
                default:
                    return null;
            }
        }

        protected override int Count
        {
            get { return 7; }
        }
    }
}
