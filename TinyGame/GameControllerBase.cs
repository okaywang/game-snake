using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleGame
{
    public abstract class GameControllerBase
    {
        private IGameView _view;
        private GameSettingsBase _settings;
        private System.Timers.Timer _timer;

        public EventHandler GameOver;

        public GameControllerBase(IGameView view, GameSettingsBase settings)
        {
            _view = view;
            _settings = settings;
        }

        public void Initialize()
        {
            InitializeMap();
            InitialieTimer();
            InitializeActiveObjects();
        }

        private void InitialieTimer()
        {
            _timer = new Timer();
            _timer.Interval = _settings.TimerInterval;
            _timer.Elapsed += TimerElapsed;
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            TimerElapsedCore();
        }

        private void InitializeMap()
        {
            InitializeModelContext();
            _view.RenderMap(_settings.RowCount, _settings.ColumnCount);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
        }

        public void Restart()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Reset()
        {
            this.InitializeActiveObjects();
        }

        public void OnGameOver()
        {
            this.Stop();
            if (GameOver !=null)
            {
                GameOver(this, EventArgs.Empty);
            }
        }

        public abstract void TimerElapsedCore();
        protected virtual void InitializeModelContext() { }
        public abstract void InitializeActiveObjects();

    }
}
