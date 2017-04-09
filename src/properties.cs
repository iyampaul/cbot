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

    class Admin {

        public string Key { get; set; }
        public List<string> Users { get; set; }

    }

    class UserInformation {

        public static string GetNick(string lineData) {

            string buildNick = "";

            char[] nickArray = lineData.ToCharArray();

            for (int i = 0; i < nickArray.Length; i++) {

                if (nickArray[i] == '!') {

                    int nickLimiter = i;
                    string nickResult = "";

                    for (int j = 1; j < nickLimiter; j++) {
                        buildNick = buildNick + nickArray[j];
                    }
                }
            }

            return buildNick;
        }
    }

}
