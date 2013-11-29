using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandlordsLibrary.ArtificialIntelligence
{
    public class AI1
    {
        private List<Poker> _pokers;

        public AI1()
        {
            _pokers = new List<Poker>();
        }

        //摸牌
        public void DrawPokers(Poker poker)
        {
            _pokers.Add(poker);
        }

        //摸牌
        public void DrawPokers(List<Poker> pokers)
        {
            _pokers.AddRange(pokers);
        }



        //弃牌
        public void Discard()
        { 
        
        }

    }
}
