using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormControls
{
    public class WinFormHelper
    {
        public static void DrawGrid(Control control, int rowCount, int columnCount)
        {
            var g = control.CreateGraphics();

            int x = 0;
            int y = 0;
            var rowHeight = control.Height / rowCount;
            while (y < control.Height)
            {
                g.DrawLine(Pens.Brown, x, y, control.Width, y);
                y += rowHeight;
            }

            x = 0;
            y = 0;
            var columnWidth = control.Width / columnCount;
            while (x < control.Width)
            {
                g.DrawLine(Pens.Brown, x, y, x, control.Height);
                x += columnWidth;
            }
        }
    }
}
