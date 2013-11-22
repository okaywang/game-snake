using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WpfGreedySnake
{
    public static class WpfHelper
    {
        public static void SetDimension(this Grid grid, int rowCount, int columnCount)
        {
            while (rowCount-- > 0)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            while (columnCount-- > 0)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
    }
}
