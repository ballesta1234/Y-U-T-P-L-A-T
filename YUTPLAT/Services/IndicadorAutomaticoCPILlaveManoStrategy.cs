using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;
using System.Linq;

namespace YUTPLAT.Services.Interface
{
    public class IndicadorAutomaticoCPILlaveManoStrategy : IndicadorAutomaticoStrategy, IIndicadorAutomaticoStrategy
    {
        private IMedicionService MedicionService { get; set; }

        public IndicadorAutomaticoCPILlaveManoStrategy(IMedicionService medicionService)
        {
            this.MedicionService = medicionService;
        }

        public override IMedicionService GetMedicionService()
        {
            return this.MedicionService;
        }

        public override IList<MedicionResultDTO> ObtenerDetallesMediciones(int mes, int anio)
        {
            YUTPLATEntities spContext = new YUTPLATEntities();
            return AutoMapper.Mapper.Map<IList<MedicionResultDTO>>(spContext.ObtenerMedicionesPorMesAnioNoServicio(mes, anio).ToList());
        }

        public override string[] GetColumnasExportacion()
        {
            string[] columnas = { "Nombre", "HorasTotales", "Horas", "Mes", "Anio", "EV", "AC", "CPI" };
            return columnas;
        }

        public override string GetTituloExportacion(string mes, string anio)
        {
            string titulo = "Detalle indicador CPI Proyectos llave en mano - " + mes + " - " + anio.ToString();
            return titulo;
        }
    }
}