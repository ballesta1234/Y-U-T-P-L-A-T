using System;
using System.Collections.Generic;
using YUTPLAT.Helpers;
using YUTPLAT.ViewModel;
using System.Linq;
using System.IO;
using System.Configuration;

namespace YUTPLAT.Services.Interface
{
    public abstract class IndicadorAutomaticoStrategy
    {
        public abstract IMedicionService GetMedicionService();        
        public abstract IList<MedicionResultDTO> ObtenerDetallesMediciones(int mes, int anio);
        public abstract string[] GetColumnasExportacion();
        public abstract string GetTituloExportacion(string mes, string anio);

        private Object thisLock = new Object();

        public void EjecutarIndicador(IndicadorViewModel indicadorViewModel)
        {
            lock (thisLock)
            {
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

                MedicionViewModel medicionMes = GetMedicionService().BuscarNoTask(new MedicionViewModel { Grupo = indicadorViewModel.Grupo, Mes = mesAnterior, Anio = anioACalcular }).FirstOrDefault();

                IList<MedicionResultDTO> medicionesNuevas = null;

                // Guardar la medición sólo si no tiene
                if (medicionMes == null)
                {
                    medicionesNuevas = ObtenerDetallesMediciones(mesACalcular, anioACalcular);

                    medicionMes = GetMedicionService().ObtenerMedicionViewModelNoTask(indicadorViewModel.Id, (int)mesAnterior, null, indicadorViewModel.Grupo, anioACalcular, null);
                    medicionMes.FechaCarga = DateTimeHelper.OntenerFechaActual().ToString("dd/MM/yyyy HH:mm tt");
                    medicionMes.UsuarioCargo = "Automático Sistema";
                    medicionMes.Anio = anioACalcular;
                    medicionMes.Valor = ObtenerValorMedicionCPI(medicionesNuevas).ToString().Replace(",", ".").TrimEnd('0').TrimEnd('.');

                    if (string.IsNullOrEmpty(medicionMes.Valor))
                        medicionMes.Valor = "0";

                    medicionMes.MedicionId = GetMedicionService().GuardarMedicionNoTask(medicionMes);
                }

                // Generar excel con el detalle
                GenerarExcel((int)medicionMes.Mes, medicionMes.Anio, indicadorViewModel.Id, (List<MedicionResultDTO>)medicionesNuevas);
            }
        }
        
        public void GenerarExcel(int mes, int anio, int idIndicador, List<MedicionResultDTO> mediciones)
        {
            string archivo = ObtenerPatrArchivoCompleto(anio, mes, idIndicador);
            
            if (!File.Exists(archivo))
            {
                if (mediciones == null)
                {
                    mediciones = (List<MedicionResultDTO>)ObtenerDetallesMediciones(mes, anio);
                }

                List<MedicionExportarDTO> medicionesExportar = (List<MedicionExportarDTO>)AutoMapper.Mapper.Map<IList<MedicionExportarDTO>>(mediciones);

                try
                {
                    string mesStr = EnumHelper<Enums.Enum.Mes>.Parse(mes.ToString()).ToString();

                    string[] columnas = GetColumnasExportacion();
                    string titulo = GetTituloExportacion(mesStr, anio.ToString());

                    FileStream fs = File.Create(archivo);

                    if (medicionesExportar.Count > 0)
                    {
                        byte[] filecontent = ExcelExportHelper.ExportExcel(medicionesExportar, titulo, false, columnas);
                        fs.Write(filecontent, 0, filecontent.Length);
                    }

                    fs.Close();                    
                }
                catch (Exception ex) { }
            }
        }

        public decimal RecalcularIndicador(int mes, int anio, int idIndicador)
        {
            IList<MedicionResultDTO> mediciones = null;

            lock (thisLock)
            {
                try
                {
                    mediciones = ObtenerDetallesMediciones(mes, anio);

                    string archivo = ObtenerPatrArchivoCompleto(anio, mes, idIndicador);
                    
                    if (File.Exists(archivo))
                    {
                        File.Delete(archivo);
                    }

                    GenerarExcel(mes, anio, idIndicador, (List<MedicionResultDTO>)mediciones);
                }
                catch (Exception ex) { }
            }

            return ObtenerValorMedicionCPI(mediciones);
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

        private string ObtenerPatrArchivoCompleto(int anio, int mes, int idIndicador)
        {
            string pathExcels = ConfigurationManager.AppSettings["PathExcelExportacion"];
            string directory = AppDomain.CurrentDomain.BaseDirectory + pathExcels + idIndicador.ToString() + "\\";
            
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string file = anio.ToString() + "_" + mes.ToString() + ".xlsx";

            return directory + file;
        }

        public byte[] ObtenerArchivo(int anio, int mes, int idIndicador)
        {
            string archivo = ObtenerPatrArchivoCompleto(anio, mes, idIndicador);

            byte[] fileBytes = null;

            if (!File.Exists(archivo))
            {
                RecalcularIndicador(mes, anio, idIndicador);
            }

            if (File.Exists(archivo))
            {
                FileStream fs = File.OpenRead(archivo);

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