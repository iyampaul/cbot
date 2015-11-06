using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Properties {

    class Server {

        public string Hostname { get; set; }
        public int Port { get; set; }
        public string Nickname { get; set; }
        public string User { get; set; }
        public string Channel { get; set; }

    }

    class Channel {

        public string Name { get; set; }
        public string[] Users { get; set; }
        public string Topic { get; set; }
        public string Modes { get; set; }

    }

}
