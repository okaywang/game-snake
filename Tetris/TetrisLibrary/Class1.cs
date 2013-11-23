using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public interface ITetrisView:IGameView
    {
        void RenderMap(int rowCount, int columnCount);
    }
}
