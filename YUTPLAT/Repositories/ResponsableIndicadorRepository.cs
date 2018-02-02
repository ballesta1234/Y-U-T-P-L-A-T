using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using System.Collections.Generic;

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

        public void Guardar(ResponsableIndicador responsableIndicador)
        {
            this.context.ResponsablesIndicador.AddOrUpdate(responsableIndicador);
            this.context.SaveChanges();
        }

        public void EliminarPorIndicador(int idIndicador)
        {
            IList<ResponsableIndicador> responsables = this.context.ResponsablesIndicador.Where(r => r.IndicadorID == idIndicador).ToList();

            foreach (ResponsableIndicador responsable in responsables)
            {
                this.context.ResponsablesIndicador.Remove(responsable);           
            }
            this.context.SaveChanges();
        }
        
        public void Dispose()
        {
            context.Dispose();
        }
    }
}