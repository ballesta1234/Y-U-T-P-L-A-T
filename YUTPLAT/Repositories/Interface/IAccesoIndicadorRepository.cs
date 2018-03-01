using System;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories.Interface
{
    public interface IAccesoIndicadorRepository : IDisposable
    {
        IQueryable<AccesoIndicador> GetById(int id);

        Task<int> Guardar(AccesoIndicador  accesoIndicador);

        Task<int> EliminarPorIndicador(int idIndicador);
    }
}