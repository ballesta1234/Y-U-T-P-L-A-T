using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using System.Collections.Generic;

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

        public void Guardar(AccesoIndicador accesoIndicador)
        {
            this.context.AccesosIndicadores.AddOrUpdate(accesoIndicador);
            this.context.SaveChanges();
        }

        public void EliminarPorIndicador(int idIndicador)
        {
            IList<AccesoIndicador> accesos = this.context.AccesosIndicadores.Where(r => r.IndicadorID == idIndicador).ToList();

            foreach (AccesoIndicador acceso in accesos)
            {
                this.context.AccesosIndicadores.Remove(acceso);
            }
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}