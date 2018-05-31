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
    public class AuditoriaRepository : IAuditoriaRepository
    {
        YutplatDbContext context;

        public AuditoriaRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public async Task<int>  Guardar(Auditoria auditoria)
        {
            this.context.Auditorias.AddOrUpdate(auditoria);
            await this.context.SaveChangesAsync();

            return auditoria.Id;
        }

        public IQueryable<Auditoria> Buscar(AuditoriaViewModel filtro)
        {
            IQueryable<Auditoria> queryable = this.context.Auditorias;

            if (filtro.TipoAuditoria != null)
            {
                queryable = queryable.Where(a => (int)a.TipoAuditoria == (int)filtro.TipoAuditoria);
            }
            if (filtro.FechaCreacion != null)
            {   
                queryable = queryable.Where(a => a.FechaCreacion >= filtro.FechaCreacion.Value);

                DateTime hasta = filtro.FechaCreacion.Value.AddDays(1).AddSeconds(-1);
                queryable = queryable.Where(a => a.FechaCreacion <= hasta);
            }
            if (filtro.UsuarioViewModel != null && !string.IsNullOrEmpty(filtro.UsuarioViewModel.NombreUsuario))
            {
                queryable = queryable.Where(a => a.Usuario.UserName.Equals(filtro.UsuarioViewModel.NombreUsuario));
            }

            return queryable;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}