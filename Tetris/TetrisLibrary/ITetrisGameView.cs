using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public interface ITetrisGameView : IGameView
    {
        //void RenderSnake(Snake snake);
        //void RenderFood(Food food);
        void ClearObjects();

        Action StartRequest { set; }
        Action PauseRequest { set; }
        Action ResetRequest { set; }
        Action StopRequest { set; }
        Action<CommandOrientation> OrientationReqest { set; }
    }
}
