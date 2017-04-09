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
using Administration;

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
            Authenticator.Users = new List<string>();

            OutputKey(Authenticator.Key);

            return Authenticator;

        }

        private static void OutputKey(string authKey) {
            Console.WriteLine("Auth Key: {0}", authKey);
        }

    }

    class Validation {

        public static bool Auth(string[] lineData, Admin authProps) {

            if (lineData[3].ToLower() == ":-auth") {
                // Initialize Auth

                if (CheckKey(lineData[4], authProps)) { 
                    // Add user to authProps.Users 

                    AdminList.AddUser(UserInformation.GetNick(lineData[0]), authProps);
                    return true; 

                }
                // Fails initial auth
                else { return false; }

            }
            else {
                // Anything but auth requests
                if (authProps.Users.Count == 0) { 
                    return false;
                }
                else if (CheckList(UserInformation.GetNick(lineData[0]), authProps)) {            
                    return true;
                }
                return false;
            }

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

            return false;
        }

    }

    class KeyAdmin {

        public static void PrintKey (StreamWriter lineWrite, string[] lineData, Server serverInfo, Admin authProps) {

            string Key = "Auth Key: " + authProps.Key;
            
            Commands.WriteStream(lineWrite, lineData, serverInfo, Key);
        }

        public static void ResetKey (StreamWriter lineWrite, string[] lineData, Server serverInfo, Admin authProps) {

            authProps.Key = Tokens.GenToken();
            
            PrintKey(lineWrite, lineData, serverInfo, authProps); 
        }

    }
}