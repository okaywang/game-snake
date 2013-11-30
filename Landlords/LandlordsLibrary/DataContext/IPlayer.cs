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

        void DrawPokers(Card poker);
        void DrawPokers(List<Card> pokers);

        void Passby();
        void Fight(List<Card> pokers);

        void ActLandlords(List<Card> pokers);
    }
}
