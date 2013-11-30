using BasicLibrary;
using BasicLibrary.DataStructure;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandlordsLibrary.DataContext
{
    public class Referee
    {
        private Card[] _pokers;

        private CircularlyLinkedList<IPlayer> _players;

        public Referee(CircularlyLinkedList<IPlayer> players)
        {
            _pokers = new Card[54];
            for (int i = 0; i < 54; i++)
            {
                _pokers[i] = CardCarton.Get(i);
            }

            _players = players;
        }

        public void Shuffle()
        {
            var rnd = Miscellanea.GetUnrepeatableRandom(54);
            for (int i = 0; i < 54; i++)
            {
                _pokers[i] = CardCarton.Get(rnd[i]);
            }
        }

        public void DistributeCards()
        {
            var player = _players.Current;
            for (int i = 0; i < 50; i += 3)
            {
                player.Value.DrawPokers(_pokers[i]);
                player.Next.Value.DrawPokers(_pokers[i + 1]);
                player.Next.Next.Value.DrawPokers(_pokers[i + 2]);
            }
        }


    }
}
