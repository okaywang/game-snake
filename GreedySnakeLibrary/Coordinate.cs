using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public struct Coordinate
    {
        public static int MaxX = 10;
        public static int MaxY = 10;

        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
            : this()
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Coordinate a, Coordinate b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Coordinate a, Coordinate b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", this.X, this.Y);
        }

        public static Coordinate GetRandomPosition()
        {
            var random =new Random();
            return new Coordinate(random.Next(Coordinate.MaxX), random.Next(Coordinate.MaxY));
        }
    }
}
