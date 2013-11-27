using SimpleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisLibrary;
using TetrisLibrary.DataContext;

namespace WinFormTetris
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
            var view = new FrmTetrisView();

            var settings = new TerisGameSettings() { RowCount = 5, ColumnCount = 4, TimerInterval = 1000000 };
            var _controller = new TetrisGameController(view, settings);

            //_controller.BeyondBoundary += view.GameOver;
            //_controller.SelfCrash += view.GameOver;
            _controller.Initialize();

            view.StartRequest = _controller.Start;
            view.PauseRequest = _controller.TimerElapsed;
            //view.PauseRequest = _controller.Pause;
            //view.ResetRequest = _controller.Reset;
            //view.StopRequest = _controller.Stop;
            view.OrientationReqest = _controller.InterviewCommand;

            Application.Run(view);
        }
    }
}
