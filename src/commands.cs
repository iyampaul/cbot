using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Properties;
using Network;
using StreamManagement;
using AuditRecord;
using DiceBot;
using WeatherBot;
using Authentication;
using Administration;

namespace UserControl {

    class Triage {

      public static void Input(StreamWriter lineWrite, Server serverInfo, string[] lineData, Admin authProps) {

        Log.Print(lineData);


        if (Validation.Auth(lineData, authProps)) {

          switch (lineData[3].ToLower()) {
            case ":-dice":
              Dice.Roll(lineWrite, serverInfo, lineData);
              break;
            case ":-weather":
              Weather.Initialize(lineWrite, serverInfo, lineData);
              break;
            case ":-quit":
              System.Environment.Exit(1);
              break;
            case ":-admin":
              if (lineData[4].ToLower() == "list") {
                AdminList.ListUser(lineWrite, lineData, serverInfo, authProps);
              }
              if (lineData[4].ToLower() == "add") {
                AdminList.AddUser(lineData[5], authProps);
              }
              if (lineData[4].ToLower() == "remove") {
                AdminList.RemUser(lineData[5], authProps);
              }
              break;
            default:
              break;      
          }
        }
        else {
          Commands.WriteStream(lineWrite, lineData, serverInfo, "Access Denied");
        }
      }
    }

    class Commands {

      public static void JoinChan(StreamWriter lineWrite, Server serverInfo) {

        lineWrite.WriteLine("JOIN {0}", serverInfo.Channel);
        lineWrite.Flush();

      }

      public static void WriteStream(StreamWriter lineWrite, string[] lineData, Server serverInfo, string outputData) {

        string writeLoc = "";

        if (lineData[2] == serverInfo.Nickname) {
          writeLoc = UserInformation.GetNick(lineData[0]);
        } 
        else { writeLoc = serverInfo.Channel; }

        lineWrite.WriteLine("PRIVMSG {0} :{1}", writeLoc, outputData);
        lineWrite.Flush();

      }
    }
}
