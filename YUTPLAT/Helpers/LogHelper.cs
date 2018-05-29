using System;
using System.Configuration;
using System.IO;

namespace YUTPLAT.Helpers
{
    public static class LogHelper
    {
        public static void LogException(Exception exception)
        {
            string pathLogs = ConfigurationManager.AppSettings["PathLogs"];

            string nameLog = pathLogs + "YUTPLAT_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".log";

            TextWriter log = null;
            log = new StreamWriter(nameLog, true);

            log.WriteLine("");
            log.WriteLine(DateTime.Now.ToString());
            log.WriteLine(exception.ToString());
            log.WriteLine("");

            if (exception.InnerException != null)
            {
                log.WriteLine(exception.InnerException.ToString());
                log.WriteLine("");
            }

            log.Close();
        }
    }
}