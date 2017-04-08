using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Properties;
using StreamManagement;
using AuditRecord;

namespace Network {

    class ServerConn {

          public static Server ConnInfo(string[] args) {

              Server serverInfo = new Server();
              serverInfo.Hostname = args[0];
              serverInfo.Port = int.Parse(args[1]);
              serverInfo.Nickname = args[2];

              serverInfo.User = serverInfo.Nickname + " " + serverInfo.Nickname + "  nullboat :Purple";

              return serverInfo;

          }

          public static void Connect(Server serverInfo) {

              try {

                  TcpClient ircConnection = new TcpClient(serverInfo.Hostname, serverInfo.Port);
                  NetworkStream ircStream = ircConnection.GetStream();
                  StreamReader ircReader = new StreamReader(ircStream);
                  StreamWriter ircWriter = new StreamWriter(ircStream);

                  Ping.loadGlobals(ircWriter, serverInfo);

                  ircWriter.WriteLine("NICK " + serverInfo.Nickname);
                  ircWriter.Flush();
                  ircWriter.WriteLine("USER " + serverInfo.User);
                  ircWriter.Flush();

                  Ping ping = new Ping();
                  ping.Start();

                  Log.Connection(serverInfo);

                  StreamReceiver.Initialize(ircReader, ircWriter, serverInfo);

                  ircWriter.Close();
                  ircReader.Close();
                  ircStream.Close();
              }

              catch (Exception e) {

                  Console.WriteLine(e.ToString());
                  Console.WriteLine("Hit the anykey to quit.");
                  Console.ReadLine();
                  System.Environment.Exit(1);

              }

          }
    }

    class Ping {

        private static StreamWriter ircWriter;
        private static Server serverInfo;

        public static void loadGlobals(StreamWriter lineWriter, Server ircInfo) {

            ircWriter = lineWriter;
            serverInfo = ircInfo;

        }

        private Thread sendPing;

        public Ping() { sendPing = new Thread(new ThreadStart(Run)); }

        public void Start() { sendPing.Start(); }

        public static void Run() {

            while (true) {

                ircWriter.WriteLine("PING :{0}", serverInfo.Hostname);
                ircWriter.Flush();
                Thread.Sleep(15000);

            }
        }
    }
}
