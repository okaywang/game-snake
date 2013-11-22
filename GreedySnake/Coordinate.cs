using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfGreedySnake
{

    /*         0 1 2 3 4 5 6 7 8 9   X
     *      0 |———————————————————————
     *      1 |
     *      2 |
     *      3 |
     *      4 |
     *      5 |
     *      6 |
     *      Y  
     */
    public struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void MoveDown()
        {
            this.Y++;
        }
        public void MoveUp()
        {
            this.Y--;
        }
        public void MoveLeft()
        {
            this.X--;
        }
        public void MoveRight()
        {
            this.X++;
        }
    }
}
