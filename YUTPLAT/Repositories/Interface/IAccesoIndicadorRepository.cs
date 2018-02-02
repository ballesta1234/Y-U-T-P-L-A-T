
using System;
using System.Linq;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories.Interface
{
    public interface IAccesoIndicadorRepository : IDisposable
    {
        IQueryable<AccesoIndicador> GetById(int id);

        void Guardar(AccesoIndicador  accesoIndicador);

        void EliminarPorIndicador(int idIndicador);
    }
}