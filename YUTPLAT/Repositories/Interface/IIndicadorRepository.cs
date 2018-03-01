using System;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IIndicadorRepository : IDisposable
    {
        IQueryable<Indicador> GetById(int id);
        
        IQueryable<Indicador> Buscar(BuscarIndicadorViewModel filtro);

        Task<int> Guardar(Indicador area);
    }
}