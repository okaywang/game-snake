using BasicLibrary;
using BasicLibrary.DataStructure;
using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandlordsLibrary.Participant
{
    public class Servant
    { 
        public static void Shuffle(Card[] cards)
        {
            var rnd = Miscellanea.GetUnrepeatableRandom(54);
            for (int i = 0; i < 54; i++)
            {
                cards[i] = CardCarton.Get(rnd[i]);
            }
        }
        
        public static void DistributeCards(Card[] cards, CircularlyLinkedNode<IPlayer> player)
        {
            for (int i = 0; i < 50; i += 3)
            {
                player.Value.DrawCard(cards[i]);
                player.Next.Value.DrawCard(cards[i + 1]);
                player.Next.Next.Value.DrawCard(cards[i + 2]);
            }
        }


    }
}
