
using System;
using System.Linq;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories.Interface
{
    public interface IResponsableIndicadorRepository : IDisposable
    {
        IQueryable<ResponsableIndicador> GetById(int id);
        
        void Guardar(ResponsableIndicador responsableIndicador);

        void EliminarPorIndicador(int idIndicador);
    }
}