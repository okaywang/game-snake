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
    public partial class MainWindow : Window
    {
        private Snake _snake;
        private Direction _direction = Direction.Down;
        public MainWindow()
        {
            InitializeComponent();


            var segment1 = new Segment();
            segment1.Poisition = new Coordinate() { X = 2, Y = 2 };
            var segment2 = new Segment();
            segment2.Poisition = new Coordinate() { X = 2, Y = 3 };
            var segment3 = new Segment();
            segment3.Poisition = new Coordinate() { X = 2, Y = 4 };
            var segment4 = new Segment();
            segment4.Poisition = new Coordinate() { X = 3, Y = 4 };

            var segs = new List<Segment>() { segment1, segment2, segment3, segment4 };
            _snake = new Snake(segs);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            opRegion.SetDimension(10, 10);

            RenderSnake(_snake);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(AA));
        }

        private void AA()
        {
            opRegion.Children.Clear();
            _snake.Move(_direction);
            RenderSnake(_snake);
        }



        private void RenderSnake(Snake snake)
        {
            snake.Segments.ForEach(s => this.RenderSegement(s));
        }

        private void RenderSegement(Segment segment)
        {
            this.RenderShape(segment.Shape, segment.Poisition);
        }

        private void RenderShape(Rectangle rect, Coordinate coord)
        {
            opRegion.Children.Add(rect);
            Grid.SetRow(rect, coord.Y);
            Grid.SetColumn(rect, coord.X);
        }

        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                _direction = Direction.Up;
            }
            else if (e.Key == Key.Right)
            {
                _direction = Direction.Right;

            }
            else if (e.Key == Key.Down)
            {
                _direction = Direction.Down;

            }
            else if (e.Key == Key.Left)
            {
                _direction = Direction.Left;
            }
        }

    }
}
