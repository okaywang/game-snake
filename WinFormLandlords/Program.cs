using BasicLibrary;
using LandlordsLibrary;
using LandlordsLibrary.DataContext;
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

            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            var a = q.ToArray();

            var p1 = new Player("zs");
            var p2 = new Player("ls");
            var p3 = new Player("ww");

            var linked = new LinkedList<IPlayer>();
            linked.AddFirst(p1);
            linked.AddLast(p2);
            linked.AddLast(p3);
            linked.AddLast(p1);

             

            var referee = new Referee(linked);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static object p1LandlordsLibraryRules { get; set; }
    }
}
