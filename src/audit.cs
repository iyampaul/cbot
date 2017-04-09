using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Properties;

namespace AuditRecord {

    class Log {

      public static void Print(string[] lineData) {
        PrintConsole(lineData);
      }

      public static void Connection(Server serverInfo) {

        string[] ConnData = { serverInfo.Hostname, "CONNECTED", "", "" };
        PrintConsole(ConnData);

      }

      private static void PrintConsole(string[] lineData) {
        Console.WriteLine("{0} {1} {2} {3}", DateTime.Now, lineData[1], lineData[0], lineData[3]);
      }

    }

}
