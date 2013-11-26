using SimpleGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary.DataContext
{
    public struct Block
    {

        private Color _color;
        public Block(Color color)
            : this()
        {
            _color = color;
        }

        public static readonly Block Empty = new Block();

        private Coordinate _pos;
        public Coordinate Position
        {
            get { return _pos; }
            set { _pos = value; }
        }



        public void Descend(int rowCount)
        {
            _pos.X -= rowCount;
        }

        public static bool operator ==(Block a, Block b)
        {
            return a.Position == b.Position;
        }

        public static bool operator !=(Block a, Block b)
        {
            return a.Position != b.Position;
        }
    }
}
