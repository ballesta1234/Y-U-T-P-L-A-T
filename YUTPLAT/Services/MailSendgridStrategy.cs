using SendGrid;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace YUTPLAT.Services.Interface
{
    public class MailSendgridStrategy : IMailStrategy
    {
        public async Task EnviarCorreo(string para, string asunto, string cuerpo)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(para);
            myMessage.From = new MailAddress(ConfigurationManager.AppSettings["MailFromAccount"], "Y U T P L A T");
            myMessage.Subject = asunto;
            myMessage.Html = cuerpo;

            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailUsername"],
                                                 ConfigurationManager.AppSettings["MailPassword"]);

            var transportWeb = new Web(credentials);
            await transportWeb.DeliverAsync(myMessage);
        }
    }
}