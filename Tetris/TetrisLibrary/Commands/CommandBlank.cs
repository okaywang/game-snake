using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary.Commands
{
    public class CommandBlank : CommandOrientation
    {
        public override void Execute(ref Coordinate coord)
        {
            throw new NotImplementedException();
        }

        public override Coordinate GetExpectedResult(Coordinate coord)
        {
            throw new NotImplementedException();
        }
    }
}
