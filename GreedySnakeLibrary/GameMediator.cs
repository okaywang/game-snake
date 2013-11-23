using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Input;

namespace GreedySnakeLibrary
{
    public class GameMediator
    {
        private Snake _snake;
        private ISnakeGameUI _ui;
        private OrientationInterpreter _orientation;
        private Timer _timer = new Timer();
        private Food _food = new Food();

        public event EventHandler<SnakeGameEvent> BeyondBoundary;

        public event EventHandler<SnakeGameEvent> SelfCrash;

        public GameMediator(ISnakeGameUI ui)
        {
            _ui = ui;
        }

        public Snake Snake
        {
            get { return _snake; }
        }

        public void InitGame()
        {
            InitMap();
            InitSnake();
            InitOrientation();
            InitTimer();
        }

        public void BeginGame()
        {
            _timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
        }

        public void ResetGame()
        {
            _ui.ClearObjects();
            this.InitSnake();
            this.InitOrientation();
        }

        public void InterpreterKey(Key key)
        {
            if (key == Key.Up && _orientation.GetType() != typeof(OrientationDown))
            {
                _orientation = new OrientationUp();
            }
            else if (key == Key.Right && _orientation.GetType() != typeof(OrientationLeft))
            {
                _orientation = new OrientationRight();
            }
            else if (key == Key.Down && _orientation.GetType() != typeof(OrientationUp))
            {
                _orientation = new OrientationDown();
            }
            else if (key == Key.Left && _orientation.GetType() != typeof(OrientationRight))
            {
                _orientation = new OrientationLeft();
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            var acrossFood = false;
            var expectedPosition = _orientation.GetExpectedPosition(_snake.Head.Segment.Poisition);
            if (expectedPosition == _food.Position)
            {
                _food = null;
                acrossFood = true;
            }

            try
            {
                _snake.Creep(_orientation, acrossFood);
            }
            catch (BeyondBoundaryException ex)
            {
                _timer.Stop();
                OnBeyondBoundary(ex.Message);
                return;
            }
            catch (SelfCrashedException ex)
            {
                _timer.Stop();
                OnSelfCrashedBoundary(ex.Message);
                return;
            }

            _ui.ClearObjects();
            _ui.PaintSnake(_snake);

            if (_food == null)
            {
                GenerateFood();
            }

            _ui.PaintFood(_food);
        }

        private void GenerateFood()
        {
            _food = new Food();
            var pos = Coordinate.GetRandomPosition();
            while (_snake.IsCover(pos))
            {
                pos = Coordinate.GetRandomPosition();
            }
            _food.Position = new Coordinate(new Random().Next(Coordinate.MaxX), new Random().Next(Coordinate.MaxY));
        }

        private void InitMap()
        {
            Coordinate.MaxX = 10;
            Coordinate.MaxY = 10;
            _ui.PaintMap(Coordinate.MaxY + 1, Coordinate.MaxX + 1);
        }

        private void InitSnake()
        {
            var segment1 = new Segment();
            segment1.Poisition = new Coordinate() { X = 0, Y = 0 };
            var segment2 = new Segment();
            segment2.Poisition = new Coordinate() { X = 0, Y = 1 };
            var segment3 = new Segment();
            segment3.Poisition = new Coordinate() { X = 0, Y = 2 };

            var head = new SnakeHead(segment3);

            var segs = new LinkedList<Segment>();
            segs.AddFirst(segment1);
            segs.AddLast(segment2);
            segs.AddLast(segment3);
            var body = new SnakeBody(segs);

            _snake = new Snake(head, body);

            _ui.PaintSnake(_snake);
        }

        private void InitTimer()
        {
            _timer.Interval = 400;
            _timer.Elapsed += TimerElapsed;
        }

        private void InitOrientation()
        {
            _orientation = new OrientationDown();
        }

        private void OnBeyondBoundary(string message)
        {
            if (BeyondBoundary != null)
            {
                BeyondBoundary(this, new SnakeGameEvent() { Message = message });
            }
        }

        private void OnSelfCrashedBoundary(string message)
        {
            if (SelfCrash != null)
            {
                SelfCrash(this, new SnakeGameEvent() { Message = message });
            }
        }

    }
}
