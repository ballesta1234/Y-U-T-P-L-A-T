using System;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IObjetivoRepository : IDisposable
    {
        IQueryable<Objetivo> GetById(int id);

        IQueryable<Objetivo> Todas();

        IQueryable<Objetivo> Buscar(ObjetivoViewModel filtro);

        Task<int> Guardar(Objetivo objetivo);
    }
}