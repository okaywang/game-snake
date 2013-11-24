using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeLibrary
{
    public class Segment : ICloneable
    {
        private Coordinate _poisition;
        public Coordinate Poisition
        {
            set { _poisition = value; }
            get { return _poisition; }
        }

        public void Creep(CommandOrientation orientation)
        {
            orientation.Execute(ref _poisition);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
