using System;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace YUTPLAT.Services.Interface
{
    public class MailApplicationStrategy : IMailStrategy
    {
        public async Task EnviarCorreo(string para, string asunto, string cuerpo)
        {            
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();            
            mmsg.To.Add(para);            
            mmsg.Subject = asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.Body = cuerpo;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;             
            mmsg.From = new MailAddress(ConfigurationManager.AppSettings["MailFromAccount"], "Y U T P L A T");
            
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            
            if (Boolean.Parse(ConfigurationManager.AppSettings["MailAuthentication"]))
            {                
                cliente.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailUsername"],
                                                     ConfigurationManager.AppSettings["MailPassword"]);
            }
            else
            {
                cliente.UseDefaultCredentials = false;
            }

            cliente.Port = Int32.Parse(ConfigurationManager.AppSettings["MailPort"]);
            cliente.EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["MailHabilitarSsl"]);
            cliente.Host = ConfigurationManager.AppSettings["MailHost"];

            try
            {                   
                cliente.Send(mmsg);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void LogException(Exception exception)
        {
            string nameLog = "C:/logs/YUTPLAT_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".log";

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