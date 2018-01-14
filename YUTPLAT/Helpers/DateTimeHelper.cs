using System;
using System.Configuration;

namespace YUTPLAT.Helpers
{

    public static class DateTimeHelper
    {
        public static DateTime OntenerFechaActual()
        {
            DateTime fechaActual = DateTime.Now;

            if (bool.Parse(ConfigurationManager.AppSettings["ModoDebug"]))
            {
                fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaActual"]);
            }

            return fechaActual;
        }

    }
}