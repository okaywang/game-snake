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
            var view = new FrmGameView();
            var settings = new SnakeGameSettings() { RowCount = 10, ColumnCount = 20, TimerInterval = 400 };
            var _controller = new SnakeGameController(view, settings);

            _controller.BeyondBoundary += view.GameOver;
            _controller.SelfCrash += view.GameOver;
            _controller.Initialize();

            view.StartRequest = _controller.Start;
            view.PauseRequest = _controller.Pause;
            view.ResetRequest = _controller.Reset;
            view.StopRequest = _controller.Stop;
            view.OrientationReqest = _controller.InterviewCommand;


            Application.Run(view);
        }
    }
}
