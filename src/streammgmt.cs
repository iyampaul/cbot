using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Properties;
using Network;
using UserControl;
using Authentication;

namespace StreamManagement {

    class StreamReceiver {

      public static void Initialize(StreamReader lineRead, StreamWriter lineWrite, Server serverInfo) {

        string newLine;

        Admin authProps = AuthInit.AdminAuth();

        while (true) {

          while ((newLine = lineRead.ReadLine()) != null) {
            string[] lineData = newLine.Split(' ');
            DataIndex.Review(lineWrite, serverInfo, lineData, authProps);
          }
        }
      }
    }

    class DataIndex {

      public static void Review(StreamWriter lineWrite, Server serverInfo, string[] lineData, Admin authProps) {

        switch (lineData[1]) {
          // ERROR: "You have not registered"
          case "451":
            lineWrite.WriteLine("USER {0}", serverInfo.User);
            lineWrite.Flush();
            break;
          // Chat line from user
          case "PRIVMSG":
            // Check for user command
            if (lineData[3].Length == 1) {
              break;
            }
            if (lineData[3][1] == '-') {
              Triage.Input(lineWrite, serverInfo, lineData, authProps);
            }
            break;
          // Channel invite
          // **NOTE: Restrict Later!
          case "INVITE":
            serverInfo.Channel = lineData[3].Substring(1,lineData[3].Length - 1);
            Commands.JoinChan(lineWrite, serverInfo);
            break;
          default:
            break;
          }
        }
    }
}
