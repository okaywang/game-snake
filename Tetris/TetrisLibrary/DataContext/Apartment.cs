using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;

namespace TetrisLibrary.DataContext
{
    public class Apartment
    {
        private readonly Floor[] _floors;
        private int _topIndex;

        public Apartment(Floor[] floors)
        {
            _floors = floors;
        }

        public bool HasBarrier(TetrominoBase tetromino, int floorIndex, int roomIndex)
        {
            if (_topIndex <= floorIndex)
            {
                return false;
            }
            var data = tetromino.GetDataUpward();
            foreach (var item in data)
            {
                var startRoomIndex = roomIndex;
                var roomCount = 0;
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i])
                    {
                        roomCount++;
                    }
                    else
                    {
                        startRoomIndex++;
                    }
                }
                _floors[floorIndex].HasAdjacentRooms(startRoomIndex, roomCount);
            }
            return true;
        }

        public void Reside(TetrominoBase tetromino, int floorIndex, int roomIndex)
        {
            var data = tetromino.GetDataUpward();
            foreach (var item in data)
            {
                Reside(item, tetromino.ForeColor, floorIndex, roomIndex);
                floorIndex++;
            }
        }

        private void Reside(bool[] mixedBlocks, Color skinColor, int floorIndex, int roomIndex)
        {
            var startRoomIndex = roomIndex;
            var adjacentBlock = new List<Block>();
            for (int i = 0; i < mixedBlocks.Length; i++)
            {
                if (mixedBlocks[i])
                {
                    adjacentBlock.Add(new Block(skinColor));
                }
                else
                {
                    startRoomIndex++;
                }
            }
            _floors[floorIndex].Reside(adjacentBlock, startRoomIndex);
        }
    }
}
