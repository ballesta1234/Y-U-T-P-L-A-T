
using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using System.Threading.Tasks;

namespace YUTPLAT.Repositories
{
    public class ObjetivoRepository : IObjetivoRepository
    {
        YutplatDbContext context;

        public ObjetivoRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Objetivo> GetById(int id)
        {
            return this.context.Objetivos.Where(a => a.Id == id);
        }

        public async Task<int> Guardar(Objetivo objetivo)
        {
            this.context.Objetivos.AddOrUpdate(objetivo);
            await this.context.SaveChangesAsync();
            return objetivo.Id;
        }

        public IQueryable<Objetivo> Todas()
        {
            return this.context.Objetivos;
        }

        public IQueryable<Objetivo> Buscar(ObjetivoViewModel filtro)
        {
            IQueryable<Objetivo> queryable = this.context.Objetivos;

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
            if (filtro.IdArea != null && !string.IsNullOrEmpty(filtro.IdArea.Trim()))
            {
                int areaId = Int32.Parse(filtro.IdArea.Trim());
                queryable = queryable.Where(a => a.AreaID == areaId);
            }

            return queryable;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}