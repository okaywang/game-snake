using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChinaBlock
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
//http://www.cnblogs.com/tuyile006/archive/2007/05/16/748256.html
        }
    }
}