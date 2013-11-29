using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandlordsLibrary.DataContext
{
    public class Poker
    {
        private int _code;
        public Poker(int code)
        {
            _code = code;
        }

        public int LiteralValue
        {
            get
            {
                return _code % 13 + 1;
            }
        }

        public PokerTypes PokerType
        {
            get { return (PokerTypes)(_code / 13); }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", PokerType, LiteralValue);
        }
    }
}
