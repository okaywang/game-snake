using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public class SnakeGameSettings : SimpleGame.GameSettingsBase
    {
        private static SnakeGameSettings _instance = new SnakeGameSettings();

        public SnakeGameSettings Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
