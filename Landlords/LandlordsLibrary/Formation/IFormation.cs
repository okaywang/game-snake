using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordsLibrary.Formation
{
    public interface IFormation
    {
        string Name { get; }
        int Weight { get; }
    }
}
