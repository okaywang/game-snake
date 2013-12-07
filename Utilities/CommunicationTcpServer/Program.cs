using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CommunicationTcpServer
{
    class Program
    {
        static void Main()
        {
            Trace.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());
            var comm = new Communicator(7788);
            comm.AcceptClient();
        }
    }
}
