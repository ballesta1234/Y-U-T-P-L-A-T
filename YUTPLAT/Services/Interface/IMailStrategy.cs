using System.Threading.Tasks;

namespace YUTPLAT.Services.Interface
{
    public interface IMailStrategy
    {
        Task EnviarCorreo(string para, string asunto, string cuerpo);        
    }
}