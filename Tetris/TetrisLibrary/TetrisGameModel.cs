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
                var context = new bool[this.Tetromino.Height, this.Tetromino.Width];
                for (int i = 0; i < this.Tetromino.Height; i++)
                {
                    for (int j = 0; j < this.Tetromino.Width; j++)
                    {
                        var rowIndex = i + ActiveRowIndex;
                        var colIndex = j + ActiveColumnIndex;
                        if (colIndex < 0 || colIndex > this.Apartment.UnitCount - 1 || rowIndex > this.Apartment.FloorCount - 1)
                        {
                            context[i, j] = true;
                        }
                        else
                        {
                            context[i, j] = this.Apartment[rowIndex][colIndex].HasResident;
                        }
                    }
                }
                return context;
            }
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
