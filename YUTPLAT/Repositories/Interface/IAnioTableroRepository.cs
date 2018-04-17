using System;
using System.Linq;
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
    }
}