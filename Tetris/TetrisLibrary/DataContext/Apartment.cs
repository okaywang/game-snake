using BasicLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary.DataContext.Tetromino;

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

        public int TopIndex
        {
            get { return _topIndex; }
        }

        public int FloorCount
        {
            get { return _floors.Length; }
        }

        public int UnitCount
        {
            get { return _floors[0].RoomsCount; }
        }

        public Floor this[int index]
        {
            get { return _floors[index]; }
        }

        public Block[,] GetUnderlyingData()
        {
            var colCount = _floors[0].RoomsCount;
            var data = new Block[_floors.Length, colCount];
            for (int i = 0; i <= _topIndex; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    data[i, j] = _floors[i][j].Resident;
                }
            }
            return data;
        }

        //public bool HasBarrier(TetrominoBase tetromino, int floorIndex, int roomIndex)
        //{
        //    if (_topIndex < floorIndex)
        //    {
        //        return false;
        //    }


        //    var data = tetromino.GetUnderlyingDataUpward();
        //    foreach (var item in data)
        //    {
        //        var startRoomIndex = roomIndex;
        //        var roomCount = 0;
        //        for (int i = 0; i < item.Length; i++)
        //        {
        //            if (item[i])
        //            {
        //                roomCount++;
        //            }
        //            else
        //            {
        //                if (roomCount > 0)
        //                {
        //                    break;
        //                }
        //                startRoomIndex++;
        //            }
        //        }
        //        if (roomCount == 0)
        //        {
        //            floorIndex++;
        //            continue;
        //        }
        //        else if (floorIndex < 0)
        //        {
        //            return true;
        //        }
        //        var floor = _floors[floorIndex++];
        //        var hasRoom = floor.HasAdjacentRooms(startRoomIndex, roomCount);
        //        if (!hasRoom)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public void Reside(TetrominoBase tetromino, int floorIndex, int roomIndex)
        {
            var data = tetromino.GetUnderlyingDataUpward();
            foreach (var item in data)
            {
                if (floorIndex > -1)
                { 
                    Reside(item, tetromino.ForeColor, floorIndex, roomIndex);
                }
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
                    if (adjacentBlock.Count > 0)
                    {
                        break;
                    }
                    startRoomIndex++;
                }
            }
            if (adjacentBlock.Count == 0)
            {
                return;
            }
            if (floorIndex> this.FloorCount -1)
            {
                throw new FloorUseupException("floor has been used up!");
            }
            _floors[floorIndex].Reside(adjacentBlock, startRoomIndex);
            if (floorIndex > _topIndex)
            {
                _topIndex = floorIndex;
            }
        }

        internal void GoDownstairs(int floorIndex, int count)
        {
            for (int i = floorIndex; i + count < this.FloorCount; i++)
            {
                _floors[i + count].Dump(_floors[i]);
            }
        }
    }
}
