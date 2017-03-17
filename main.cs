using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Properties;
using Network;

namespace main {

    class Program {

          public static void Main(string[] args) {

              if (args.Length == 0) {

                  Help();
                  System.Environment.Exit(1);

              }
              else {

                  Server connServer = ServerConn.ConnInfo(args);

                  ServerConn.Connect(connServer);
              }

          }

          public static void Help() {

              Console.WriteLine("Input: <filename> <server> <port> <nickname>");
              Console.WriteLine("Example: main.exe irc.freenode.net 6667 imabotlol");

          }
    }
}
