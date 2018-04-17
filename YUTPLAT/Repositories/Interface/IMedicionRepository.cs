using System;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IMedicionRepository : IDisposable
    {
        IQueryable<Medicion> GetById(int id);        

        IQueryable<Medicion> Todas(int anio);

        IQueryable<Medicion> Buscar(MedicionViewModel filtro);

        Task<int> Guardar(Medicion medicion);
    }
}