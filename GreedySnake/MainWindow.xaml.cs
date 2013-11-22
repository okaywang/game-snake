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
    public partial class MainWindow : Window
    {
        private Snake _snake;
        private OrientationInterpreter _orientation = new OrientationDown();
        private Timer _timer = new Timer();
        public MainWindow()
        {
            InitializeComponent();

            Coordinate.MaxX = 10;
            Coordinate.MaxY = 10;

            var segment1 = new Segment();
            segment1.Poisition = new Coordinate() { X = 2, Y = 2 };
            var segment2 = new Segment();
            segment2.Poisition = new Coordinate() { X = 2, Y = 3 };
            var segment3 = new Segment();
            segment3.Poisition = new Coordinate() { X = 2, Y = 4 };
            var segment4 = new Segment();
            segment4.Poisition = new Coordinate() { X = 2, Y = 5 };

            var head = new SnakeHead( segment4);

            var segs = new LinkedList<Segment>();
            segs.AddFirst(segment1);
            segs.AddLast(segment2);
            segs.AddLast(segment3);
            segs.AddLast(segment4);
            var body = new SnakeBody( segs);

            _snake = new Snake(head, body);
        }
        public Rectangle SegmentShape
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            opRegion.SetDimension(Coordinate.MaxY + 1, Coordinate.MaxX + 1);

            RenderSnake(_snake);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _timer.Interval = 500;
            _timer.Elapsed += timer_Elapsed;
            _timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(AA));
        }

        private void AA()
        {
            try
            {
                _snake.Creep(_orientation, _hasFood);
            }
            catch (BeyondBoundaryException ex)
            {
                _timer.Stop();
                MessageBox.Show(ex.Message);
                MessageBox.Show("game over");
                return;
            }
            catch (SelfCrashedException ex)
            {
                _timer.Stop();
                MessageBox.Show(ex.Message);
                MessageBox.Show("game over");
                return;
            }
            _hasFood = false;

            opRegion.Children.Clear();
            RenderSnake(_snake);
        }

        private void RenderSnake(Snake snake)
        {
            this.RenderSegement(snake.Head.Segment);
            snake.Body.Segments.ForEach(s => this.RenderSegement(s));
        }

        private void RenderSegement(Segment segment)
        {
            this.RenderShape(SegmentShape, segment.Poisition);
        }

        private void RenderShape(Rectangle rect, Coordinate coord)
        {
            opRegion.Children.Add(rect);
            Grid.SetRow(rect, coord.Y);
            Grid.SetColumn(rect, coord.X);
        }

        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && _orientation.GetType() != typeof(OrientationDown))
            {
                _orientation = new OrientationUp();
            }
            else if (e.Key == Key.Right && _orientation.GetType() != typeof(OrientationLeft))
            {
                _orientation = new OrientationRight();
            }
            else if (e.Key == Key.Down && _orientation.GetType() != typeof(OrientationUp))
            {
                _orientation = new OrientationDown();
            }
            else if (e.Key == Key.Left && _orientation.GetType() != typeof(OrientationRight))
            {
                _orientation = new OrientationLeft();
            }
        }
        private bool _hasFood;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var food = new Food();
            _hasFood = true;
        }

    }
}
