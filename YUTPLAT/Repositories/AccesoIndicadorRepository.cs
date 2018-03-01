using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace YUTPLAT.Repositories
{
    public class AccesoIndicadorRepository : IAccesoIndicadorRepository
    {
        YutplatDbContext context;

        public AccesoIndicadorRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<AccesoIndicador> GetById(int id)
        {
            return this.context.AccesosIndicadores.Where(a => a.AccesoIndicadorID == id);
        }

        public async Task<int> Guardar(AccesoIndicador accesoIndicador)
        {
            this.context.AccesosIndicadores.AddOrUpdate(accesoIndicador);
            await this.context.SaveChangesAsync();
            return accesoIndicador.AccesoIndicadorID;
        }

        public async Task<int> EliminarPorIndicador(int idIndicador)
        {
            IList<AccesoIndicador> accesos = await this.context.AccesosIndicadores.Where(r => r.IndicadorID == idIndicador).ToListAsync();

            foreach (AccesoIndicador acceso in accesos)
            {
                this.context.AccesosIndicadores.Remove(acceso);
            }

            await this.context.SaveChangesAsync();

            return idIndicador;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}