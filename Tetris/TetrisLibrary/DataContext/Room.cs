using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary.DataContext
{
    public struct Room
    {
        private Block _block;

        public bool HasResident
        {
            get { return _block != Block.Empty; }
        }

        public void Reside(Block block)
        {
            if (HasResident)
            {
                throw new InvalidResidenceException("room has been occupied, can not reside.");
            }
            _block = block;
        }

        public void Remove()
        {
            _block = Block.Empty;
        }
    }
}
