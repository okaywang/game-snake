using GreedySnakeLibrary;
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
        private GameMediator2 _gameMediator;

        private int _blockHeight = 10;
        private int _blockWidth = 10;
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.pnlGame.CreateGraphics();

            var settings = new SnakeGameSettings() { RowCount = 10, ColumnCount = 20, TimerInterval = 200 };
            _gameMediator = new GameMediator2(this,settings);
            _gameMediator.BeyondBoundary += GameOver;
            _gameMediator.SelfCrash += GameOver;
            _gameMediator.Initialize();

            this.btnPause.Enabled = false;
            this.btnRestart.Enabled = false;
            //this.pnlGame.BackColor = Color.Transparent;
        }
        private void GameOver(object sender, SnakeGameEvent e)
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


        public void RenderScence()
        {
            g.Clear(this.BackColor);
            RenderSnake(_gameMediator.Snake);
            RenderFood(_gameMediator.Food);
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
            g.Clear(this.BackColor);
        }
        private void PaintBlock(Coordinate pos)
        {
            var rect = this.GetFoodRect(pos);
            g.FillRectangle(Brushes.Silver, rect);
        }

        //how to avoid twinkle
        private void PaintGrid(int rowCount,int columnCount)
        {
            WinFormHelper.DrawGrid(this.pnlGame, rowCount, columnCount);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            _gameMediator.Pause();
            this.btnPause.Enabled = false;
            this.btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _gameMediator.Start();
            this.btnStart.Enabled = false;
            this.btnPause.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
 
            //_gameMediator.ResetGame();
            _gameMediator.Start();
            this.btnPause.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _gameMediator.InterpreterKey(e.KeyCode);
        }

    }
}
