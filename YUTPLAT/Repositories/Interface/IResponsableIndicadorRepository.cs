using System;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories.Interface
{
    public interface IResponsableIndicadorRepository : IDisposable
    {
        IQueryable<ResponsableIndicador> GetById(int id);
        
        Task<int> Guardar(ResponsableIndicador responsableIndicador);

        Task<int> EliminarPorIndicador(int idIndicador);
    }
}