using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Data.Entity.Migrations;
using YUTPLAT.Context;
using System.Threading.Tasks;
using YUTPLAT.Services.Interface;
using Hangfire;

namespace YUTPLAT.Repositories
{
    public class IndicadorAutomaticoRepository : IIndicadorAutomaticoRepository
    {
        YutplatDbContext context;

        public IndicadorAutomaticoRepository(YutplatDbContext context)
        {
            this.context = context;
        }
                
        public IQueryable<IndicadorAutomatico> Todos()
        {
            return this.context.IndicadoresAutomaticos;
        }

        public IQueryable<IndicadorAutomatico> GetByIdIndicador(int idIndicador)
        {
            return this.context.IndicadoresAutomaticos.Where(ia => ia.IndicadorID == idIndicador);
        }

        public async Task<int> Guardar(IndicadorAutomatico indicadorAutomatico)
        {
            this.context.IndicadoresAutomaticos.AddOrUpdate(indicadorAutomatico);
            await this.context.SaveChangesAsync();

            return indicadorAutomatico.Id;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void DetenerJob(IndicadorAutomaticoViewModel indicadorAutomatico)
        {
            RecurringJob.RemoveIfExists(indicadorAutomatico.Nombre);
        }

        public void IniciarJob(IndicadorAutomaticoViewModel indicadorAutomatico)
        {
            switch (indicadorAutomatico.CategoriaIndicadorAutomatico)
            {
                case Enums.Enum.CategoriaIndicadorAutomatico.CPI:
                    RecurringJob.AddOrUpdate<IndicadorAutomaticoCPIStrategy>(
                       indicadorAutomatico.Nombre,
                       x => x.EjecutarIndicador(indicadorAutomatico.IndicadorViewModel),
                       //Cron.Minutely);
                       Cron.Monthly(5, 1, 0)); // El 5 de cada mes a la 1:00 a.m.
                    break;
                case Enums.Enum.CategoriaIndicadorAutomatico.CPI_Servicios:
                    RecurringJob.AddOrUpdate<IndicadorAutomaticoCPIServiciosStrategy>(
                       indicadorAutomatico.Nombre,
                       x => x.EjecutarIndicador(indicadorAutomatico.IndicadorViewModel),
                       //Cron.Minutely);
                       Cron.Monthly(5, 1, 15)); // El 5 de cada mes a la 1:15 a.m.
                    break;
                case Enums.Enum.CategoriaIndicadorAutomatico.CPI_Llave_En_Mano:
                    RecurringJob.AddOrUpdate<IndicadorAutomaticoCPILlaveManoStrategy>(
                       indicadorAutomatico.Nombre,
                       x => x.EjecutarIndicador(indicadorAutomatico.IndicadorViewModel),
                       //Cron.Minutely);
                       Cron.Monthly(5, 1, 30)); // El 5 de cada mes a la 1:30 a.m.
                    break;
            }
        }
    }
}