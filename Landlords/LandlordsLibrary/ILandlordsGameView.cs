using BasicLibrary.DataStructure;
using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using LandlordsLibrary.Participant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary
{
    public interface ILandlordsGameView
    {
        void Init(CircularlyLinkedNode<IPlayer> player);

        void RepresentDistributeCards(CircularlyLinkedNode<IPlayer> player);

        //challenge landlords 
        void ArrangeActLandlordsActionPrelude(CircularlyLinkedNode<IPlayer> player);
        void DiscardLandlordsAction(CircularlyLinkedNode<IPlayer> player);
        void ActLandlordsAction(CircularlyLinkedNode<IPlayer> player);
        void ArrangeActLandlordsActionPostlude(CircularlyLinkedNode<IPlayer> player, Card card1, Card card2, Card card3);

        //piston motion repeatedly
        void ArrangleBringFormationPrelude(CircularlyLinkedNode<IPlayer> player);
        void ArrangeFollowFormationPrelude(CircularlyLinkedNode<IPlayer> player, RoundInfo roundInfo);
        void ThrowSelectedFormationAction(CircularlyLinkedNode<IPlayer> player, IFormation formation);
        void PlayerPassbyAction(CircularlyLinkedNode<IPlayer> player);
        void ArrangeFormationRoundPostlude(CircularlyLinkedNode<IPlayer> player);

    }
}
