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
            authProps.Users.Remove(requestUser);
        }

        public static void ListUser(StreamWriter lineWrite, string[] lineData, Server serverInfo, Admin authProps) {

            Commands.WriteStream(lineWrite, lineData, serverInfo, "Authorized Users:");

            foreach (string user in authProps.Users) {
                
                Commands.WriteStream(lineWrite, lineData, serverInfo, user);

            }

        }

    }

    class BotAdmin {

        public static void Triage (StreamWriter lineWrite, string[] lineData, Server serverInfo, Admin authProps) { 

            switch(lineData[4].ToLower()) {
                case "auth":
                    switch(lineData[5].ToLower()) {
                        case "list":
                            AdminList.ListUser(lineWrite, lineData, serverInfo, authProps);
                            break;
                        case "add":
                            AdminList.AddUser(lineData[6], authProps);
                            break;
                        case "remove":
                            AdminList.RemUser(lineData[6], authProps);
                            break;
                        default:
                            break;
                    }
                    break;
                case "key":
                    switch(lineData[5].ToLower()) {
                        case "show":
                            KeyAdmin.PrintKey(lineWrite, lineData, serverInfo, authProps);
                            break;
                        case "reset":
                            KeyAdmin.ResetKey(lineWrite, lineData, serverInfo, authProps);
                            break;
                        default:
                            break;
                    }
                    break;
                case "chan":
                    switch(lineData[5].ToLower()) {
                        case "join":
                            Commands.JoinChan(lineWrite, serverInfo);
                            break;
                        default:
                            break;
                    }
                    break;
                case "bot":
                    switch(lineData[5].ToLower()) {
                        case "nick":
                            Commands.NickChange(lineWrite, serverInfo, lineData[6]);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

        }
    }

}