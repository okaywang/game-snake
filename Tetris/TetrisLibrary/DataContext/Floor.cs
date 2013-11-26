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
        }

        public bool IsFull
        {
            get { return _rooms.Length == _residentCount; }
        }

        public bool HasAdjacentRooms(int fromRoomIndex, int roomCount)
        {
            for (int i = 0; i < roomCount; i++)
            {
                if (_rooms[fromRoomIndex++].HasResident)
                {
                    return false;
                }
            }
            return true;
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

        public void Reside(ICollection<Block> blocks, int roomIndex)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (_rooms[roomIndex + i].HasResident)
                {
                    throw new InvalidCrowdResidenceException("can not arrange the crowd with consecutive rooms at this floor.");
                }
            }

            for (int i = 0; i < blocks.Count; i++)
            {
                _rooms[roomIndex + i].Reside(blocks.ElementAt(i));
            }

            _residentCount += blocks.Count;
        }
    }
}
