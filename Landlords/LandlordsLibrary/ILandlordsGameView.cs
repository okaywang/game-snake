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
        IPlayer Player { get; }
        IPlayer PlayerLeft { get; }
        IPlayer PlayerRight { get; }

        void Init();

        void RepresentDistributeCards();

        //challenge landlords 
        void ArrangeActLandlordsActionPrelude(IPlayer specifiedPlayer);
        void DiscardLandlordsAction();
        void ActLandlordsAction();
        void ArrangeActLandlordsActionPostlude(IPlayer specifiedPlayer, Card card1, Card card2, Card card3);

        //piston motion repeatedly
        void ArrangleBringFormationPrelude(IPlayer specifiedPlayer);
        void ArrangeFollowFormationPrelude(IPlayer specifiedPlayer, RoundInfo roundInfo);
        void ThrowFormationAction(IPlayer specifiedPlayer,IFormation formation);
        void PlayerPassbyAction(IPlayer specifiedPlayer);
        void ArrangeFormationRoundPostlude(IPlayer specifiedPlayer);
    }
}
