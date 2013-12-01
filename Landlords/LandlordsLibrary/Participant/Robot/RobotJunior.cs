using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Participant.Robot
{
    public class RobotJunior : Player, IRobot
    { 
        public RobotJunior(string name)
            :base(name)
        { 
        }

        public Formation.IFormation TakeOut()
        {
            return new Formation.FormationSingle(this.Cards.First());
        }

        public Formation.IFormation Follow(DataContext.RoundInfo round)
        {
            if (round.Formation is Formation.FormationSingle)
            {
                var flg = this.Cards.Any(c => c.WeightValue > round.Formation.Weight);
                if (flg)
                {
                    return new Formation.FormationSingle(this.Cards.Last(c => c.WeightValue > round.Formation.Weight));
                }
            }
            return null;
        }
    }
}
