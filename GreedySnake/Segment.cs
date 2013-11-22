using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfGreedySnake
{
    public class Segment : IMoveable
    {
        public Coordinate Poisition;// { get; set; }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    Poisition.MoveUp();
                    break;
                case Direction.Right:
                    Poisition.MoveRight();
                    break;
                case Direction.Down:
                    Poisition.MoveDown();
                    break;
                case Direction.Left:
                    Poisition.MoveLeft();
                    break;
                default:
                    break;
            }
        }

        public Rectangle Shape
        {
            get
            {
                var rect = new Rectangle();
                rect.Width = 20;
                rect.Height = 20;
                rect.Fill = Brushes.Silver;
                return rect;
            }
        }
    }
}
