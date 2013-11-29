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
    public class SnakeGameController : GameControllerBase
    {
        private ISnakeGameView _view;
        private SnakeGameModel _model;

        //private RequestOrientation _orientation;
        private Queue<CommandOrientation> _requests;

        public event EventHandler<SnakeGameEvent> BeyondBoundary;
        public event EventHandler<SnakeGameEvent> SelfCrash;

        public SnakeGameController(ISnakeGameView view, SnakeGameSettings settings)
            : base(view, settings)
        {
            _view = view;
            Coordinate.MaxX = settings.ColumnCount ;
            Coordinate.MaxY = settings.RowCount;
        }


        public override void TimerElapsedCore()
        {
            if (_requests.Count > 0)
            {
                _model.Snake.Command = _requests.Dequeue();
            }

            var acrossFood = _model.Snake.ImmediatePosition == _model.Food.Position;

            try
            {
                _model.Snake.Creep(acrossFood);
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

            if (acrossFood)
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

            _model.Snake = new Snake(head, body, new CommandDown());
        }

        private void GenerateFood()
        {
            _model.Food = new Food();
            var pos = Coordinate.GetRandomPosition();
            while (_model.Snake.IsCover(pos))
            {
                pos = Coordinate.GetRandomPosition();
            }
            _model.Food.Position = pos;
        }

        public override void InitializeActiveObjects()
        {
            _model = new SnakeGameModel();
            _requests = new Queue<CommandOrientation>();

            GenerateSnake();

            GenerateFood();

            _view.RenderScence(_model);
        }

        public void InterviewCommand(CommandOrientation command)
        {
            var adjacentCommand = _model.Snake.Command;
            if (_requests.Count > 0)
            {
                adjacentCommand = _requests.Peek();
            }

            if (this.IsIdenticalDimension(command, adjacentCommand))
            {
                return;
            }
            _requests.Enqueue(command);
        }

        private bool IsIdenticalDimension(CommandOrientation a, CommandOrientation b)
        {
            if (a is IHorizontalOrientation && b is IHorizontalOrientation)
            {
                return true;
            }
            if (a is IVerticalOrientation && b is IVerticalOrientation)
            {
                return true;
            }
            return false;
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
