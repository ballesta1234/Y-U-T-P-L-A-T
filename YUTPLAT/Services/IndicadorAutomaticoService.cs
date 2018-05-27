using System.Collections.Generic;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Linq;
using Hangfire;

namespace YUTPLAT.Services.Interface
{
    public class IndicadorAutomaticoService : IIndicadorAutomaticoService
    {
        private IIndicadorAutomaticoRepository IndicadorAutomaticoRepository { get; set; }

        public IndicadorAutomaticoService(IIndicadorAutomaticoRepository indicadorAutomaticoRepository)
        {
            this.IndicadorAutomaticoRepository = indicadorAutomaticoRepository;
        }
                
        public void GenerarJobsTareasAutomaticas()
        {
            IList<IndicadorAutomaticoViewModel> indicadoresAutomaticos = this.Todos();

            foreach (IndicadorAutomaticoViewModel indicadorAutomatico in indicadoresAutomaticos)
            {
                if (indicadorAutomatico.CategoriaIndicadorAutomatico == Enums.Enum.CategoriaIndicadorAutomatico.CPI)
                {
                    RecurringJob.AddOrUpdate<IndicadorAutomaticoCPIStrategy>(
                       indicadorAutomatico.Nombre,
                       x => x.EjecutarIndicador(indicadorAutomatico.IndicadorViewModel),
                       //Cron.Minutely);
                       Cron.Monthly(5, 1, 0)); // El 5 de cada mes a la 1:00 a.m.
                }
            }
        }

        public void DetenerJob(IndicadorAutomaticoViewModel indicadorAutomatico)
        {
            RecurringJob.RemoveIfExists(indicadorAutomatico.Nombre);
        }

        public void IniciarJob(IndicadorAutomaticoViewModel indicadorAutomatico)
        {
            if (indicadorAutomatico.CategoriaIndicadorAutomatico == Enums.Enum.CategoriaIndicadorAutomatico.CPI)
            {
                RecurringJob.AddOrUpdate<IndicadorAutomaticoCPIStrategy>(
                   indicadorAutomatico.Nombre,
                   x => x.EjecutarIndicador(indicadorAutomatico.IndicadorViewModel),
                   Cron.Minutely);
                //Cron.Monthly(5, 1, 0)); // El 5 de cada mes a la 1:00 a.m.
            }
        }

        public IList<IndicadorAutomaticoViewModel> Todos()
        {
            return AutoMapper.Mapper.Map<IList<IndicadorAutomaticoViewModel>>(IndicadorAutomaticoRepository.Todos().ToList());
        }
    }
}