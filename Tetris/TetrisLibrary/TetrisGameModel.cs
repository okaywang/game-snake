using BasicLibrary;
using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary.DataContext;
using TetrisLibrary.DataContext.Tetromino;

namespace TetrisLibrary
{
    public class TetrisGameModel : IDataModel
    {
        public Apartment Apartment { get; set; }
        public TetrominoBase Tetromino { get; set; }

        public int ActiveRowIndex { get; set; }
        public int ActiveColumnIndex { get; set; }

        public bool[,] TetrominoContext
        {
            get
            {
                return GetContext(this.ActiveRowIndex, this.ActiveColumnIndex);
            }
        }

        public bool[,] LeftTetrominoContext
        {
            get
            {
                return GetContext(this.ActiveRowIndex, this.ActiveColumnIndex - 1);
            }
        }
        public bool[,] RightTetrominoContext
        {
            get
            {
                return GetContext(this.ActiveRowIndex, this.ActiveColumnIndex + 1);
            }
        }
        public bool[,] DownTetrominoContext
        {
            get
            {
                return GetContext(this.ActiveRowIndex - 1, this.ActiveColumnIndex);
            }
        }

        private bool[,] GetContext(int relativeRowIndex, int relativeColumnIndex)
        {
            var context = new bool[this.Tetromino.Height, this.Tetromino.Width];
            for (int i = this.Tetromino.Height - 1; i > -1; i--)
            {
                var colIndex = relativeColumnIndex;
                for (int j = 0; j < this.Tetromino.Width; j++)
                {
                    if (colIndex < 0 || colIndex > this.Apartment.UnitCount - 1 || relativeRowIndex < 0)
                    {
                        context[i, j] = true;
                    }
                    else if (relativeRowIndex > this.Apartment.FloorCount - 1)
                    {
                        context[i, j] = false;
                    }
                    else
                    {
                        context[i, j] = this.Apartment[relativeRowIndex][colIndex].HasResident;
                    }
                    colIndex++;
                }

                relativeRowIndex++;
            }
            return context;
        }

        public Block[,] GetUnderlyingData()
        {
            var data = this.Apartment.GetUnderlyingData();
            var tetrominoData = this.Tetromino.GetUnderlyingDataUpward();

            var rowIndex = ActiveRowIndex;

            foreach (var rowData in tetrominoData)
            {
                if (rowIndex > this.Apartment.FloorCount - 1)
                {
                    break;
                }
                if (rowIndex < 0)
                {
                    rowIndex++;
                    continue;
                }
                for (int i = 0; i < rowData.Length; i++)
                {
                    var colIndex = ActiveColumnIndex + i;
                    if (colIndex < this.Apartment.UnitCount && colIndex > -1)
                    {
                        if (rowData[i])
                        {
                            data[rowIndex, ActiveColumnIndex + i] = new Block(this.Tetromino.ForeColor);
                        }
                    }
                }
                rowIndex++;
            }

            return data;
        }
    }
}
