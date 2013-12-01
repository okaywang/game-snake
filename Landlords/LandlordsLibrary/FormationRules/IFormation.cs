using LandlordsLibrary.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public interface IFormation
    {
        string Signature { get; }
        int Weight { get; }

        Card[] Cards { get; }
    }
}
