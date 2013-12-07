using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationTestSocket
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

            var frmServer = new FrmServer();
            var frmClient1 = new FrmClient() { Text = "client 1111" };
            var frmClient2 = new FrmClient() { Text = "client 2222" };
            var frmClient3 = new FrmClient() { Text = "client 3333" };
            frmClient1.Show();
            frmClient2.Show();
            frmClient3.Show();
            Application.Run(frmServer);

        }
    }
}
