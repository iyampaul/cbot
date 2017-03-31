using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Properties;
using Network;
using UserControl;
using AuditRecord;
using Authentication;

namespace Administration {

    class AdminList { 

        public static void AddUser(string requestUser, Admin authProps) {

            authProps.Users.Add(requestUser);

        }

        public static void RemUser(string requestUser, Admin authProps) {

            authProps.Users.Remove(requestUsers);

        }

        public static void ListUser(StreamWriter lineWrite, string[] lineData, Server serverInfo, Admin authProps) {

            Commands.WriteStream(lineWrite, lineData, serverInfo, "Authorized Users:");

            foreach (string user in authProps) {
                
                Commands.WriteStream(lineWrite, lineData, serverInfo, user);

            }

        }

    }

}