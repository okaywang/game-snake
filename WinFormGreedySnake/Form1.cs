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
    public partial class Form1 : Form, ISnakeGameUI
    {
        private GameMediator _gameMediator;

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

            _gameMediator = new GameMediator(this);
            _gameMediator.BeyondBoundary += GameOver;
            _gameMediator.SelfCrash += GameOver;
            _gameMediator.InitGame();

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

        public void PaintMap(int rowCount, int columnCount)
        {
            _blockHeight = this.pnlGame.Height / rowCount;
            _blockWidth = this.pnlGame.Width / columnCount;
            PaintGrid(rowCount,columnCount);
        }

        public void PaintSnake(Snake snake)
        {
            PaintBlock(snake.Head.Segment.Poisition);
            snake.Body.Segments.ForEach(s => PaintBlock(s.Poisition));
        }

        private Rectangle GetFoodRect(Coordinate coor)
        {
            return new Rectangle(coor.X * _blockWidth, coor.Y * _blockHeight, _blockWidth, _blockHeight);
        }

        public void PaintFood(Food food)
        {
            PaintBlock(food.Position);
        }

        private void PaintBlock(Coordinate pos)
        {
            var rect = this.GetFoodRect(pos);
            g.FillRectangle(Brushes.Silver, rect);
        }

        public void ClearObjects()
        {
            g.Clear(this.BackColor);
            //PaintGrid(10, 10);
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
            _gameMediator.BeginGame();
            this.btnStart.Enabled = false;
            this.btnPause.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            _gameMediator.ResetGame();
            _gameMediator.BeginGame();
            this.btnPause.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _gameMediator.InterpreterKey(e.KeyCode);
        } 

    }
}
