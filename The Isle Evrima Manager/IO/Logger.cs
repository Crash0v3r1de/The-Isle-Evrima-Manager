using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

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
                    WritErrorLog($"{currTime} - [ERROR] {message}");
                    break;
            }
        }
        private static void WriteLog(string msg) {
            Form1.AppendConsoleEntry(msg);
            using (StreamWriter sw = File.AppendText($"{ManagerGlobalTracker.logDir}\\{DateTime.Today.ToString("MM-dd-yyyy")}.txt")) { 
                sw.WriteLine(msg);
            }
        }
        private static void WritErrorLog(string msg)
        {
            Form1.AppendConsoleEntry(msg);
            using (StreamWriter sw = File.AppendText($"{ManagerGlobalTracker.logDir}\\Errors-{DateTime.Today.ToString("MM-dd-yyyy")}.txt"))
            {
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
