using System;
using System.Collections.Generic;
using YUTPLAT.Helpers;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;
using System.Linq;
using System.IO;
using System.Configuration;

namespace YUTPLAT.Services.Interface
{
    public class IndicadorAutomaticoCPIServiciosStrategy : IIndicadorAutomaticoStrategy
    {
        private IMedicionService MedicionService { get; set; }

        public IndicadorAutomaticoCPIServiciosStrategy(IMedicionService medicionService)
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

                MedicionViewModel medicionMes = this.MedicionService.BuscarNoTask(new MedicionViewModel { Grupo = indicadorViewModel.Grupo, Mes = mesAnterior, Anio = anioACalcular }).FirstOrDefault();

                IList<MedicionResultDTO> medicionesNuevas = null;

                // Guardar la medición sólo si no tiene
                if (medicionMes == null)
                {
                    medicionesNuevas = ObtenerDetallesMediciones(mesACalcular, anioACalcular);

                    medicionMes = MedicionService.ObtenerMedicionViewModelNoTask(indicadorViewModel.Id, (int)mesAnterior, null, indicadorViewModel.Grupo, anioACalcular, null);
                    medicionMes.FechaCarga = DateTimeHelper.OntenerFechaActual().ToString("dd/MM/yyyy HH:mm tt");
                    medicionMes.UsuarioCargo = "Automático Sistema";
                    medicionMes.Anio = anioACalcular;
                    medicionMes.Valor = ObtenerValorMedicionCPI(medicionesNuevas).ToString().Replace(",", ".").TrimEnd('0').TrimEnd('.');

                    if (string.IsNullOrEmpty(medicionMes.Valor))
                        medicionMes.Valor = "0";

                    medicionMes.MedicionId = MedicionService.GuardarMedicionNoTask(medicionMes);
                }

                // Generar excel con el detalle
                GenerarExcel((int)medicionMes.Mes, medicionMes.Anio, (List<MedicionResultDTO>)medicionesNuevas);
            }
        }

        public void GenerarExcel(int mes, int anio, List<MedicionResultDTO> mediciones)
        {
            string tempDirectory = AppDomain.CurrentDomain.BaseDirectory + "Temp/";
            string file = anio.ToString() + "_" + mes.ToString() + ".xlsx";

            if (!File.Exists(tempDirectory + file))
            {
                if (mediciones == null)
                {
                    mediciones = (List<MedicionResultDTO>)ObtenerDetallesMediciones(mes, anio);
                }

                List<MedicionExportarDTO> medicionesExportar = (List<MedicionExportarDTO>)AutoMapper.Mapper.Map<IList<MedicionExportarDTO>>(mediciones);

                try
                {
                    string mesStr = EnumHelper<Enums.Enum.Mes>.Parse(mes.ToString()).ToString();
                    string[] columnas = { "Nombre", "HorasTotales", "Horas", "Mes", "Anio", "EV", "AC", "CPI" };
                    string titulo = "Detalle indicador CPI - " + mesStr + " - " + anio.ToString();

                    byte[] filecontent = ExcelExportHelper.ExportExcel(medicionesExportar, titulo, false, columnas);

                    using (FileStream fs = File.Create(tempDirectory + file))
                    {
                        fs.Write(filecontent, 0, filecontent.Length);
                        fs.Close();
                    }
                }
                catch (Exception ex) { }
            }
        }

        public decimal RecalcularIndicador(int mes, int anio)
        {
            IList<MedicionResultDTO> mediciones = null;

            lock (thisLock)
            {
                try
                {
                    mediciones = ObtenerDetallesMediciones(mes, anio);

                    string tempDirectory = AppDomain.CurrentDomain.BaseDirectory + "Temp/";
                    string file = anio.ToString() + "_" + mes.ToString() + ".xlsx";

                    if (File.Exists(tempDirectory + file))
                    {                        
                        File.Delete(tempDirectory + file);
                    }

                    GenerarExcel(mes, anio, (List<MedicionResultDTO>)mediciones);
                }
                catch(Exception ex) { }             
            }
            
            return ObtenerValorMedicionCPI(mediciones);
        }

        private IList<MedicionResultDTO> ObtenerDetallesMediciones(int mes, int anio)
        {
            YUTPLATEntities spContext = new YUTPLATEntities();
            return AutoMapper.Mapper.Map<IList<MedicionResultDTO>>(spContext.ObtenerMedicionesPorMesAnioServicio(mes, anio).ToList());
        }

        private decimal ObtenerValorMedicionCPI(IList<MedicionResultDTO> mediciones)
        {
            decimal suma = 0;
            int sumaHoras = 0;

            foreach (MedicionResultDTO medicion in mediciones)
            {
                if (medicion.CPI != null && medicion.CPI.Value != 0)
                {
                    suma += medicion.CPI.Value * medicion.Horas.Value;
                    sumaHoras += medicion.Horas.Value;
                }
            }

            if (sumaHoras != 0)
                return decimal.Round(suma / sumaHoras, 2);
            else
                return 0;
        }

        public byte[] ObtenerArchivo(int anio, int mes, int idIndicador)
        {
            string pathExcels = ConfigurationManager.AppSettings["PathExcelExportacion"];

            string directory = AppDomain.CurrentDomain.BaseDirectory + pathExcels + idIndicador.ToString();
            string file = anio.ToString() + "_" + mes.ToString() + ".xlsx";

            byte[] fileBytes = null;

            if (!File.Exists(directory + file))
            {
                RecalcularIndicador(mes, anio);
            }

            if (File.Exists(directory + file))
            {
                FileStream fs = File.OpenRead(directory + file);

                byte[] buffer = new byte[4096];

                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                int chunkSize = 0;

                do
                {
                    chunkSize = fs.Read(buffer, 0, buffer.Length);
                    memoryStream.Write(buffer, 0, chunkSize);
                } while (chunkSize != 0);

                fs.Close();

                fileBytes = memoryStream.ToArray();
            }

            return fileBytes;
        }
    }
}