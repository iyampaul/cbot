using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Properties;
using Network;
using StreamManagement;
using AuditRecord;
using UserControl;

namespace WeatherBot {

    class Weather {

      public static void Initialize(StreamWriter lineWrite, Server serverInfo) {

        DownloadXML();

        ReviewXML(ParseXML(), lineWrite, serverInfo);

        File.Delete("weather.xml");

      }

      private static void DownloadXML() {

        string remoteURL = "http://rss.theweathernetwork.com/weather/camb0244";
        string fileName = "weather.xml";

        using (WebClient webConn = new WebClient()) {
          webConn.DownloadFile(remoteURL, fileName);
        }
      }

      private static string[] ParseXML() {

        XmlDocument weatherXML = new XmlDocument();
        weatherXML.Load("weather.xml");

        XmlNodeList currentWeather = weatherXML.GetElementsByTagName("description");

        return currentWeather[1].InnerText.Split('\t');

      }

      private static void OutputWeather(StreamWriter lineWrite, Server serverInfo, string weatherData) {

        Commands.WriteStream(lineWrite, serverInfo, weatherData);

      }

      private static void ReviewXML(string[] weatherXML, StreamWriter lineWrite, Server serverInfo) {

        for (int i = 0; i < weatherXML.Length; i++) {

          switch (i) {
            case 0:
              weatherXML[0] = weatherXML[0].Trim();
              OutputWeather(lineWrite, serverInfo, "Current Connditions: " + weatherXML[0].Remove(weatherXML[0].Length - 1));
              break;
            case 2:
              string temperature = "";
              weatherXML[2] = weatherXML[2].Trim();
              for (int j = 0; j < weatherXML[2].IndexOf("&"); j++) {
                temperature = temperature + weatherXML[2][j];
              }
              OutputWeather(lineWrite, serverInfo, "Temperature: " + temperature + "C");
              break;
            case 6:
              string humidity = "";
              for (int j = 0; j < weatherXML[6].Length; j++) {
                humidity = humidity + weatherXML[6][j];
              }
              OutputWeather(lineWrite, serverInfo, "Humidity: " + humidity);
              break;
            case 10:
              string windSpeed = "";
              for (int j = 0; j < weatherXML[10].Length; j++) {
                windSpeed = windSpeed + weatherXML[10][j];
              }
              OutputWeather(lineWrite, serverInfo, "Wind: " + windSpeed);
              break;
            default:
              break;
          }

        }

      }
    }
}
