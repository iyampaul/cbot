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
        // This needs to move around channel properties
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
              BotAdmin.Triage(lineWrite, lineData, serverInfo, authProps);
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
        // Create the channel property - Call the channel property channelname sans #.
        lineWrite.WriteLine("JOIN {0}", serverInfo.Channel);
        lineWrite.Flush();

      }

      public static void PartChan(StreamWriter lineWrite, Server serverInfo) {
        // This is completely broken and dependent on refactor of Channel storage.
        lineWrite.WriteLine("PART {0}", )
      }

      public static void NickChange(StreamWriter lineWrite, Server serverInfo, string newNick) {
        lineWrite.WriteLine("NICK {0}", newNick);
      }

      public static void WriteStream(StreamWriter lineWrite, string[] lineData, Server serverInfo, string outputData) {
        // Needs channel property
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
