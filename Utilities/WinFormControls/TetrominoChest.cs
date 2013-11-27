using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design;
using BasicLibrary;
using System.Drawing.Drawing2D;

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


                    if (_blocks[i, j] != null)
                    {
                        //e.Graphics.FillEllipse(new SolidBrush(_blocks[i, j].ForeColor), j * blockWidth, (_rowCount - i - 1) * blockWidth, blockWidth, blockHeight);
                        this.PaintSquare(e.Graphics, new PointF(j * blockWidth, (_rowCount - i - 1) * blockWidth), new SizeF(blockWidth, blockHeight), Color.White, _blocks[i, j].ForeColor);
                    }
                }
            }
        }

        private void PaintSquare(Graphics g, PointF location, SizeF size, Color backColor, Color foreColor)
        {
            var gp = new GraphicsPath();
            var rec = new RectangleF(location, size);
            gp.AddRectangle(rec);
            var surroundColor = new Color[] { backColor };
            var pb = new PathGradientBrush(gp);
            pb.CenterColor = foreColor;
            pb.SurroundColors = surroundColor;
            g.FillPath(pb, gp);
        }
    }
}
