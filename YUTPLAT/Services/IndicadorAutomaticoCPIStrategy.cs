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
                YUTPLAT_DESAEntities spContext = new YUTPLAT_DESAEntities();

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

                IList<Medicion> medicionesNuevas = AutoMapper.Mapper.Map<IList<Medicion>>(spContext.ObtenerTodasMediciones().ToList());

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
                List<MedicionExportarDTO> mediciones = (List<MedicionExportarDTO>)ObtenerDetallesMediciones();

                string[] columnas = { "Proyecto", "Mes", "Valor" };
                byte[] filecontent = ExcelExportHelper.ExportExcel(mediciones, "Detalles Indicador CPI", false, columnas);
                
                using (FileStream fs = File.Create(tempDirectory + file))
                {
                    fs.Write(filecontent, 0, filecontent.Length);
                }

                medicionMes.ArchivoGenerado = true;
                MedicionService.Guardar(medicionMes);
            }
        }
        
        public decimal RecalcularIndicador(int mes)
        {
            ObjectParameter valorOtuput = new ObjectParameter("ValorOutput", typeof(decimal));

            YUTPLAT_DESAEntities spContext = new YUTPLAT_DESAEntities();
            spContext.ObtenerMedicionPorMes(mes, valorOtuput);

            return decimal.Parse(valorOtuput.Value.ToString());
        }

        public IList<MedicionExportarDTO> ObtenerDetallesMediciones()
        {
            YUTPLAT_DESAEntities spContext = new YUTPLAT_DESAEntities();
            return AutoMapper.Mapper.Map<IList<MedicionExportarDTO>>(spContext.ObtenerDetallesMediciones().ToList());
        }
    }
}