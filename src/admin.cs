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

            for (int i = 0; i < tokenSize; i++)
            {
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

        public static void Auth(StreamWriter lineWrite, Server serverInfo, string[] lineData, Admin authProps) {

            // In Progress!

        }

        public static bool CheckKey(string inputKey, Admin authProps) {
            bool validKey = false;

            return validKey;
        }

        public static bool CheckList(string requestUser, Admin authProps) {
            bool validUser = false;

            return valudUser;
        }
    }
}