using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary.DataContext;
using WindowsFormsApplication1;

namespace TetrisLibrary
{
    public class TetrisGameController : GameControllerBase
    {
        private ITetrisGameView _view;
        private TetrisGameModel _model;

        private TerisGameSettings _settings;
        public TetrisGameController(ITetrisGameView view, TerisGameSettings settings)
            : base(view, settings)
        {
            _view = view;
            _settings = settings;
        }

        public override void TimerElapsed()
        {
            var hasBarrier = _model.Apartment.HasBarrier(_model.Tetromino, _model.ActiveRowIndex - 1, _model.ActiveColumnIndex);
            if (hasBarrier)
            {
                _model.Apartment.Reside(_model.Tetromino, _model.ActiveRowIndex, _model.ActiveColumnIndex);
                this.ProduceTetromino();
            }
            else
            {
                _model.ActiveRowIndex--;
            }

            _view.RenderScence(_model);
        }

        public void InterviewCommand(CommandOrientation command)
        {
            if (command is CommandUp)
            {
                _model.Tetromino.Transform();
            }
            else if (command is CommandLeft)
            {
                bool a = _model.Tetromino.IsEmpty(2);
                if (_model.ActiveColumnIndex <= 0)
                {
                    if (_model.Tetromino.IsEmpty(Math.Abs(_model.ActiveColumnIndex)))
                    {
                        _model.ActiveColumnIndex--;
                    }
                }
                else
                {
                    _model.ActiveColumnIndex--;
                }
            }
            else if (command is CommandRight)
            {
                var criticalIndex = _model.Apartment.UnitCount  - _model.Tetromino.Width;
                if (_model.ActiveColumnIndex < criticalIndex)
                {
                    _model.ActiveColumnIndex++;
                }
                else
                {
                    if (_model.Tetromino.IsEmpty(_model.Tetromino.Width - 1 - (_model.ActiveColumnIndex - criticalIndex)))
                    {
                        _model.ActiveColumnIndex++;
                    }
                }
            }
            else if (command is CommandDown)
            {
                _model.ActiveRowIndex -= 1;
            }

            _view.RenderScence(_model);
        }

        private void ProduceTetromino()
        {
            _model.ActiveRowIndex = _settings.RowCount - 1;
            _model.Tetromino = new T_Tetromino();
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
            _model.Tetromino = new T_Tetromino();
            _model.ActiveRowIndex = _settings.RowCount - 1;
        }
    }
}
