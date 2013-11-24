using GreedySnakeLibrary;
using SimpleGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using WinFormControls;

namespace WinFormGreedySnake
{
    public partial class Form1 : Form, ISnakeGameView
    {
        private int _blockHeight = 10;
        private int _blockWidth = 10;

        public SnakeGameModel Model;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.btnPause.Enabled = false;
            this.btnRestart.Enabled = false;
            //this.pnlGame.BackColor = Color.Transparent;
        }

        public void GameOver(object sender, SnakeGameEvent e)
        {
            this.Invoke(new Action(() =>
            {
                MessageBox.Show(e.Message);
                this.btnPause.Enabled = false;
                this.btnRestart.Enabled = true;
            }));
        }

        public void RenderMap(int rowCount, int columnCount)
        {
            _blockHeight = this.pnlGame.Height / rowCount;
            _blockWidth = this.pnlGame.Width / columnCount;
            PaintGrid(rowCount,columnCount);
        }

        public void RenderScence(IDataModel model)
        {
            var m = model as SnakeGameModel;
            ClearObjects();
            RenderSnake(m.Snake);
            RenderFood(m.Food);
        }

        public void ClearObjects()
        {
            var g = this.pnlGame.CreateGraphics();
            g.Clear(this.BackColor);
        }

        public void RenderSnake(Snake snake)
        {
            PaintBlock(snake.Head.Segment.Poisition);
            snake.Body.Segments.ForEach(s => PaintBlock(s.Poisition));
        }
        
        public void RenderFood(Food food)
        {
            PaintBlock(food.Position);
        }

        private Action _actionStart;
        public Action StartRequest
        {
            set { _actionStart = value; }
            protected get { return _actionStart; }
        }

        private Action _actionPause;
        public Action PauseRequest
        {
            set { _actionPause = value; }
            protected get { return _actionPause; }
        }

        private Action _actionReset;
        public Action ResetRequest
        {
            set { _actionReset = value; }
            protected get { return _actionReset; }
        }

        private Action _actionStop;
        public Action StopRequest
        {
            set { _actionStop = value; }
            protected get { return _actionStop; }
        }

        private Action<CommandOrientation> _actionOrientate;
        public Action<CommandOrientation> OrientationReqest
        {
            set { _actionOrientate = value; }
            protected get { return _actionOrientate; }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this.PauseRequest();
            this.btnPause.Enabled = false;
            this.btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.StartRequest();
            this.btnStart.Enabled = false;
            this.btnPause.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.ResetRequest();
            this.StartRequest();
            this.btnPause.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    OrientationReqest(new CommandUp());
                    break;
                case Keys.Down:
                    OrientationReqest(new CommandDown());
                    break;
                case Keys.Left:
                    OrientationReqest(new CommandLeft());
                    break;
                case Keys.Right:
                    OrientationReqest(new CommandRight());
                    break;
                default:
                    break;
            }
        }

        private Rectangle GetFoodRect(Coordinate coor)
        {
            return new Rectangle(coor.X * _blockWidth, coor.Y * _blockHeight, _blockWidth, _blockHeight);
        }

        private void PaintBlock(Coordinate pos)
        {
            var rect = this.GetFoodRect(pos);
            var g = this.pnlGame.CreateGraphics();
            g.FillRectangle(Brushes.Silver, rect);
        }

        //how to avoid twinkle
        private void PaintGrid(int rowCount,int columnCount)
        {
            WinFormHelper.DrawGrid(this.pnlGame, rowCount, columnCount);
        }


    }
}
