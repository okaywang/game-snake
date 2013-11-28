using BasicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary.DataContext
{
    public class Floor
    {
        private int _floorNumber;
        private int _residentCount;
        private Room[] _rooms;
        public Floor(int floorNumber, int limitedCount)
        {
            _floorNumber = floorNumber;
            _rooms = new Room[limitedCount];
        }

        public int RoomsCount
        {
            get { return _rooms.Length; }
        }

        public Room this[int index]
        {
            get { return _rooms[index]; }
            set { _rooms[index] = value; }
        }

        public bool IsFull
        {
            get { return _rooms.Length == _residentCount; }
        } 

        public void Reside(Block block, int roomIndex)
        {
            if (_rooms[roomIndex].HasResident)
            {
                throw new InvalidResidenceException("can not arrange the block at this floor.");
            }
            _rooms[roomIndex].Reside(block);
            _residentCount++;
        } 

        internal void Clear()
        {
            for (int i = 0; i < _rooms.Length; i++)
            {
                _rooms[i].Clear();
            }
            _residentCount = 0;
        }

        public void Dump(Floor floor)
        {
            floor._residentCount = this._residentCount;
            for (int i = 0; i < _rooms.Length; i++)
            {
                floor[i] = this[i];
                 
                this[i].Clear();
            }

        }
    }
}
