using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandlordsLibrary.ArtificialIntelligence
{
    public interface AIBase
    {
        void DrawPokers(Card poker);
        void DrawPokers(List<Card> pokers);
        
        void Passby();
        void Fight(List<Card> pokers);

        void ActLandlords(List<Card> pokers);
    }
}
