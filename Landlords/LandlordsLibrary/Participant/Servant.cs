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
        
        public static void DistributeCards(Card[] cards, CircularlyLinkedNode<ILandlordsGameView> views)
        {
            for (int i = 0; i < 50; i += 3)
            {
                views.Value.Player.DrawCard(cards[i]);
                views.Next.Value.Player.DrawCard(cards[i + 1]);
                views.Next.Next.Value.Player.DrawCard(cards[i + 2]);
            }
        }  
    }
}
