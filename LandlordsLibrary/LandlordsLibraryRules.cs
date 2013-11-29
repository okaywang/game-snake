using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandlordsLibrary
{
    public class LandlordsLibraryRules
    {
        public static int Compare_SingleCard(Poker p1, Poker p2)
        {
            return GetWeight(p1) - GetWeight(p2);
        }

        private static int GetWeight(Poker p)
        {
            switch (p.PokerType)
            {
                case PokerTypes.King:
                    return p.LiteralValue + 100;
                default:
                    if (p.LiteralValue == 1)
                    {
                        return 20;
                    }
                    if (p.LiteralValue == 2)
                    {
                        return 30;
                    }
                    return p.LiteralValue;
            }
        }
    }
}
