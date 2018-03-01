using System;
using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;

namespace Hangfire.Highlighter.Jobs
{
    public class SnippetHighlighter
    {
        
        public SnippetHighlighter()
        { }
        
        public async Task CleanUpAsync()
        {
            try
            {
                var myMessage = new SendGridMessage();
                myMessage.AddTo("yutplat@gmail.com");
                myMessage.From = new MailAddress("you@youremail.com", "First Last");
                myMessage.Subject = "Hola!!!";
                myMessage.Text = "Aaaaaaaaaaaaaaaa";

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_39d431228d7223a382b59a41fb7d87c1@azure.com", "Parva1Domus");
                var transportWeb = new Web(credentials);
                await transportWeb.DeliverAsync(myMessage);
                // NOTE: If you're developing a Console Application, 
                // use the following so that the API call has time to complete
                // transportWeb.DeliverAsync(myMessage).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


    }
}
