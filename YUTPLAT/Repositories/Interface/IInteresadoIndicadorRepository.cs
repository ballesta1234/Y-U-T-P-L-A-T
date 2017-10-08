
using System;
using System.Collections.Generic;
using System.Linq;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories.Interface
{
    public interface IInteresadoIndicadorRepository : IDisposable
    {
        IQueryable<InteresadoIndicador> GetById(int id);
        
        void Guardar(InteresadoIndicador interesadoIndicador);

        void EliminarPorIndicador(int idIndicador);
    }
}