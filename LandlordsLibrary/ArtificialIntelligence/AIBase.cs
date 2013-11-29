using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandlordsLibrary.ArtificialIntelligence
{
    public interface AIBase
    {
        void DrawPokers(Poker poker);
        void DrawPokers(List<Poker> pokers);
        
        void Passby();
        void Fight(List<Poker> pokers);

        void ActLandlords(List<Poker> pokers);
    }
}
