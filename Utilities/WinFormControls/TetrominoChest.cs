using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design;
using BasicLibrary;

namespace WindowsFormsApplication1
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public class TetrominoChest : ContainerControl
    {
        private int _rowCount = 1;
        private int _colCount = 1;

        private Block[,] _blocks;

        public void SetTetrominos(Block[,] data)
        {
            _blocks = data;
            _rowCount = data.GetUpperBound(0) + 1;
            _colCount = data.GetUpperBound(1) + 1;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_blocks == null)
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

                    if (_blocks[i, j] != null)
                    {
                        e.Graphics.FillEllipse(new SolidBrush(_blocks[i, j].ForeColor), j * blockWidth, (_rowCount - i - 1) * blockWidth, blockWidth, blockHeight);
                    }
                }
            }
        }
    }
}
