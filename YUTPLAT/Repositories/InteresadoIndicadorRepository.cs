
using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using System.Collections.Generic;

namespace YUTPLAT.Repositories
{
    public class InteresadoIndicadorRepository : IInteresadoIndicadorRepository
    {
        YutplatDbContext context;

        public InteresadoIndicadorRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<InteresadoIndicador> GetById(int id)
        {
            return this.context.InteresadosIndicador.Where(a => a.InteresadoIndicadorID == id);
        }

        public void Guardar(InteresadoIndicador interesadoIndicador)
        {
            this.context.InteresadosIndicador.AddOrUpdate(interesadoIndicador);
            this.context.SaveChanges();
        }

        public void EliminarPorIndicador(int idIndicador)
        {
            IList<InteresadoIndicador> interesados = this.context.InteresadosIndicador.Where(r => r.IndicadorID == idIndicador).ToList();

            foreach (InteresadoIndicador interesado in interesados)
            {
                this.context.InteresadosIndicador.Remove(interesado);
            }
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}