using CommunicationTcpClient;
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
            var cm = new Communicator();
            cm.Connect();
        }
    }
}
