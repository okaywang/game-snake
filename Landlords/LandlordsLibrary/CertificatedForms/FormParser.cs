using LandlordsLibrary.DataContext;
using LandlordsLibrary.Formation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.CertificatedForms
{
    public class FormParser
    {
        private static Dictionary<int, IEnumerable<ICertification>> dicts = new Dictionary<int, IEnumerable<ICertification>>();

        static FormParser()
        {
            dicts.Add(1, new List<ICertification>() { new SoleForm() });
            dicts.Add(2, new List<ICertification>() { new DoubleForm(), new BombKingForm() });
            dicts.Add(3, new List<ICertification>() { new ThreeForm() });
            dicts.Add(4, new List<ICertification>() { new ThreeWithSole(), new BombCivilianForm() });
            dicts.Add(5, new List<ICertification>() { new FlowSingleForm(), new ThreeWithDouble() });
            dicts.Add(6, new List<ICertification>() { new FlowSingleForm(), new FourWithTwoSoleForm(), new FlowPairForm(), new FlowThreeForm() });
            dicts.Add(7, new List<ICertification>() { new FlowSingleForm() });
            dicts.Add(8, new List<ICertification>() { new FlowSingleForm(), new FourWithTwoPair(), new FlowPairForm(), new FlowThreeWithSole() });
            dicts.Add(9, new List<ICertification>() { new FlowSingleForm(), new FlowThreeForm() });
            dicts.Add(10, new List<ICertification>() { new FlowSingleForm(), new FlowPairForm(), new FlowThreeWithPair() });
            dicts.Add(11, new List<ICertification>() { new FlowSingleForm() });
            dicts.Add(12, new List<ICertification>() { new FlowSingleForm(), new FlowPairForm(), new FlowThreeWithSole() });
            //dicts.Add(13, null);
            dicts.Add(14, new List<ICertification>() { new FlowPairForm() });
            dicts.Add(15, new List<ICertification>() { new FlowThreeForm(), new FlowThreeWithPair() });
            dicts.Add(16, new List<ICertification>() { new FlowPairForm(), new FlowThreeWithSole() });
            //dicts.Add(17, null);
            dicts.Add(18, new List<ICertification>() { new FlowPairForm(), new FlowThreeForm() });
            //dicts.Add(19, null);
            dicts.Add(20, new List<ICertification>() { new FlowPairForm(), new FlowThreeWithSole(), new FlowThreeWithPair() });

        }

        public static IFormation Parse(List<Card> cards)
        {
            var certs = dicts[cards.Count];
            foreach (var item in certs)
            {
                if (item.IsValid(cards))
                {
                    return item.Parse(cards);
                }
            }
            return null;
        }

    }
}
