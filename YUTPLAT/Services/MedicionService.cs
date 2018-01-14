
using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;
using static YUTPLAT.Enums.Enum;
using System;
using YUTPLAT.Helpers;

namespace YUTPLAT.Services.Interface
{
    public class MedicionService : IMedicionService
    {
        public static readonly string[] ColorMetaInaceptableExcelente = { "#DF0101", "#F79F81", "#F7FE2E", "#81F781", "#0B610B" };
        public static readonly string[] ColorMetaExcelenteInaceptable = { "#0B610B", "#81F781", "#F7FE2E", "#F79F81", "#DF0101" };

        private IMedicionRepository MedicionRepository { get; set; }
        private IIndicadorRepository IndicadorRepository { get; set; }

        public MedicionService(IMedicionRepository medicionRepository, IIndicadorRepository indicadorRepository)
        {
            this.MedicionRepository = medicionRepository;
            this.IndicadorRepository = indicadorRepository;
        }

        public MedicionViewModel GetById(string id)
        {
            return AutoMapper.Mapper.Map<MedicionViewModel>(MedicionRepository.GetById(id).First());
        }

        public IList<MedicionViewModel> Todas()
        {
            return AutoMapper.Mapper.Map<IList<MedicionViewModel>>(MedicionRepository.Todas().ToList());
        }

        public IList<MedicionViewModel> Buscar(MedicionViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<MedicionViewModel>>(MedicionRepository.Buscar(filtro).ToList());
        }

        public GaugeViewModel ObtenerGaugeViewModel(int idIndicador)
        {
            MedicionViewModel filtro = new MedicionViewModel();
            filtro.IndicadorID = idIndicador;

            IList<MedicionViewModel> medicionesViewModel = Buscar(filtro);

            GaugeViewModel gaugeViewModel = new GaugeViewModel();


            if (medicionesViewModel != null && medicionesViewModel.Count > 0)
            {
                MedicionViewModel ultimaMedicionCargada = medicionesViewModel.OrderBy(m => m.Mes).Reverse().First();

                gaugeViewModel.NombreMes = ultimaMedicionCargada.Mes.ToString();
                gaugeViewModel.NombreIndicador = ultimaMedicionCargada.IndicadorViewModel.Nombre;
                gaugeViewModel.Valor = ultimaMedicionCargada.Valor;

                CompletarEscalasGauge(gaugeViewModel, ultimaMedicionCargada);
            }

            return gaugeViewModel;
        }

        private EscalaGraficosViewModel ObtenerEscalasGrafico(MedicionViewModel medicion)
        {
            EscalaGraficosViewModel escalas = new EscalaGraficosViewModel();

            decimal valorExcelente =
                ObtenerValorEscala(medicion.IndicadorViewModel.MetaExcelenteViewModel, medicion.IndicadorViewModel.MetaSatisfactoriaViewModel);

            decimal valorSatisfactorio =
                ObtenerValorEscala(medicion.IndicadorViewModel.MetaSatisfactoriaViewModel, medicion.IndicadorViewModel.MetaAceptableViewModel);

            decimal valorAceptable =
                ObtenerValorEscala(medicion.IndicadorViewModel.MetaAceptableViewModel, medicion.IndicadorViewModel.MetaAMejorarViewModel);

            decimal valorAMejorar =
                ObtenerValorEscala(medicion.IndicadorViewModel.MetaAMejorarViewModel, medicion.IndicadorViewModel.MetaInaceptableViewModel);

            if (valorExcelente > valorSatisfactorio)
            {
                decimal maximoEscala = (!string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1) && decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1.Replace(".", ",")) > valorExcelente ? decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor2.Replace(".", ",")));
                decimal minimoEscala = (!string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1) && decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1.Replace(".", ",")) < valorAMejorar ? decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor2.Replace(".", ",")));

                if (minimoEscala > 0)
                    minimoEscala = 0;

                escalas.EscalaValores = new decimal[6] { minimoEscala, valorAMejorar, valorAceptable, valorSatisfactorio, valorExcelente, maximoEscala };
                escalas.EscalaColores = ColorMetaInaceptableExcelente;
            }
            else
            {
                decimal maximoEscala = (!string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1) && decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1.Replace(".", ",")) > valorAMejorar ? decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor2.Replace(".", ",")));
                decimal minimoEscala = (!string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1) && decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1.Replace(".", ",")) < valorExcelente ? decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor2.Replace(".", ",")));


                if (minimoEscala > 0)
                    minimoEscala = 0;

                escalas.EscalaValores = new decimal[6] { minimoEscala, valorExcelente, valorSatisfactorio, valorAceptable, valorAMejorar, maximoEscala };
                escalas.EscalaColores = ColorMetaExcelenteInaceptable;
            }

            return escalas;
        }

        private void CompletarEscalasGauge(GaugeViewModel gauge, MedicionViewModel medicion)
        {
            EscalaGraficosViewModel escalas = ObtenerEscalasGrafico(medicion);
            gauge.Escala = escalas.EscalaValores;
            gauge.Colores = escalas.EscalaColores;       
        }
        
        private decimal ObtenerValorEscala(MetaViewModel meta1, MetaViewModel meta2)
        {
            decimal valor = 0;
             
            if (!string.IsNullOrEmpty(meta1.Valor1) && !string.IsNullOrEmpty(meta2.Valor1))
            {
                if (decimal.Parse(meta1.Valor1.Replace(".", ",")) == decimal.Parse(meta2.Valor1.Replace(".", ",")))
                    valor = decimal.Parse(meta1.Valor1.Replace(".", ","));                 
            }

            if (!string.IsNullOrEmpty(meta1.Valor2) && !string.IsNullOrEmpty(meta2.Valor2))
            {
                if (decimal.Parse(meta1.Valor2.Replace(".", ",")) == decimal.Parse(meta2.Valor2.Replace(".", ",")))
                    valor = decimal.Parse(meta1.Valor2.Replace(".", ","));
            }

            if (!string.IsNullOrEmpty(meta1.Valor1) && !string.IsNullOrEmpty(meta2.Valor2))
            {
                if (decimal.Parse(meta1.Valor1.Replace(".", ",")) == decimal.Parse(meta2.Valor2.Replace(".", ",")))
                    valor = decimal.Parse(meta1.Valor1.Replace(".", ","));
            }

            if (!string.IsNullOrEmpty(meta1.Valor2) && !string.IsNullOrEmpty(meta2.Valor1))
            {
                if (decimal.Parse(meta1.Valor2.Replace(".", ",")) == decimal.Parse(meta2.Valor1.Replace(".", ",")))
                    valor = decimal.Parse(meta1.Valor2.Replace(".", ","));
            }

            return valor;
        }

        private string ObtenerColorCeldaHeatMap(MedicionViewModel medicion)
        {
            EscalaGraficosViewModel escalas = ObtenerEscalasGrafico(medicion);

            decimal valor = 0;
            int i = 0;

            decimal valorMedicion = decimal.Parse(medicion.Valor.Replace(".", ","));

            while(valorMedicion >= valor)
            {
                i++;
                valor = escalas.EscalaValores[i];                
            }

            return escalas.EscalaColores[i-1];
        }

        public HeatMapViewModel ObtenerHeatMapViewModel()
        {
            IList<FilaHeatMapViewModel> filasHeatMapViewModel = AutoMapper.Mapper.Map<IList<FilaHeatMapViewModel>>(IndicadorRepository.Todas().ToList());
                       
            IList<MedicionViewModel> mediciones = Todas();

            IList<CeldaHeatMapViewModel> celdasHeatMapViewModel = new List<CeldaHeatMapViewModel>();

            HeatMapViewModel heatMapViewModel = new HeatMapViewModel();
            heatMapViewModel.Meses = Enum.GetValues(typeof(Enums.Enum.Mes)).Cast<Enums.Enum.Mes>().Select(v => v.ToString()).ToList();
            heatMapViewModel.FilasHeatMapViewModel = filasHeatMapViewModel;

            int mesActual = DateTimeHelper.OntenerFechaActual().Month;

            foreach (Enums.Enum.Mes mes in Enum.GetValues(typeof(Enums.Enum.Mes)).Cast<Enums.Enum.Mes>())
            {
                if ((int)mes <= mesActual)
                {
                    IList<MedicionViewModel> medicionesPorMes = mediciones.Where(m => m.Mes == mes).OrderBy(m => m.IndicadorViewModel.Id).ToList();

                    int i = 0;

                    while (i < filasHeatMapViewModel.Count)
                    {
                        CeldaHeatMapViewModel celdaHeatMapViewModel = new CeldaHeatMapViewModel();
                        celdaHeatMapViewModel.IndiceIndicador = i + 1;
                        celdaHeatMapViewModel.Mes = (int)mes;

                        if (medicionesPorMes.Any(m => m.IndicadorID == filasHeatMapViewModel[i].IdIndicador && m.Mes == mes))
                        {
                            MedicionViewModel medicionPorMes = medicionesPorMes.First(m => m.IndicadorID == filasHeatMapViewModel[i].IdIndicador && m.Mes == mes);

                            celdaHeatMapViewModel.IdIndicador = medicionPorMes.IndicadorID;
                            celdaHeatMapViewModel.Medicion = medicionPorMes.Valor;
                            celdaHeatMapViewModel.ColorMeta = "black";//ObtenerColorCeldaHeatMap(medicionPorMes);
                            celdaHeatMapViewModel.MedicionCargada = true;
                        }

                        celdasHeatMapViewModel.Add(celdaHeatMapViewModel);
                        i++;
                    }
                }
            }                       
            heatMapViewModel.Celdas = celdasHeatMapViewModel;
            return heatMapViewModel;
        }       
    }
}