using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormControls
{
    public class GridPanel : Panel
    {
        private int _rowCount = 3;
        public int RowsCount
        {
            get { return _rowCount; }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                _rowCount = value;

                this.Invalidate();
            }
        }

        private int _columnCount = 3;
        public int ColumnCount
        {
            get { return _columnCount; }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                _columnCount = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            WinFormHelper.DrawGrid(this, this.RowsCount, this.ColumnCount);
        }
    }
}
