using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandlordsLibrary.DataContext
{
    public class Poker
    {
        private int[] _weights = { 3, 2 };
        private int _code;
        public Poker(int code)
        {
            _code = code;
        }

        public int Code
        {
            get { return _code; }
        }

        public int LiteralValue
        {
            get
            {
                return _code % 13 + 1;
            }
        }

        public int WeightValue
        {
            get
            {
                if (_code == 52)
                {
                    return (int)CardWeights.Queen;
                }
                else if (_code == 53)
                {
                    return (int)CardWeights.King;
                }
                var index = _code % 13;
                return (int)(CardWeights)(Enum.GetValues(typeof(CardWeights)).GetValue(index));

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
