using BasicLibrary.DataStructure;
using LandlordsLibrary.DataContext;
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

        void DesireLandlords(CircularlyLinkedNode<IPlayer> player);

        void TakeOutCardsCommand(CircularlyLinkedNode<IPlayer> player);

        void FollowCardsCommand(CircularlyLinkedNode<IPlayer> player, RoundInfo roundInfo);
    }
}
