using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Input;

namespace GreedySnakeLibrary
{
    public class GameMediator2 : GameControllerBase
    {
        private ISnakeGameView _view;
        private SnakeGameModel _model;
        
        private OrientationInterpreter _orientation;
        
        public event EventHandler<SnakeGameEvent> BeyondBoundary;
        public event EventHandler<SnakeGameEvent> SelfCrash;

        public GameMediator2(ISnakeGameView view, SnakeGameSettings settings)
            : base(view, settings)
        {
            _view = view;
            _model = new SnakeGameModel();
        }

  
        public override void TimerElapsed()
        {
            var acrossFood = false;
            var expectedPosition = _orientation.GetExpectedPosition(_model.Snake.Head.Segment.Poisition);
            if (expectedPosition == _model.Food.Position)
            {
                _model.Food = null;
                acrossFood = true;
            }

            try
            {
                _model.Snake.Creep(_orientation, acrossFood);
            }
            catch (BeyondBoundaryException ex)
            {
                base.Stop();
                OnBeyondBoundary(ex.Message);
                return;
            }
            catch (SelfCrashedException ex)
            {
                base.Stop();
                OnSelfCrashedBoundary(ex.Message);
                return;
            }

            if (_model.Food == null)
            {
                GenerateFood();
            }

            _view.RenderScence(_model);
        }

        private void GenerateSnake()
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

            _model.Snake = new Snake(head, body);

            _orientation = new OrientationDown();
        }

        private void GenerateFood()
        {
            _model.Food = new Food();
            var pos = Coordinate.GetRandomPosition();
            while (_model.Snake.IsCover(pos))
            {
                pos = Coordinate.GetRandomPosition();
            }
            _model.Food.Position = new Coordinate(new Random().Next(Coordinate.MaxX), new Random().Next(Coordinate.MaxY));
        }

        public override void InitializeActiveObjects()
        {
            GenerateSnake();

            GenerateFood();

            _view.RenderScence(_model);
        }

        public void InterpreterKey(Keys key)
        {
            if (key == Keys.Up && _orientation.GetType() != typeof(OrientationDown))
            {
                _orientation = new OrientationUp();
            }
            else if (key == Keys.Right && _orientation.GetType() != typeof(OrientationLeft))
            {
                _orientation = new OrientationRight();
            }
            else if (key == Keys.Down && _orientation.GetType() != typeof(OrientationUp))
            {
                _orientation = new OrientationDown();
            }
            else if (key == Keys.Left && _orientation.GetType() != typeof(OrientationRight))
            {
                _orientation = new OrientationLeft();
            }
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
