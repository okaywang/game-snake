using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary.DataContext;
using WindowsFormsApplication1;

namespace TetrisLibrary
{
    public class TetrisGameModel : IDataModel
    {
        public Apartment Apartment { get; set; }
        public TetrominoBase Tetromino { get; set; }

        public int ActiveRowIndex { get; set; }
        public int ActiveColumnIndex { get; set; }

        public bool[,] GetUnderlyingData()
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
                    data[rowIndex, ActiveColumnIndex + i] = data[rowIndex, ActiveColumnIndex + i] || rowData[i];
                }
                rowIndex++;
            }

            return data;
        }
    }
}
