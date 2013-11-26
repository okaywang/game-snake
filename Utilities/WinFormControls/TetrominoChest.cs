using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace WindowsFormsApplication1
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public class TetrominoChest : ContainerControl
    {
        private int _rowCount = 1;
        private int _colCount = 1;

        private bool[,] _tetrominos;

        public void SetTetrominos(bool[,] data)
        {
            _tetrominos = data;
            _rowCount = data.GetUpperBound(0) + 1;
            _colCount = data.GetUpperBound(1) + 1;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_tetrominos == null)
            {
                return;
            }
            var blockWidth = this.Width / (float)_colCount;
            var blockHeight = this.Height / (float)_rowCount;

            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    e.Graphics.FillEllipse(Brushes.Silver, j * blockWidth, (_rowCount - i - 1) * blockWidth, blockWidth, blockHeight);

                    if (_tetrominos[i, j])
                    {
                        e.Graphics.FillEllipse(Brushes.Red, j * blockWidth, (_rowCount - i - 1) * blockWidth, blockWidth, blockHeight);
                    }
                }
            }
        }
    }
}
