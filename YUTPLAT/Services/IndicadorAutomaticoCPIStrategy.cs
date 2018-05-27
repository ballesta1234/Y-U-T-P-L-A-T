using System;
using System.Collections.Generic;
using YUTPLAT.Helpers;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.IO;

namespace YUTPLAT.Services.Interface
{
    public class IndicadorAutomaticoCPIStrategy : IIndicadorAutomaticoStrategy
    {
        private IMedicionService MedicionService { get; set; }

        public IndicadorAutomaticoCPIStrategy(IMedicionService medicionService)
        {
            this.MedicionService = medicionService;
        }

        private Object thisLock = new Object();

        public void EjecutarIndicador(IndicadorViewModel indicadorViewModel)
        {
            lock (thisLock)
            {
                YUTPLATEntities spContext = new YUTPLATEntities();

                int mesACalcular = 0;
                int anioACalcular = 0;

                if (DateTimeHelper.OntenerFechaActual().Month == 1)
                {
                    mesACalcular = 12;
                    anioACalcular = DateTimeHelper.OntenerFechaActual().Year - 1;
                }
                else
                {
                    mesACalcular = DateTimeHelper.OntenerFechaActual().Month - 1;
                    anioACalcular = DateTimeHelper.OntenerFechaActual().Year;
                }

                // Calcular las mediciones del mes anterior
                Enums.Enum.Mes mesAnterior = Helpers.EnumHelper<Enums.Enum.Mes>.Parse(mesACalcular.ToString());

                //corregir
                IList<Medicion> medicionesNuevas = AutoMapper.Mapper.Map<IList<Medicion>>(spContext.ObtenerMedicionesPorMesAnio(mesACalcular, anioACalcular).ToList());

                Medicion medicionNuevaMes = medicionesNuevas.First(mn => (int)mn.Mes == mesACalcular);
                
                MedicionViewModel medicionMes = this.MedicionService.BuscarNoTask(new MedicionViewModel { Grupo = indicadorViewModel.Grupo, Mes = mesAnterior, Anio = anioACalcular }).FirstOrDefault();

                // Guardar la medición sólo si no tiene
                if (medicionMes == null)
                {
                    medicionMes = MedicionService.ObtenerMedicionViewModelNoTask(indicadorViewModel.Id, (int)mesAnterior, null, indicadorViewModel.Grupo, anioACalcular, null);
                    medicionMes.FechaCarga = DateTimeHelper.OntenerFechaActual().ToString("dd/MM/yyyy HH:mm tt");
                    medicionMes.UsuarioCargo = "Automático Sistema";
                    medicionMes.Anio = anioACalcular;
                    medicionMes.Valor = medicionNuevaMes.Valor.ToString().Replace(",", ".").TrimEnd('0').TrimEnd('.');

                    medicionMes.MedicionId = MedicionService.GuardarMedicionNoTask(medicionMes);
                }

                // Generar excel con el detalle
                GenerarExcel(medicionMes);
            }
        }

        public void GenerarExcel(MedicionViewModel medicionMes)
        {   
            string tempDirectory = AppDomain.CurrentDomain.BaseDirectory + "Temp/";
            string file = medicionMes.Anio.ToString() + "_" + ((int)medicionMes.Mes).ToString() + ".xlsx";

            if (!File.Exists(tempDirectory + file))
            {
                List<MedicionExportarDTO> mediciones = (List<MedicionExportarDTO>)ObtenerDetallesMediciones((int)medicionMes.Mes, medicionMes.Anio);

                string[] columnas = { "Nombre", "HorasTotales", "Horas" };
                byte[] filecontent = ExcelExportHelper.ExportExcel(mediciones, "Detalles Indicador CPI", false, columnas);
                
                using (FileStream fs = File.Create(tempDirectory + file))
                {
                    fs.Write(filecontent, 0, filecontent.Length);
                }

                medicionMes.ArchivoGenerado = true;
                MedicionService.Guardar(medicionMes);
            }
        }
        
        public decimal RecalcularIndicador(int mes, int anio)
        {
            YUTPLATEntities spContext = new YUTPLATEntities();
            spContext.ObtenerMedicionesPorMesAnio(mes, anio);

            return decimal.Parse("1");
        }

        public IList<MedicionExportarDTO> ObtenerDetallesMediciones(int mes, int anio)
        {
            YUTPLATEntities spContext = new YUTPLATEntities();
            return AutoMapper.Mapper.Map<IList<MedicionExportarDTO>>(spContext.ObtenerMedicionesPorMesAnio(mes, anio).ToList());
        }
    }
}