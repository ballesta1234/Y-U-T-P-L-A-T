using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories.Interface
{
    public interface IInteresadoIndicadorRepository : IDisposable
    {
        IQueryable<InteresadoIndicador> GetById(int id);
        
        Task<int> Guardar(InteresadoIndicador interesadoIndicador);

        Task<int> EliminarPorIndicador(int idIndicador);
    }
}