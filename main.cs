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

              Server connServer = ServerConn.ConnInfo(args);

              ServerConn.Connect(connServer);

          }
    }
}
