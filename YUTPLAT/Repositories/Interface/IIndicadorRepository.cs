
using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IIndicadorRepository : IDisposable
    {
        IQueryable<Indicador> GetById(int id);
        
        IQueryable<Indicador> Buscar(BuscarIndicadorViewModel filtro);

        void Guardar(Indicador area);
    }
}