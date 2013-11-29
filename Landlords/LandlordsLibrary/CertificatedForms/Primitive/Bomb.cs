using BasicLibrary;
using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class BombKingForm : ICertification
    {
        public bool ICertificate(List<Poker> cards)
        {
            return Identifier.BeSameRespectively(cards, p => p.WeightValue, (int)CardWeights.Queen, (int)CardWeights.King);
        }

        public IFormation Issue(List<Poker> cards)
        {
            return new FormationBomb();
        }
    }

    public class BombCivilianForm : ICertification
    {
        public bool ICertificate(List<Poker> cards)
        {
            if (cards.Count != 4)
            {
                return false;
            }
            return Identifier.BeSame<Poker,int>(cards, p => p.WeightValue);
        }

        public IFormation Issue(List<Poker> cards)
        {
            return new FormationBomb(new FormationFour(cards.ToArray(), null, null));
        }
    }
}
