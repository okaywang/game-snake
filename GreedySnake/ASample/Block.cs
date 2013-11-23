using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 贪吃蛇
{
    class Block
    {
        private Color Sncolor;//颜色
        private int Snsize;//大小
        private Point Snpoint;//位置

        public Block(Color color, int size, Point p)
        {
            this.Sncolor = color;
            this.Snsize =size;
            this.Snpoint = p;
        }

        public Point Point
        {
            get { return this.Snpoint; }
        }

        //绘制自身到画布
        public virtual void Paint(Graphics g)
        {
            SolidBrush sb=new SolidBrush(Sncolor);
            lock(g)
            {
                try
                {
                    g.FillRectangle(sb,this.Point.X*this.Snsize,this.Point.Y*this.Snsize,this.Snsize-1,this.Snsize-1);
                }
                catch
                {
                }
            }
        }
    }
}
