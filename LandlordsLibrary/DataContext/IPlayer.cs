using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.DataContext
{
    public interface IPlayer
    {
        string Name { get; }
        bool IsBanker { get; set; }

        void DrawPokers(Poker poker);
        void DrawPokers(List<Poker> pokers);

        void Passby();
        void Fight(List<Poker> pokers);

        void ActLandlords(List<Poker> pokers);
    }
}
