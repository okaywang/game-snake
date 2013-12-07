using BasicLibrary;
using BasicLibrary.DataStructure;
using LandlordsLibrary;
using LandlordsLibrary.DataContext;
using LandlordsLibrary.Participant;
using LandlordsLibrary.Participant.Robot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


            var p1 = new Player("王国君");
            var p2 = new Player("张衡");
            var p3 = new Player("刘志伟");

            var view1 = new LandlordsGameView(p1, p2, p3);
            var view2 = new LandlordsGameView(p2, p3, p1);
            var view3 = new LandlordsGameView(p3, p1, p2);


            var views = new CircularlyLinkedList<ILandlordsGameView>(view1, view2, view3);
            var controller = new LandlordsGameController(views);
            controller.Initiallize();

            views.Each(v =>
            {
                var view = v.Value as LandlordsGameView;
                view.PlayerPrepared += controller.PlayerPreparedHandler;
                view.PlayerDesireLandlords += controller.PlayerDesireLandlordsHandler;
                view.PlayerDiscardLandlords += controller.PlayerDiscardLandlordsHandler;
                view.PlayerTakeoutFormation += controller.PlayerTakeoutFormationHandler;
                view.PlayerPassby += controller.PlayerPassbyHandler;
                view.PlayerActLandlordsTimeout += controller.PlayerActLandlordsTimeoutHandler;
                view.PlayerBringFormationTimeout += controller.PlayerBringFormationTimeoutHandler;
                view.PlayerFollowFormationTimeout += controller.PlayerFollowFormationTimeoutHandler;

                view.Text = view.Player.Name;
                view.Show();
            });

            Application.Run();
        }


        public static object p1LandlordsLibraryRules { get; set; }
    }
}
