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

namespace Authentication {

    class Tokens {

        public static string GenToken() {

            int tokenSize = 64;
            Random totesRandom = new Random();

            char[] tokenArray = new char[tokenSize];

            for (int i = 0; i < tokenSize; i++){

                tokenArray[i] = TokenAlphabet[totesRandom.Next(TokenAlphabet.Length)];

            }

            return new string(tokenArray);
         
        }

        private const string TokenAlphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

    }

    class AuthInit {

        public static Admin AdminAuth() {

            Admin Authenticator = new Admin();
            Authenticator.Key = Tokens.GenToken();

            OutputKey(Authenticator.Key);

            return Authenticator;

        }

        private static void OutputKey(string authKey) {

            Console.WriteLine("Auth Key: {0}", authKey);

        }

    }

    class Validation {

        public static bool Auth(string[] lineData, Admin authProps) {

            /*
            Purpose: Authorize the requestor; If the user is not in the list, check if the command is '-auth' and the key is accurate.  If it is accurate, add user to the list and validate.
            1. Check if the user is on the list, if yes return true, if no
            2. Check if the command was -auth and if so check if the key is accurate.
            3. If the key is accurate, add the user to the list.
            4. If the key is inaccurate, return rejection.     
            */

            if ((authProps.Users.Count == 0) && (lineData[3].ToLower() == ':-auth')) {
                // Initialize Auth

                if (CheckKey(lineData[4], authProps)) { 
                    // Add user to authProps.Users 

                    AddUser(UserInformation.GetNick(lineData[0]), authProps);
                    return true; 

                }
                // Fails initial auth
                else { return false; }

            }
            else {
                // Temporary!
                return false;
            }


            return true;

        }

        private static bool CheckKey(string inputKey, Admin authProps) {

            if (inputKey == authProps.Key) {
                return true;
            }
            else { return false; }

        }

        private static bool CheckList(string requestUser, Admin authProps) {

            if (authProps.Users.Count == 0) { 

                return false;

            }
            else {

                foreach (string user in authProps.Users) {

                    if (user == requestUser) { return true; }

                }

            }

            // If all else fails, it's false.
            return false;

        }

        private static void AddUser(string requestUser, Admin authProps) {

            authProps.Users.Add(requestUser);

        }
    }
}