using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
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
            : base(name)
        {
        }

        public static IFormation BringFormation(List<Card> cards)
        {
            return new Formation.FormationSingle(cards.Last());
        }

        public IFormation BringFormation()
        {
            return new Formation.FormationSingle(this.Cards.Last());
        }

        public IFormation FollowFormation(DataContext.RoundInfo round)
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
