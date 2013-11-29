using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary
{
    public class Block:ICloneable
    {

        private Color _color;
        public Block(Color color)
        {
            _color = color;
        }

        public Color ForeColor
        {
            get { return _color; }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
