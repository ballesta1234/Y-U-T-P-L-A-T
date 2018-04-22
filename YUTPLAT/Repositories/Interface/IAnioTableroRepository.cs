using System;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IAnioTableroRepository : IDisposable
    {
        IQueryable<AnioTablero> GetById(int id);
        IQueryable<AnioTablero> GetActual();
        IQueryable<AnioTablero> TodosHabilitados();
        IQueryable<AnioTablero> Buscar(AnioTableroViewModel filtro);

        Task<int> HabilitarAnio(int anio);
    }
}