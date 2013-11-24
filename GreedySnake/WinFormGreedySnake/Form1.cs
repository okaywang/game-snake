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

        public Action StartRequest;
        public Action PauseRequest;
        public Action ResetRequest;
        public Action StopRequest;
        public Action<Keys> OrientationReqest;

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
            var g = this.pnlGame.CreateGraphics();
            g.Clear(this.BackColor);
            RenderSnake(m.Snake);
            RenderFood(m.Food);
        }

        public void RenderSnake(Snake snake)
        {
            PaintBlock(snake.Head.Segment.Poisition);
            snake.Body.Segments.ForEach(s => PaintBlock(s.Poisition));
        }

        private Rectangle GetFoodRect(Coordinate coor)
        {
            return new Rectangle(coor.X * _blockWidth, coor.Y * _blockHeight, _blockWidth, _blockHeight);
        }

        public void RenderFood(Food food)
        {
            PaintBlock(food.Position);
        }

        public void ClearObjects()
        {
            var g = this.pnlGame.CreateGraphics();
            g.Clear(this.BackColor);
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
 
            //_gameMediator.ResetGame();
            this.StartRequest();
            this.btnPause.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            OrientationReqest(e.KeyCode);
            //_gameMediator.InterpreterKey(e.KeyCode);
        }

    }
}
