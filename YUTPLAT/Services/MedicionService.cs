using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Helpers;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public class MedicionService : IMedicionService
    {
        public static readonly string[] ColorMetaInaceptableExcelente = { "#DF0101", "#F79F81", "#F7FE2E", "#81F781", "#0B610B" };
        public static readonly string[] ColorMetaExcelenteInaceptable = { "#0B610B", "#81F781", "#F7FE2E", "#F79F81", "#DF0101" };

        private IMedicionRepository MedicionRepository { get; set; }
        private IIndicadorRepository IndicadorRepository { get; set; }
        private IIndicadorService IndicadorService { get; set; }
        private IIndicadorAutomaticoService IndicadorAutomaticoService { get; set; }
        private IPersonaRepository PersonaRepository { get; set; }

        public MedicionService(IMedicionRepository medicionRepository,
                               IIndicadorRepository indicadorRepository,
                               IIndicadorService indicadorService,
                               IIndicadorAutomaticoService indicadorAutomaticoService,
                               IPersonaRepository personaRepository)
        {
            this.MedicionRepository = medicionRepository;
            this.IndicadorRepository = indicadorRepository;
            this.IndicadorService = indicadorService;
            this.IndicadorAutomaticoService = indicadorAutomaticoService;
            this.PersonaRepository = personaRepository;
        }

        public async Task<MedicionViewModel> GetById(int id)
        {
            return AutoMapper.Mapper.Map<MedicionViewModel>(await MedicionRepository.GetById(id).FirstAsync());
        }

        public async Task<IList<MedicionViewModel>> Todas(int anio)
        {
            return AutoMapper.Mapper.Map<IList<MedicionViewModel>>(await MedicionRepository.Todas(anio).ToListAsync());
        }

        public async Task<IList<MedicionViewModel>> Buscar(MedicionViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<MedicionViewModel>>(await MedicionRepository.Buscar(filtro).ToListAsync());
        }

        public async Task<IList<LineViewModel>> ObtenerLineViewModel(long grupo, int anio, PersonaViewModel personaViewModel)
        {
            MedicionViewModel filtro = new MedicionViewModel();
            filtro.Grupo = grupo;
            filtro.Anio = anio;

            return AutoMapper.Mapper.Map<IList<LineViewModel>>((await MedicionRepository.Buscar(filtro).ToListAsync()).OrderBy(m => m.Mes));
        }

        public async Task<GaugeViewModel> ObtenerGaugeViewModel(long grupo, int anio, PersonaViewModel personaViewModel)
        {
            MedicionViewModel filtro = new MedicionViewModel();
            filtro.Grupo = grupo;
            filtro.Anio = anio;

            IList<MedicionViewModel> medicionesViewModel = await Buscar(filtro);

            GaugeViewModel gaugeViewModel = new GaugeViewModel();

            if (medicionesViewModel != null && medicionesViewModel.Count > 0)
            {
                MedicionViewModel ultimaMedicionCargada = medicionesViewModel.OrderBy(m => m.Mes).Reverse().First();

                // Obtener el último indicador
                Indicador ultimoIndicador = IndicadorRepository.Buscar(new BuscarIndicadorViewModel { Busqueda = new IndicadorViewModel { Grupo = grupo }, PersonaLogueadaViewModel = personaViewModel }).First();

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

                if (!string.IsNullOrEmpty(medicion.IndicadorViewModel.MetaInaceptableViewModel.Valor1) &&
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

            if (decimal.Parse(gauge.Valor.Replace(".", ",")) < gauge.Escala[0])
            {
                gauge.Valor = (gauge.Escala[0] != 0 ? gauge.Escala[0].ToString().Replace(",", ".").TrimEnd('0').TrimEnd('.') : "0");
            }
            else if (decimal.Parse(gauge.Valor.Replace(".", ",")) > gauge.Escala[5])
            {
                gauge.Valor = (gauge.Escala[5] != 0 ? gauge.Escala[5].ToString().Replace(",", ".").TrimEnd('0').TrimEnd('.') : "0");
            }
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

            while (valorMedicion >= valor && i < 5)
            {
                i++;
                valor = escalas.EscalaValores[i];
            }

            if (i == 0)
                i++;

            return escalas.EscalaColores[i - 1];
        }

        public async Task<HeatMapViewModel> ObtenerHeatMapViewModel(BuscarIndicadorViewModel buscarIndicadorViewModel)
        {
            Persona persona = await PersonaRepository.GetByUserName(buscarIndicadorViewModel.PersonaLogueadaViewModel.NombreUsuario).FirstOrDefaultAsync();
            IList<IndicadorAutomaticoViewModel> todosIndicadoresAutomaticos = this.IndicadorAutomaticoService.Todos();

            IList<FilaHeatMapViewModel> filasHeatMapViewModel = AutoMapper.Mapper.Map<IList<FilaHeatMapViewModel>>(IndicadorRepository.Buscar(buscarIndicadorViewModel).ToList());

            CargarPermisosAIndicadores(filasHeatMapViewModel, persona);

            IList<MedicionViewModel> mediciones = await Todas(buscarIndicadorViewModel.AnioTablero);

            IList<CeldaHeatMapViewModel> celdasHeatMapViewModel = new List<CeldaHeatMapViewModel>();

            HeatMapViewModel heatMapViewModel = new HeatMapViewModel();
            heatMapViewModel.Meses = Enum.GetValues(typeof(Enums.Enum.Mes)).Cast<Enums.Enum.Mes>().Select(v => v.ToString()).ToList();
            heatMapViewModel.FilasHeatMapViewModel = filasHeatMapViewModel;

            DateTime fechaActual = DateTimeHelper.OntenerFechaActual();

            foreach (Enums.Enum.Mes mes in Enum.GetValues(typeof(Enums.Enum.Mes)).Cast<Enums.Enum.Mes>())
            {
                if ((int)mes <= fechaActual.Month || buscarIndicadorViewModel.AnioTablero < fechaActual.Year)
                {
                    IList<MedicionViewModel> medicionesPorMes = mediciones.Where(m => m.Mes == mes).OrderBy(m => m.IndicadorViewModel.Id).ToList();

                    int i = 0;

                    while (i < filasHeatMapViewModel.Count)
                    {
                        FilaHeatMapViewModel indicador = filasHeatMapViewModel[i];

                        if (indicador.FechaValidez == null ||
                            (indicador.FechaValidez != null &&
                             (
                                (indicador.FechaValidez.Value.Year > buscarIndicadorViewModel.AnioTablero) ||
                                    (
                                        indicador.FechaValidez.Value.Year == buscarIndicadorViewModel.AnioTablero &&
                                        indicador.FechaValidez.Value.Month >= (int)mes
                                    )
                                )
                             )
                           )
                        {
                            CeldaHeatMapViewModel celdaHeatMapViewModel = new CeldaHeatMapViewModel();
                            celdaHeatMapViewModel.IndiceIndicador = i + 1;
                            celdaHeatMapViewModel.Mes = (int)mes;
                            celdaHeatMapViewModel.IdIndicador = indicador.IdIndicador;
                            celdaHeatMapViewModel.GrupoIndicador = indicador.Grupo;
                            celdaHeatMapViewModel.NombreMes = mes.ToString();
                            celdaHeatMapViewModel.TieneAccesoLecturaEscritura = indicador.TieneAccesoLecturaEscritura;
                            celdaHeatMapViewModel.EsAutomatico = todosIndicadoresAutomaticos.Any(ia => ia.IndicadorViewModel.Grupo == celdaHeatMapViewModel.GrupoIndicador);

                            if (medicionesPorMes.Any(m => m.IndicadorViewModel.Grupo == indicador.Grupo && m.Mes == mes))
                            {
                                MedicionViewModel medicionPorMes = medicionesPorMes.First(m => m.IndicadorViewModel.Grupo == indicador.Grupo && m.Mes == mes);

                                celdaHeatMapViewModel.Medicion = medicionPorMes.Valor;
                                celdaHeatMapViewModel.IdMedicion = medicionPorMes.MedicionId;
                                celdaHeatMapViewModel.ColorMeta = ObtenerColorCeldaHeatMap(medicionPorMes);
                                celdaHeatMapViewModel.MedicionCargada = true;
                            }

                            celdasHeatMapViewModel.Add(celdaHeatMapViewModel);
                        }
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

        public async Task<MedicionViewModel> ObtenerMedicionViewModel(int idIndicador, int mes, int? idMedicion, long grupo, int anio, PersonaViewModel personaViewModel)
        {
            MedicionViewModel medicionViewModel = new MedicionViewModel();
            medicionViewModel.Mes = Helpers.EnumHelper<Enums.Enum.Mes>.Parse(mes.ToString());
            medicionViewModel.IndicadorID = idIndicador;

            // Obtener el nombre del último indicador del grupo.
            IndicadorViewModel indicadorViewModel = await IndicadorService.GetUltimoByGrupo(grupo, personaViewModel);

            if (idMedicion != null)
            {
                medicionViewModel = await this.GetById(idMedicion.Value);
            }
            else
            {
                medicionViewModel.IndicadorViewModel = indicadorViewModel;
            }

            medicionViewModel.IndicadorViewModel.Nombre = indicadorViewModel.Nombre;

            return medicionViewModel;
        }

        public async Task<int> GuardarMedicion(MedicionViewModel medicionViewModel)
        {
            Medicion medicion = AutoMapper.Mapper.Map<Medicion>(medicionViewModel);
            medicion.Indicador = null;
           
            return await MedicionRepository.Guardar(medicion);
        }

        public bool ValidaMedicion(MedicionViewModel medicionViewModel)
        {
            return true;
        }
    }
}