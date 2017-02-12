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

namespace UserControl {

    class Triage {

      public static void Input(StreamWriter lineWrite, Server serverInfo, string[] lineData) {

        Log.Print(lineData);

        switch (lineData[3].ToLower()) {
          case ":-dice":
            Dice.Roll(lineWrite, serverInfo, lineData[4]);
            break;
          case ":-weather":
            Weather.Initialize(lineWrite, serverInfo);
            break;
          default:
            break;
        }
      }
    }

    class Commands {

      public static void JoinChan(StreamWriter lineWrite, Server serverInfo, string[] lineData) {

        serverInfo.Channel = lineData[3].Substring(1,lineData[3].Length - 1);
        lineWrite.WriteLine("JOIN {0}", lineData[3]);
        lineWrite.Flush();

      }

      public static void WriteStream(StreamWriter lineWrite, Server serverInfo, string outputData) {

        lineWrite.WriteLine("PRIVMSG {0} :{1}", serverInfo.Channel, outputData);
        lineWrite.Flush();

      }
    }
}