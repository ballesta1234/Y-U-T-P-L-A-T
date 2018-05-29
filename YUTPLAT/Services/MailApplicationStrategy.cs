using System;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using YUTPLAT.Helpers;

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
                LogHelper.LogException(ex);
            }
        }
    }
}