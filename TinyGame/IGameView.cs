using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    public interface IGameView
    {
        void RenderMap(int rowCount,int columnCount);
        void RenderScence(IDataModel model);
    }
}
