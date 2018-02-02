
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
        private IIndicadorService IndicadorService { get; set; }
        private IPersonaRepository PersonaRepository { get; set; }

        public MedicionService(IMedicionRepository medicionRepository, 
                               IIndicadorRepository indicadorRepository, 
                               IIndicadorService indicadorService,
                               IPersonaRepository personaRepository)
        {
            this.MedicionRepository = medicionRepository;
            this.IndicadorRepository = indicadorRepository;
            this.IndicadorService = indicadorService;
            this.PersonaRepository = personaRepository;
        }

        public MedicionViewModel GetById(int id)
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

        public IList<LineViewModel> ObtenerLineViewModel(long grupo)
        {
            MedicionViewModel filtro = new MedicionViewModel();
            filtro.Grupo = grupo;

            return AutoMapper.Mapper.Map<IList<LineViewModel>>(MedicionRepository.Buscar(filtro).ToList().OrderBy(m => m.Mes));
        }

        public GaugeViewModel ObtenerGaugeViewModel(long grupo)
        {
            MedicionViewModel filtro = new MedicionViewModel();
            filtro.Grupo = grupo;

            IList<MedicionViewModel> medicionesViewModel = Buscar(filtro);
            
            GaugeViewModel gaugeViewModel = new GaugeViewModel();
            
            if (medicionesViewModel != null && medicionesViewModel.Count > 0)
            {
                MedicionViewModel ultimaMedicionCargada = medicionesViewModel.OrderBy(m => m.Mes).Reverse().First();

                // Obtener el último indicador
                Indicador ultimoIndicador = IndicadorRepository.Buscar(new BuscarIndicadorViewModel { Busqueda = new IndicadorViewModel { Grupo = grupo } }).First();

                gaugeViewModel.NombreMes = ultimaMedicionCargada.Mes.ToString();
                gaugeViewModel.NombreIndicador = ultimoIndicador.Nombre;
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

            if (valorExcelente >= valorSatisfactorio)
            {
                decimal minimoEscala = 0;

                if(!string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1) && 
                   !string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor2))
                {
                    minimoEscala = decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1.Replace(".", ",")) < decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor2.Replace(".", ",")) ? decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor2.Replace(".", ","));
                }
                else
                {
                    minimoEscala = string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1) ? decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor2.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1.Replace(".", ","));
                }
                
                decimal maximoEscala = 0;

                if (!string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1) &&
                   !string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor2))
                {
                    maximoEscala = decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1.Replace(".", ",")) > decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor2.Replace(".", ",")) ? decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor2.Replace(".", ","));
                }
                else
                {
                    maximoEscala = string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1) ? decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor2.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1.Replace(".", ","));
                }

                escalas.EscalaValores = new decimal[6] { minimoEscala, valorAMejorar, valorAceptable, valorSatisfactorio, valorExcelente, maximoEscala };
                escalas.EscalaColores = ColorMetaInaceptableExcelente;
            }
            else
            {
                decimal maximoEscala = 0;

                if (!string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1) &&
                   !string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor2))
                {
                    maximoEscala = decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1.Replace(".", ",")) > decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor2.Replace(".", ",")) ? decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor2.Replace(".", ","));
                }
                else
                {
                    maximoEscala = string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1) ? decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor2.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1.Replace(".", ","));
                }

                decimal minimoEscala = 0;

                if (!string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1) &&
                   !string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor2))
                {
                    minimoEscala = decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1.Replace(".", ",")) < decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor2.Replace(".", ",")) ? decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor2.Replace(".", ","));
                }
                else
                {
                    minimoEscala = string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1) ? decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor2.Replace(".", ",")) : decimal.Parse(medicion.IndicadorViewModel.MetaExcelenteViewModel.Valor1.Replace(".", ","));
                }

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

            decimal valor = escalas.EscalaValores[0];
            int i = 0;

            decimal valorMedicion = decimal.Parse(medicion.Valor.Replace(".", ","));

            while(valorMedicion >= valor && i < 5)
            {
                i++;
                valor = escalas.EscalaValores[i];                
            }

            if (i == 0)
                i++;

            return escalas.EscalaColores[i-1];
        }

        public HeatMapViewModel ObtenerHeatMapViewModel(BuscarIndicadorViewModel buscarIndicadorViewModel)
        {
            Persona persona = PersonaRepository.GetByUserName(buscarIndicadorViewModel.NombreUsuario);
            
            IList<FilaHeatMapViewModel> filasHeatMapViewModel = AutoMapper.Mapper.Map<IList<FilaHeatMapViewModel>>(IndicadorRepository.Buscar(buscarIndicadorViewModel).ToList());

            CargarPermisosAIndicadores(filasHeatMapViewModel, persona);

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
                        celdaHeatMapViewModel.IdIndicador = filasHeatMapViewModel[i].IdIndicador;
                        celdaHeatMapViewModel.GrupoIndicador = filasHeatMapViewModel[i].Grupo;
                        celdaHeatMapViewModel.NombreMes = mes.ToString();
                        celdaHeatMapViewModel.TieneAccesoLecturaEscritura = filasHeatMapViewModel[i].TieneAccesoLecturaEscritura;
                        
                        if (medicionesPorMes.Any(m => m.IndicadorViewModel.Grupo == filasHeatMapViewModel[i].Grupo && m.Mes == mes))
                        {
                            MedicionViewModel medicionPorMes = medicionesPorMes.First(m => m.IndicadorViewModel.Grupo == filasHeatMapViewModel[i].Grupo && m.Mes == mes);
                            
                            celdaHeatMapViewModel.Medicion = medicionPorMes.Valor;
                            celdaHeatMapViewModel.IdMedicion = medicionPorMes.MedicionId;
                            celdaHeatMapViewModel.ColorMeta = ObtenerColorCeldaHeatMap(medicionPorMes);
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

        private void CargarPermisosAIndicadores(IList<FilaHeatMapViewModel> filas, Persona persona)
        {
            if (filas != null && filas.Count > 0)
            {
                foreach (FilaHeatMapViewModel fila in filas)
                {
                    fila.TieneAccesoLecturaEscritura = persona.TieneAccesoLecturaEscritura(fila.IdIndicador);
                }
            }
        }

        public MedicionViewModel ObtenerMedicionViewModel(int idIndicador, int mes, int? idMedicion, long grupo)
        {
            MedicionViewModel medicionViewModel = new MedicionViewModel();
            medicionViewModel.Mes = Helpers.EnumHelper<Enums.Enum.Mes>.Parse(mes.ToString());
            medicionViewModel.IndicadorID = idIndicador;

            // Obtener el nombre del último indicador del grupo.
            IndicadorViewModel indicadorViewModel = IndicadorService.GetUltimoByGrupo(grupo);
                        
            if (idMedicion != null)
            {
                medicionViewModel = this.GetById(idMedicion.Value);
            }
            else
            {
                medicionViewModel.IndicadorViewModel = indicadorViewModel;
            }

            medicionViewModel.IndicadorViewModel.Nombre = indicadorViewModel.Nombre;

            return medicionViewModel;
        }

        public void GuardarMedicion(MedicionViewModel medicionViewModel)
        {
            if (medicionViewModel.MedicionId == 0 || (int)medicionViewModel.Mes == DateTimeHelper.OntenerFechaActual().Month)
            {
                Medicion medicion = AutoMapper.Mapper.Map<Medicion>(medicionViewModel);
                medicion.Indicador = null;

                MedicionRepository.Guardar(medicion);
            }
        }
    }
}