
using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IFrecuenciaMedicionIndicadorRepository : IDisposable
    {
        IQueryable<FrecuenciaMedicionIndicador> GetById(int id);

        IQueryable<FrecuenciaMedicionIndicador> Todas();

        IQueryable<FrecuenciaMedicionIndicador> Buscar(FrecuenciaMedicionIndicadorViewModel filtro);
    }
}