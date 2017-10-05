
using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;

namespace YUTPLAT.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        YutplatDbContext context;

        public AreaRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Area> GetById(int id)
        {
            return this.context.Areas.Where(a => a.Id == id);
        }

        public void Guardar(Area area)
        {
            this.context.Areas.AddOrUpdate(area);
            this.context.SaveChanges();
        }

        public IQueryable<Area> Todas()
        {
            return this.context.Areas;
        }

        public IQueryable<Area> Buscar(AreaViewModel filtro)
        {
            IQueryable<Area> queryable = this.context.Areas;

            if (filtro.Nombre != null && !string.IsNullOrEmpty(filtro.Nombre.Trim()))
            {
                queryable = queryable.Where(a => a.Nombre.Contains(filtro.Nombre.Trim()));
            }
            if (!string.IsNullOrEmpty(filtro.FechaCreacion))
            {
                DateTime desde = DateTime.Parse(filtro.FechaCreacion);
                queryable = queryable.Where(a => a.FechaCreacion >= desde);

                DateTime hasta = desde.AddDays(1).AddSeconds(-1);
                queryable = queryable.Where(a => a.FechaCreacion <= hasta);
            }
            if (filtro.UltimoUsuarioModifico != null && !string.IsNullOrEmpty(filtro.UltimoUsuarioModifico.Trim()))
            {
                queryable = queryable.Where(a => a.UltimoUsuarioModifico.Contains(filtro.UltimoUsuarioModifico.Trim()));
            }
            if (!string.IsNullOrEmpty(filtro.FechaUltimaModificacion))
            {
                DateTime desde = DateTime.Parse(filtro.FechaUltimaModificacion);
                queryable = queryable.Where(a => a.FechaUltimaModificacion >= desde);

                DateTime hasta = desde.AddDays(1).AddSeconds(-1);
                queryable = queryable.Where(a => a.FechaUltimaModificacion <= hasta);
            }

            return queryable;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}