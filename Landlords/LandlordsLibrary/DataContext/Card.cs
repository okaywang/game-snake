﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandlordsLibrary.DataContext
{
    public struct Card
    {
        //public   readonly Card Empty = new Card(-1, -1);

        private int _code;
        private int _weight;
        internal Card(int code, int weight)
            : this()
        {
            _code = code;
            _weight = weight;
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
                return _weight;

            }
        }

        public CardTypes PokerType
        {
            get { return (CardTypes)(_code / 13); }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", PokerType, LiteralValue);
        }

        public static bool operator ==(Card card1, Card card2)
        {
            return card1.Code == card2.Code;
        }
        public static bool operator !=(Card card1, Card card2)
        {
            return card1.Code != card2.Code;
        }
    }

    public class CardCarton
    {
        private static int[] _codes = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 
                                   13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
                                   26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38,
                                   39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 
                                   52, 53 };
        private static int[] _weights = { 11, 13, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 
                                     11, 13, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                     11, 13, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 
                                     11, 13, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 
                                     (int)CardWeights.Queen,(int)CardWeights.King };
        private static Card[] _cards = new Card[54];
        static CardCarton()
        {
            for (int i = 0; i < 54; i++)
            {
                _cards[i] = new Card(_codes[i], _weights[i]);
            }
        }

        public static Card Get(int code)
        {
            return _cards[code];
        }
    }
}
