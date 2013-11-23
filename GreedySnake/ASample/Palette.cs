using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace 贪吃蛇
{
    class Palette
    {
        private int _width ;//画布横排能排多少蛇块
        private int _height;//画布竖排能排多少蛇块
        private Color _bgColor;//背景色
        private Graphics _gpPalette;//画布
        private ArrayList _blocks;//蛇块列表
        private Direction _direction;//方向
        private Timer timerBlock;//更新器
        private Block _food;//当前食物
        private int _size ;//蛇块大小
        private int _level;//游戏等级
        
        private int[] _speed = new int[] { 500, 250,50 };//游戏速度

        public Palette(int width, int height, int size, Color bgColor, Graphics g, int lvl)
        {
            this._width = width;
            this._height = height;
            this._bgColor = bgColor;
            this._gpPalette = g;
            this._size = size;
            this._level = lvl;
            this._blocks = new ArrayList();
            this._blocks.Insert(0,(new Block(Color.Red,this._size,new Point(1,1))));
            this._direction=Direction.Right;
        }

        public Direction Direction
        {
            get
            {
                return this._direction;
            }
            set
            {
                this._direction = value;
            }
        }

        //开始游戏
        public void start()
        {
            this._food=getFood();//得到一个食物
            //初始化计时器
            timerBlock=new System.Timers.Timer(_speed[this._level]);
            timerBlock.Elapsed+=new System.Timers.ElapsedEventHandler(OnBlockTimeEvent);
            timerBlock.AutoReset=true;
            timerBlock.Start();
        }

        //定时更新
        private void OnBlockTimeEvent(object sourse, ElapsedEventArgs e)
        {
            this.move();//前进一个单位
            if(this.CheckDead())//检查是否结束
            {
                this.timerBlock.Stop();
                this.timerBlock.Dispose();
                System.Windows.Forms.MessageBox.Show("Score:"+this._blocks.Count,"Game Over");
            }
        }
        public void Stop()
        {
            this.timerBlock.Stop();
            this.timerBlock.Dispose();           
            this._blocks.RemoveRange(0, this._blocks.Count);
            
        }

        //检查是否游戏结束
        private bool CheckDead()
        {
            Block head=(Block)(this._blocks[0]);//取蛇头
            //检查是否超出画布范围
            if(head.Point.X<0||head.Point.Y<0||head.Point.X+1>this._width||head.Point.Y+1 >this._height)
            {
                return true;
            }
            for(int i=1;i<this._blocks.Count;i++)
            {
                Block b=(Block)this._blocks[i];
                if(head.Point.X==b.Point.X&&head.Point.Y==b.Point.Y)
                {
                    return true;
                }
            }
            return false;
        }

        //生成下一个食物（方块）
        private Block getFood()
        {
            Block food=null;
            Random r=new Random();
            bool redo=false;
            while(true)
            {
                redo=false;
                int x=r.Next(this._width);
                int y=r.Next(this._height);
                for(int i=0;i<this._blocks.Count;i++)//检查食物出现位置是否和贪吃蛇重叠
                {
                    Block b=(Block)(this._blocks[i]);
                    if(b.Point.X==x&&b.Point.Y==y)//有冲突（重叠)，重新找坐标
                    {redo=true;}
                }
                if(redo==false)
                {
                    food=new Block(Color.Black,this._size,new Point(x,y));
                    break;
                }
            }
                return food;
        }

        //前进一节
        private void move()
        {                                              
            Point p;//下一个坐标位置
            Block head=(Block)this._blocks[0];
            if(this._direction==Direction.Up)
                p=new Point(head.Point.X,head.Point.Y-1);
            else if(this._direction==Direction.Down)
                p=new Point(head.Point.X,head.Point.Y+1);
            else if(this._direction==Direction.Left)
                p=new Point(head.Point.X-1,head.Point.Y);
            else 
                p=new Point(head.Point.X+1,head.Point.Y);

            //生成新坐标，将来成为蛇头
            Block b=new Block(Color.Red ,this._size,p);

            //如果下一个坐标不是食物坐标，就删除最后一个蛇块
            if(this._food.Point!=p)
                this._blocks.RemoveAt(this._blocks.Count-1);

            //如果下一个坐标和食物重合，就生成一个新食物
            else 
                this._food=this.getFood();

            //把下一个坐标插入蛇块列表第一个，使其成为蛇头 
            this._blocks.Insert(0,b);

            this.PaintPalette(this._gpPalette);//更新画板


        }

        //更新画板
        public void PaintPalette(Graphics gp)
        {
            gp.Clear(this._bgColor);
            this._food.Paint(gp);
            foreach (Block b in this._blocks)
                b.Paint(gp);
        }       

    }
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
