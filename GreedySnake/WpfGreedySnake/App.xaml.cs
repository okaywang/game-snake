using GreedySnakeLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace GreedySnake
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup_1(object sender, StartupEventArgs e)
        {
            var view = new MainWindow();
            var settings = new SnakeGameSettings() { RowCount = 10, ColumnCount = 20, TimerInterval = 400 };
            var _gameMediator = new SnakeGameController(view, settings);

            _gameMediator.BeyondBoundary += view.GameOver;
            _gameMediator.SelfCrash += view.GameOver;
            _gameMediator.Initialize();

            view.StartRequest = _gameMediator.Start;
            view.PauseRequest = _gameMediator.Pause;
            view.ResetRequest = _gameMediator.Reset;
            view.StopRequest = _gameMediator.Stop;
            view.OrientationReqest = _gameMediator.InterviewCommand;

            view.Show();
        }
    }
}
