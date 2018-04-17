using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using System.Data.Entity;
using YUTPLAT.Helpers;
using System.Threading.Tasks;

namespace YUTPLAT.Repositories
{
    public class IndicadorRepository : IIndicadorRepository
    {
        YutplatDbContext context;

        public IndicadorRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Indicador> GetById(int id)
        {
            return this.context.Indicadores
                .Include(i => i.MetaAceptable)
                .Include(i => i.MetaAMejorar)
                .Include(i => i.MetaExcelente)
                .Include(i => i.MetaInaceptable)
                .Include(i => i.MetaSatisfactoria)
                .Where(i => i.IndicadorID == id);
        }

        public async Task<int> Guardar(Indicador indicador)
        {
            this.context.Indicadores.AddOrUpdate(indicador);
            await this.context.SaveChangesAsync();
            return indicador.IndicadorID;
        }
        
        public IQueryable<Indicador> Buscar(BuscarIndicadorViewModel filtro)
        {
            string rolAdmin = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Admin);

            IQueryable<Indicador> queryable = this.context.Indicadores;

            if (filtro.UltimoDeCadaGrupo)
            {
                queryable = queryable.GroupBy(i => i.Grupo)
                        .Select(grp => new
                        {
                            grp.Key,
                            LastAccess = grp.OrderByDescending(x => x.FechaCreacion).FirstOrDefault()
                        }).Select(g => g.LastAccess);
            }

            if (filtro.AnioTablero > 0)
            {
                queryable = queryable.Where(a => a.FechaValidez == null || a.FechaValidez.Value.Year == filtro.AnioTablero);
            }
            if (filtro.Busqueda.Nombre != null && !string.IsNullOrEmpty(filtro.Busqueda.Nombre.Trim()))
            {
                queryable = queryable.Where(a => a.Nombre.Contains(filtro.Busqueda.Nombre.Trim()));
            }
            if (!string.IsNullOrEmpty(filtro.Busqueda.FechaCreacion))
            {
                DateTime desde = DateTime.Parse(filtro.Busqueda.FechaCreacion);
                queryable = queryable.Where(a => a.FechaCreacion >= desde);

                DateTime hasta = desde.AddDays(1).AddSeconds(-1);
                queryable = queryable.Where(a => a.FechaCreacion <= hasta);
            }
            if (filtro.Busqueda.UltimoUsuarioModifico != null && !string.IsNullOrEmpty(filtro.Busqueda.UltimoUsuarioModifico.Trim()))
            {
                queryable = queryable.Where(a => a.UltimoUsuarioModifico.Contains(filtro.Busqueda.UltimoUsuarioModifico.Trim()));
            }
            if (!string.IsNullOrEmpty(filtro.Busqueda.FechaUltimaModificacion))
            {
                DateTime desde = DateTime.Parse(filtro.Busqueda.FechaUltimaModificacion);
                queryable = queryable.Where(a => a.FechaUltimaModificacion >= desde);

                DateTime hasta = desde.AddDays(1).AddSeconds(-1);
                queryable = queryable.Where(a => a.FechaUltimaModificacion <= hasta);
            }
            if (filtro.Busqueda.AreaID != null && !string.IsNullOrEmpty(filtro.Busqueda.AreaID.Trim()))
            {
                int areaId = Int32.Parse(filtro.Busqueda.AreaID.Trim());
                queryable = queryable.Where(a => a.Objetivo.AreaID == areaId);
            }
            if (filtro.Busqueda.ObjetivoID != null && !string.IsNullOrEmpty(filtro.Busqueda.ObjetivoID.Trim()))
            {
                int objetivoId = Int32.Parse(filtro.Busqueda.ObjetivoID.Trim());
                queryable = queryable.Where(a => a.ObjetivoID == objetivoId);
            }
            if (filtro.Busqueda.Grupo != 0)
            {                
                queryable = queryable.Where(a => a.Grupo == filtro.Busqueda.Grupo);
            }
            if (filtro.Busqueda.Id != 0)
            {
                queryable = queryable.Where(a => a.IndicadorID == filtro.Busqueda.Id);
            }
            if (filtro.RolUsuario != null && !filtro.RolUsuario.Equals(rolAdmin))
            {
                queryable = queryable.Where( a => a.Responsables.Any( r => r.Persona.UserName.Equals(filtro.NombreUsuario)) ||
                                                  a.Interesados.Any(i => i.Persona.UserName.Equals(filtro.NombreUsuario)));
            }
            
            return queryable;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}