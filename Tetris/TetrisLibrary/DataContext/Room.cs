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
        private Block _block ;
         
        private bool _hasResident;
        public bool HasResident
        {
            get { return _hasResident; }
        }

        public Block Resident
        {
            get { return _block; }
        }

        public void Reside(Block block)
        {
            if (_hasResident)
            {
                throw new InvalidResidenceException("room has been occupied, can not reside.");
            }
            _hasResident = true;
            _block = block;
        }

        public void Remove()
        {
            _hasResident = false;
            _block = null;
        }
    }
}
