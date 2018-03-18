﻿using System.Collections.Generic;
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
                       Cron.Minutely);
                }
            }
        }

        public IList<IndicadorAutomaticoViewModel> Todos()
        {
            return AutoMapper.Mapper.Map<IList<IndicadorAutomaticoViewModel>>(IndicadorAutomaticoRepository.Todos().ToList());
        }
    }
}