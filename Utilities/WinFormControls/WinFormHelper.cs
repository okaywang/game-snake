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
        public static void DrawGrid(Panel panel, int rowCount, int columnCount)
        {
            var g = panel.CreateGraphics();

            int x = 0;
            int y = 0;
            var rowHeight = panel.Height / rowCount;
            while (y < panel.Height)
            {
                g.DrawLine(Pens.Brown, x, y, panel.Width, y);
                y += rowHeight;
            }

            x = 0;
            y = 0;
            var columnWidth = panel.Width / columnCount;
            while (x < panel.Width)
            {
                g.DrawLine(Pens.Brown, x, y, x, panel.Height);
                x += columnWidth;
            }
        }
    }
}
