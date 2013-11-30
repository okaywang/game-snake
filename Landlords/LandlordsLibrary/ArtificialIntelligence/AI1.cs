using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandlordsLibrary.ArtificialIntelligence
{
    public class AI1
    {
        private List<Card> _pokers;

        public AI1()
        {
            _pokers = new List<Card>();
        }

        //摸牌
        public void DrawPokers(Card poker)
        {
            _pokers.Add(poker);
        }

        //摸牌
        public void DrawPokers(List<Card> pokers)
        {
            _pokers.AddRange(pokers);
        }



        //弃牌
        public void Discard()
        { 
        
        }

    }
}
