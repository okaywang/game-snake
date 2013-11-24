using GreedySnakeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormGreedySnake
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form1();
            var settings = new SnakeGameSettings() { RowCount = 10, ColumnCount = 20, TimerInterval = 400 };
            var _gameMediator = new SnakeGameController(form, settings);

            _gameMediator.BeyondBoundary += form.GameOver;
            _gameMediator.SelfCrash += form.GameOver;
            _gameMediator.Initialize();

            form.StartRequest = _gameMediator.Start;
            form.PauseRequest = _gameMediator.Pause;
            form.ResetRequest = _gameMediator.Reset;
            form.StopRequest = _gameMediator.Stop;
            form.OrientationReqest = _gameMediator.InterviewCommand;


            Application.Run(form);
        }
    }
}
