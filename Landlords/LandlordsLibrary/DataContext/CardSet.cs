using LandlordsLibrary.Formation;
using LandlordsLibrary.Participant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.DataContext
{
    public class CardSet
    {
        public IPlayer Player { get; set; }
        public IFormation Cards { get; set; }
    }
}
