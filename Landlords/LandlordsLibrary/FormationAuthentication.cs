using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary
{
    public class FormationAuthentication
    {

        public IFormation Authenticate(List<int> codes)
        {
            if (codes.Count == 1)
            {
                return new FormationSingle(new Poker(codes[0]));
            }
            else if (codes.Count == 2)
            {
                if (codes[0] == codes[1])
                {
                    return new FormationPair(new Poker[] { new Poker(codes[0]), new Poker(codes[1]) });
                }
                else if (codes[0] == 52 && codes[1] == 53)
                {
                    return new FormationBomb();
                }
                else
                {
                    return null;
                }
            }
            else if (codes.Count == 3)
            {
                if (codes[0] == codes[1] && codes[1] == codes[2])
                {
                    return new FormationThree(new Poker[] { new Poker(codes[0]), new Poker(codes[1]), new Poker(codes[2]) }, null);
                }
                else
                {
                    return null;
                }
            }
            else if (codes.Count == 4)
            {
                if (codes[0] == codes[1] && codes[1] == codes[2] && codes[2] == codes[3])
                {
                    var fFour = new FormationFour(new Poker[] { new Poker(codes[0]), new Poker(codes[1]), new Poker(codes[2]), new Poker(codes[3]) }, null, null);
                    return new FormationBomb(fFour);
                }
                if ((codes[0] == codes[1] && codes[1] == codes[2]) && codes[2] != codes[3])
                {
                    return new FormationThree(new Poker[] { new Poker(codes[0]), new Poker(codes[1]), new Poker(codes[2]) }, new FormationSingle(new Poker(codes[3])));
                }
                if (codes[0] != codes[1] && (codes[1] == codes[2] && codes[2] == codes[3]))
                {
                    return new FormationThree(new Poker[] { new Poker(codes[1]), new Poker(codes[2]), new Poker(codes[3]) }, new FormationSingle(new Poker(codes[0])));
                }
            }
            else if (codes.Count == 5)
            {

            }
            return null;
        }
    }
}
