using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CommonHelper;

namespace WindowsFormsApplication1
{
    public abstract class TetrominoBase
    {
        protected abstract bool[,] Data { get; set; }
        public abstract Color ForeColor { get; }


        public void Transform()
        {
            Data = Helper.ClockwiseRotate90(Data);
        }

        public IEnumerable<bool[]> GetDataUpward()
        {
            var rowUpperBound = Data.GetUpperBound(0);
            var colUpperBound = Data.GetUpperBound(1);
            var b = new bool[rowUpperBound];
            for (int i = rowUpperBound; i >= 0; i--)
            {
                for (int j = 0; j <= colUpperBound; j++)
                {
                    b[j] = Data[i, j];
                }
                yield return b;
            }
        }

        protected void Paint(int blockWidth, int blockHeight, Graphics g)
        {
            var rowCount = Data.GetUpperBound(0) + 1;
            var colCount = Data.GetUpperBound(1) + 1;

            var brush = Brushes.Red;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (Data[i, j])
                    {
                        brush = new SolidBrush(this.ForeColor);
                        g.FillRectangle(brush, j * blockWidth, i * blockHeight, blockWidth, blockHeight);
                    }
                }
            }
        }
    }
}
