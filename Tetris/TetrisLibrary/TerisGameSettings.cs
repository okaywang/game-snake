using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary.DataContext.Tetromino;

namespace TetrisLibrary
{
    public class TerisGameSettings : GameSettingsBase
    {
        public TetrominoFactoryBase TetrominoFactory { get; set; }
    }
}
