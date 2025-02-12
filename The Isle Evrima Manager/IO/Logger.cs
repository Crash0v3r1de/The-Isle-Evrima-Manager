using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.IO
{
    public static class Logger
    {
        private static string logDir = "/logs";
        public static void Log(string message, LogType type)
        {
            string currTime = DateTime.Now.ToString("HH:mm:ss");
            switch (type)
            {
                case LogType.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    WriteLog($"{currTime} - [INFO] {message}");
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteLog($"{currTime} - [WARNING] {message}");
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLog($"{currTime} - [ERROR] {message}");
                    break;
            }
        }
        private static void WriteLog(string msg) {
            using (StreamWriter sw = File.AppendText($"{logDir}/{DateTime.Today.ToString("MM-dd-yyyy")}.txt")) { 
                sw.WriteLine(msg);
            }
        }
    }
    public enum LogType
    {
        Info,
        Warning,
        Error
    }
}
