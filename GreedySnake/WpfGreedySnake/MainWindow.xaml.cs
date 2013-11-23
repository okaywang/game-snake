using GreedySnakeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfGreedySnake;

namespace GreedySnake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISnakeGameView
    {
        private GameMediator _gameMediator;
        public MainWindow()
        {
            InitializeComponent();
            _gameMediator = new GameMediator(this);
            _gameMediator.BeyondBoundary += GameOver;
            _gameMediator.SelfCrash += GameOver;
            _gameMediator.InitGame();

            this.btnPause.IsEnabled = false;
            this.btnRestart.IsEnabled = false;
        } 

        void GameOver(object sender, SnakeGameEvent e)
        {
            Dispatcher.Invoke(new Action(() => {
                MessageBox.Show(e.Message);
                this.btnPause.IsEnabled = false;
                this.btnRestart.IsEnabled = true;
            }));
        }

        public void RenderMap(int rowCount, int columnCount)
        {
            opRegion.SetDimension(rowCount, columnCount);
        }


        private Rectangle SegmentShape
        {
            get
            {
                var rect = new Rectangle();
                rect.Width = 20;
                rect.Height = 20;
                rect.Fill = Brushes.Silver;
                return rect;
            }
        }
        private Rectangle FoodShape
        {
            get
            {
                var rect = new Rectangle();
                rect.Width = 15;
                rect.Height = 15;
                rect.Fill = Brushes.Green;
                return rect;
            }
        }
         

        public void ClearObjects()
        {
            Dispatcher.Invoke(new Action(() => { opRegion.Children.Clear(); }));
        }
        
        public void RenderFood(Food food)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                PaintShape(FoodShape, food.Position);
            }));
        }

        public void RenderSnake(Snake snake)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                this.PaintSegement(snake.Head.Segment);
                snake.Body.Segments.ForEach(s => this.PaintSegement(s));
            }));
        }

        private void PaintSegement(Segment segment)
        {
            this.PaintShape(SegmentShape, segment.Poisition);
        }

        private void PaintShape(Rectangle rect, Coordinate coord)
        {
            opRegion.Children.Add(rect);
            Grid.SetRow(rect, coord.Y);
            Grid.SetColumn(rect, coord.X);
        }

        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            //_gameMediator.InterpreterKey(e.Key);

           
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            _gameMediator.Pause();
            this.btnPause.IsEnabled = false;
            this.btnStart.IsEnabled = true;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _gameMediator.BeginGame();
            this.btnStart.IsEnabled = false;
            this.btnPause.IsEnabled = true;
            this.btnRestart.IsEnabled = false;
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            _gameMediator.ResetGame();
            _gameMediator.BeginGame();
            this.btnPause.IsEnabled = true;
            this.btnRestart.IsEnabled = false;
        }



    }
}
