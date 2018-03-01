using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public async Task<int> Guardar(InteresadoIndicador interesadoIndicador)
        {
            this.context.InteresadosIndicador.AddOrUpdate(interesadoIndicador);
            await this.context.SaveChangesAsync();
            return interesadoIndicador.InteresadoIndicadorID;
        }

        public async Task<int> EliminarPorIndicador(int idIndicador)
        {
            IList<InteresadoIndicador> interesados = await this.context.InteresadosIndicador.Where(r => r.IndicadorID == idIndicador).ToListAsync();

            foreach (InteresadoIndicador interesado in interesados)
            {
                this.context.InteresadosIndicador.Remove(interesado);
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