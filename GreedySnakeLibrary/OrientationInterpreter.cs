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
    public abstract class OrientationInterpreter
    {
        public abstract void Interpret(ref Coordinate coord);

        public abstract Coordinate GetExpectedPosition(Coordinate coord);
    }

    public class OrientationUp : OrientationInterpreter
    {
        public override void Interpret(ref Coordinate coord)
        {
            if (coord.Y == 0)
            {
                throw new BeyondBoundaryException("can not move beyond the up boundary!");
            }
            coord.Y--;
        }

        public override Coordinate GetExpectedPosition(Coordinate coord)
        {
            coord.Y--;
            return coord;
        }
    }
    public class OrientationDown : OrientationInterpreter
    {
        public override void Interpret(ref Coordinate coord)
        {
            if (coord.Y == Coordinate.MaxY)
            {
                throw new BeyondBoundaryException("can not move beyond the down boundary!");
            }
            coord.Y++;
        }
        public override Coordinate GetExpectedPosition(Coordinate coord)
        {
            coord.Y++;
            return coord;
        }
    }
    public class OrientationLeft : OrientationInterpreter
    {
        public override void Interpret(ref Coordinate coord)
        {
            if (coord.X == 0)
            {
                throw new BeyondBoundaryException("can not move beyond the left boundary!");
            }
            coord.X--;
        }
        public override Coordinate GetExpectedPosition(Coordinate coord)
        {
            coord.X--;
            return coord;
        }
    }
    public class OrientationRight : OrientationInterpreter
    {
        public override void Interpret(ref Coordinate coord)
        {
            if (coord.X == Coordinate.MaxX)
            {
                throw new BeyondBoundaryException("can not move beyond the right boundary!");
            }
            coord.X++;
        }
        public override Coordinate GetExpectedPosition(Coordinate coord)
        {
            coord.X++;
            return coord;
        }
    }
}
