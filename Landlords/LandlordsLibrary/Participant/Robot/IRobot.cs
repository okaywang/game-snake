using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Participant.Robot
{
    public interface IRobot
    {
        Formation.IFormation TakeOut();
        IFormation Follow(RoundInfo round);
    }
}
