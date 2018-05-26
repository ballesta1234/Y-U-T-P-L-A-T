using System;
using System.Threading.Tasks;

namespace YUTPLAT.Services.Interface
{
    public class MailDatabaseStrategy : IMailStrategy
    {
        public async Task EnviarCorreo(string para, string asunto, string cuerpo)
        {
            throw new NotImplementedException();
        }
    }
}