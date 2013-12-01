using BasicLibrary;
using BasicLibrary.DataStructure;
using LandlordsLibrary;
using LandlordsLibrary.DataContext;
using LandlordsLibrary.Participant;
using LandlordsLibrary.Participant.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormLandlords
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

            var view = new LandlordsGameView();
            var p1 = new Player("王国君");
            var p2 = new RobotJunior("机器人");
            var p3 = new Player("刘志伟");
            var players = new CircularlyLinkedList<IPlayer>(p1, p2, p3);
            var controller = new LandlordsGameController(players, view);
            controller.Initiallize();

            view.UserPrepared += controller.UserPreparedHandler;
            view.PlayerDesireLandlords += controller.PlayerDesireLandlordsHandler;
            view.NoPlayerDesireLandlords += controller.NoPlayerDesireLandlordsHandler;
            view.PlayerTakeoutFormation += controller.PlayerTakeoutFormationHandler;
            view.PlayerPassby += controller.PlayerPassbyHandler;
            Application.Run(view);
        }
         

        public static object p1LandlordsLibraryRules { get; set; }
    }
}
