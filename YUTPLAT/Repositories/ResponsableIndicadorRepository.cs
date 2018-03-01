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
    public class ResponsableIndicadorRepository : IResponsableIndicadorRepository
    {
        YutplatDbContext context;

        public ResponsableIndicadorRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ResponsableIndicador> GetById(int id)
        {
            return this.context.ResponsablesIndicador.Where(a => a.ResponsableIndicadorID == id);
        }

        public async Task<int> Guardar(ResponsableIndicador responsableIndicador)
        {
            this.context.ResponsablesIndicador.AddOrUpdate(responsableIndicador);
            await this.context.SaveChangesAsync();
            return responsableIndicador.ResponsableIndicadorID;
        }

        public async Task<int> EliminarPorIndicador(int idIndicador)
        {
            IList<ResponsableIndicador> responsables = await this.context.ResponsablesIndicador.Where(r => r.IndicadorID == idIndicador).ToListAsync();

            foreach (ResponsableIndicador responsable in responsables)
            {
                this.context.ResponsablesIndicador.Remove(responsable);           
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