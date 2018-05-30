using System;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IAuditoriaRepository : IDisposable
    {
        IQueryable<Auditoria> Buscar(AuditoriaViewModel filtro);
        Task<int> Guardar(Auditoria area);
    }
}