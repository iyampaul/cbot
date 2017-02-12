using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Properties;
using Network;
using StreamManagement;
using AuditRecord;
using UserControl;

namespace DiceBot {

    class Dice {

      private int Multiplier { get; set; }
      private int Type { get; set; }

      public static void Roll(StreamWriter lineWrite, Server serverInfo, string diceInput) {

          Dice DiceData = new Dice();

          InitializeDice(diceInput, DiceData);

          OutputRoll(lineWrite, serverInfo, CalcRoll(DiceData));
      }

      private static void InitializeDice(string diceInput, Dice DiceData) {

        if (InputValidation(diceInput)) {
            char[] diceArray = diceInput.ToCharArray();

            for (int i = 0; i < diceArray.Length; i++) {

              if (diceArray[i] == 'd') {

                int diceLimiter = i;
                string diceResult = "";

                for (int j = 0; j < diceLimiter; j++) {
                  diceResult = diceResult + diceArray[j];
                }

                DiceData.Multiplier = Int32.Parse(diceResult);
                diceResult = "";

                for (int k = (diceLimiter + 1); (k > diceLimiter) & (k < diceArray.Length); k++) {
                  diceResult = diceResult + diceArray[k];
                }

                DiceData.Type = Int32.Parse(diceResult);
              }
            }
        }
      }

      private static bool InputValidation(string diceData) {

        Regex sanityCheck = new Regex("^[1-9][0-9]*[dD][1-9][0-9]*$");

        if (sanityCheck.IsMatch(diceData) & (diceData.Length < 10)) {
          return true;
        }
        else { return false; }
      }


      private static int CalcRoll(Dice DiceData) {

        int diceResult = 0;
        Random randNum = new Random();

        for (int i =0; i < DiceData.Multiplier; i++) {
          diceResult = diceResult + randNum.Next(1, DiceData.Type + 1);
        }

        return diceResult;
      }

      private static void OutputRoll(StreamWriter lineWrite, Server serverInfo, int rollResult) {
        Commands.WriteStream(lineWrite, serverInfo, "Roll: " + rollResult);
      }
    }
}
