using System.Collections.Generic;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Linq;
using Hangfire;
using YUTPLAT.Models;

namespace YUTPLAT.Services.Interface
{
    public class IndicadorAutomaticoService : IIndicadorAutomaticoService
    {
        private IIndicadorAutomaticoRepository IndicadorAutomaticoRepository { get; set; }

        private IndicadorAutomaticoCPIStrategy IndicadorAutomaticoCPIStrategy { get; set; }
        private IndicadorAutomaticoCPIServiciosStrategy IndicadorAutomaticoCPIServiciosStrategy { get; set; }
        private IndicadorAutomaticoCPILlaveManoStrategy IndicadorAutomaticoCPILlaveManoStrategy { get; set; }

        public IndicadorAutomaticoService(IIndicadorAutomaticoRepository indicadorAutomaticoRepository,
                                          IndicadorAutomaticoCPIStrategy indicadorAutomaticoCPIStrategy,
                                          IndicadorAutomaticoCPIServiciosStrategy indicadorAutomaticoCPIServiciosStrategy,
                                          IndicadorAutomaticoCPILlaveManoStrategy indicadorAutomaticoCPILlaveManoStrategy)
        {
            this.IndicadorAutomaticoRepository = indicadorAutomaticoRepository;

            this.IndicadorAutomaticoCPIStrategy = indicadorAutomaticoCPIStrategy;
            this.IndicadorAutomaticoCPIServiciosStrategy = indicadorAutomaticoCPIServiciosStrategy;
            this.IndicadorAutomaticoCPILlaveManoStrategy = indicadorAutomaticoCPILlaveManoStrategy;
        }

        public void GenerarJobsTareasAutomaticas()
        {
            IList<IndicadorAutomaticoViewModel> indicadoresAutomaticos = this.Todos();

            foreach (IndicadorAutomaticoViewModel indicadorAutomatico in indicadoresAutomaticos)
            {
                switch (indicadorAutomatico.CategoriaIndicadorAutomatico)
                {
                    case Enums.Enum.CategoriaIndicadorAutomatico.CPI:
                        RecurringJob.AddOrUpdate<IndicadorAutomaticoCPIStrategy>(
                           indicadorAutomatico.Nombre,
                           x => x.EjecutarIndicador(indicadorAutomatico.IndicadorViewModel),
                           Cron.Minutely);
                           //Cron.Monthly(5, 1, 0)); // El 5 de cada mes a la 1:00 a.m.
                        break;
                    case Enums.Enum.CategoriaIndicadorAutomatico.CPI_Servicios:
                        RecurringJob.AddOrUpdate<IndicadorAutomaticoCPIServiciosStrategy>(
                           indicadorAutomatico.Nombre,
                           x => x.EjecutarIndicador(indicadorAutomatico.IndicadorViewModel),
                           Cron.Minutely);
                           //Cron.Monthly(5, 1, 15)); // El 5 de cada mes a la 1:15 a.m.
                        break;
                    case Enums.Enum.CategoriaIndicadorAutomatico.CPI_Llave_En_Mano:
                        RecurringJob.AddOrUpdate<IndicadorAutomaticoCPILlaveManoStrategy>(
                           indicadorAutomatico.Nombre,
                           x => x.EjecutarIndicador(indicadorAutomatico.IndicadorViewModel),
                           Cron.Minutely);
                           //Cron.Monthly(5, 1, 30)); // El 5 de cada mes a la 1:30 a.m.
                        break;
                }
            }
        }
        
        public IList<IndicadorAutomaticoViewModel> Todos()
        {
            return AutoMapper.Mapper.Map<IList<IndicadorAutomaticoViewModel>>(IndicadorAutomaticoRepository.Todos().ToList());
        }

        public byte[] ObtenerArchivo(int anio, int mes, int idIndicador)
        {
            return GetStrategy(idIndicador).ObtenerArchivo(anio, mes, idIndicador);
        }

        public decimal RecalcularIndicador(int anio, int mes, int idIndicador)
        {
            return GetStrategy(idIndicador).RecalcularIndicador(mes, anio, idIndicador);
        }

        private IIndicadorAutomaticoStrategy GetStrategy(int idIndicador)
        {
            IndicadorAutomatico automatico = IndicadorAutomaticoRepository.GetByIdIndicador(idIndicador).First();

            switch (automatico.CategoriaIndicadorAutomatico)
            {
                case Enums.Enum.CategoriaIndicadorAutomatico.CPI:
                    return IndicadorAutomaticoCPIStrategy;
                case Enums.Enum.CategoriaIndicadorAutomatico.CPI_Servicios:
                    return IndicadorAutomaticoCPIServiciosStrategy;
                case Enums.Enum.CategoriaIndicadorAutomatico.CPI_Llave_En_Mano:
                    return IndicadorAutomaticoCPILlaveManoStrategy;
                default:
                    return null;
            }
        }
    }
}