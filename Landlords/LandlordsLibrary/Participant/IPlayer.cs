using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Participant
{
    public interface IPlayer
    {
        string Name { get; }
        bool IsBanker { get; }
        List<Card> Cards { get; }
        bool IsPrepared { get; set; }
        //bool RoundToken { get; set; }

        void DrawCard(Card card);
        void DrawCards(List<Card> cards);

        void TakeOff(IFormation cards);
        IFormation Track(IFormation cards,IPlayer player);
        void Passby();
        IFormation NewRound_TakeOut();

        void Review();

        bool ActAsLandlords();

        void GainBonus(Card card1, Card card2, Card card3);
         
        void ExpelFormation(IFormation formation);
    }
}
