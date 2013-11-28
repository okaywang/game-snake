using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary.Commands;
using TetrisLibrary.DataContext;
using TetrisLibrary.DataContext.Tetromino;

namespace TetrisLibrary
{
    public class TetrisGameController : GameControllerBase
    {
        private ITetrisGameView _view;
        private TetrisGameModel _model;

        private TerisGameSettings _settings;
        public EventHandler<EliminateRowsEventArgs> RowsEliminated;
        public TetrisGameController(ITetrisGameView view, TerisGameSettings settings)
            : base(view, settings)
        {
            _view = view;
            _settings = settings;
        }

        public override void TimerElapsed()
        {
            if (_model.Tetromino.BeHold(_model.DownTetrominoContext))
            {
                _model.ActiveRowIndex--;
            }
            else
            {
                if (_model.Apartment.TopIndex == _model.Apartment.FloorCount - 1)
                {
                    base.OnGameOver();
                    return;
                }
                try
                {

                    _model.Apartment.Reside(_model.Tetromino, _model.ActiveRowIndex, _model.ActiveColumnIndex);
                }
                catch (FloorUseupException)
                {
                    base.OnGameOver();
                    return;
                }

                var eliminateRows = 0;
                for (int i = _model.ActiveRowIndex; i < _model.ActiveRowIndex + _model.Tetromino.Height; )
                {
                    if (i < 0)
                    {
                        i++;
                        continue;
                    }
                    if (_model.Apartment[i].IsFull)
                    {
                        _model.Apartment[i].Clear();
                        _model.Apartment.GoDownstairs(i, 1);
                        eliminateRows++;
                    }
                    else
                    {
                        i++;
                    }
                }
                if (eliminateRows > 0)
                {
                    OnRowsEliminated(eliminateRows);
                }
                this.ProduceTetromino();
            }

            _view.RenderScence(_model);
        }

        private void OnRowsEliminated(int count)
        {
            if (RowsEliminated != null)
            {
                var e = new EliminateRowsEventArgs() { EliminateRowsCount = count };
                RowsEliminated(this, e);
            }
        }

        public void InterviewCommand(CommandOrientation command)
        {
            if (command is CommandUp)
            {
                if (_model.Tetromino.CanTransform(_model.TetrominoContext))
                {
                    _model.Tetromino.Transform();
                }
            }
            else if (command is CommandLeft)
            {
                if (_model.Tetromino.BeHold(_model.LeftTetrominoContext))
                {
                    _model.ActiveColumnIndex--;
                }
            }
            else if (command is CommandRight)
            {
                if (_model.Tetromino.BeHold(_model.RightTetrominoContext))
                {
                    _model.ActiveColumnIndex++;
                }
            }
            else if (command is CommandDown)
            {
                this.TimerElapsed();
            }
            else if (command is CommandBlank)
            {
                while (_model.Tetromino.BeHold(_model.DownTetrominoContext))
                {
                    _model.ActiveRowIndex--;
                }
                this.TimerElapsed();
            }

            _view.RenderScence(_model);
        }

        private void ProduceTetromino()
        {
            _model.ActiveRowIndex = _settings.RowCount - 1;
            if (_model.SpareTire == null)
            {
                _model.SpareTire = TetrominoFactory.GetRandomTetromino();
            }
            _model.Tetromino = _model.SpareTire.Clone() as TetrominoBase;
            _model.SpareTire = TetrominoFactory.GetRandomTetromino();
            _model.ActiveColumnIndex = _model.Apartment.UnitCount / 2 - _model.Tetromino.Width / 2;
        }

        public override void InitializeActiveObjects()
        {
            _model = new TetrisGameModel();
            var floors = new Floor[_settings.RowCount];
            for (int i = 0; i < floors.Length; i++)
            {
                floors[i] = new Floor(_settings.RowCount, _settings.ColumnCount);
            }
            _model.Apartment = new TetrisLibrary.DataContext.Apartment(floors);
            ProduceTetromino();
        }
    }
}
