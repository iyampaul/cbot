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

      private static void PrintConsole(string[] lineData) {

        Console.WriteLine("{0} {1} {2} {3}", DateTime.Now, lineData[1], lineData[0], lineData[3]);

      }

      private static void PrintFile(string[] lineData) { } // Futureproofing!

    }

}
