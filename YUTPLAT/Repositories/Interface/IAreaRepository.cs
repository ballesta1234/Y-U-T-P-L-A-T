
using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IAreaRepository : IDisposable
    {
        IQueryable<Area> Todas();

        IQueryable<Area> Buscar(AreaViewModel filtro);
    }
}