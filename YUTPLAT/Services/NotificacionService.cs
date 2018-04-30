using System.Threading.Tasks;
using YUTPLAT.Repositories.Interface;
using System;
using System.Net.Mail;
using SendGrid;
using System.Configuration;

namespace YUTPLAT.Services.Interface
{
    public class NotificacionService : INotificacionService
    {
        private INotificacionRepository NotificacionRepository { get; set; }

        public NotificacionService(INotificacionRepository notificacionRepository)
        {
            this.NotificacionRepository = notificacionRepository;
        }

        public async Task Notificar()
        {            
            try
            {
                var myMessage = new SendGridMessage();
                myMessage.AddTo(ConfigurationManager.AppSettings["SendGridToAccountTest"]); 
                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["SendGridFromAccount"], "Y U T P L A T");
                myMessage.Subject = "Asunto Test";
                myMessage.Text = "Cuerpo Test";

                System.Net.NetworkCredential credentials = 
                    new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SendGridUsername"], 
                                                     ConfigurationManager.AppSettings["SendGridPassword"]);

                var transportWeb = new Web(credentials);
                await transportWeb.DeliverAsync(myMessage);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}