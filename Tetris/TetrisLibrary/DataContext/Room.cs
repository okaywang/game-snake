using BasicLibrary;
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
            get { return _block != null; }
        }

        public Block Resident
        {
            get { return _block; }
            set
            {
                if (value == null)
                {
                    this.Clear();
                }
                else
                {
                    _block = value;
                }
            }
        }

        public void Reside(Block block)
        {
            if (HasResident)
            {
                throw new InvalidResidenceException("room has been occupied, can not reside.");
            }
            _block = block;
        }

        public void Substitute(Block block)
        {
            if (block == null)
            {
                this.Clear();
            }
            else
            {
                _block = block;
            }
        }

        public void Clear()
        {
            _block = null;
        }
    }
}
