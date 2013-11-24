using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
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
    public abstract class CommandOrientation
    {
        public abstract void Execute(ref Coordinate coord);

        public abstract Coordinate GetExpectedResult(Coordinate coord);
    }
    public interface IVerticalOrientation
    { }
    public interface IHorizontalOrientation
    { }
    public class CommandUp : CommandOrientation,IVerticalOrientation
    {
        public override void Execute(ref Coordinate coord)
        {
            if (coord.Y == 0)
            {
                throw new BeyondBoundaryException("can not move beyond the up boundary!");
            }
            coord.Y--;
        }

        public override Coordinate GetExpectedResult(Coordinate coord)
        {
            coord.Y--;
            return coord;
        }
    }
    public class CommandDown : CommandOrientation,IVerticalOrientation
    {
        public override void Execute(ref Coordinate coord)
        {
            if (coord.Y == Coordinate.MaxY)
            {
                throw new BeyondBoundaryException("can not move beyond the down boundary!");
            }
            coord.Y++;
        }
        public override Coordinate GetExpectedResult(Coordinate coord)
        {
            coord.Y++;
            return coord;
        }
    }
    public class CommandLeft : CommandOrientation,IHorizontalOrientation
    {
        public override void Execute(ref Coordinate coord)
        {
            if (coord.X == 0)
            {
                throw new BeyondBoundaryException("can not move beyond the left boundary!");
            }
            coord.X--;
        }
        public override Coordinate GetExpectedResult(Coordinate coord)
        {
            coord.X--;
            return coord;
        }
    }
    public class CommandRight : CommandOrientation,IHorizontalOrientation
    {
        public override void Execute(ref Coordinate coord)
        {
            if (coord.X == Coordinate.MaxX)
            {
                throw new BeyondBoundaryException("can not move beyond the right boundary!");
            }
            coord.X++;
        }
        public override Coordinate GetExpectedResult(Coordinate coord)
        {
            coord.X++;
            return coord;
        }
    }
}
