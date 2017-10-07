
using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IAreaRepository : IDisposable
    {
        IQueryable<Area> GetById(int id);

        IQueryable<Area> GetByIdObjetivo(int idObjetivo);

        IQueryable<Area> Todas();

        IQueryable<Area> Buscar(AreaViewModel filtro);

        void Guardar(Area area);
    }
}