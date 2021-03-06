﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
        public static string Inaceptable { get { return "#DF0101"; } }
        public static string AMejorar { get { return "#F79F81"; } }
        public static string Aceptable { get { return "#ffff66"; } }
        public static string Satisfactoria { get { return "#81F781"; } }
        public static string Excelente { get { return "#009900"; } }

        public static readonly string[] ColorMetaInaceptableExcelente = { Inaceptable, AMejorar, Aceptable, Satisfactoria, Excelente };
        public static readonly string[] ColorMetaExcelenteInaceptable = { Excelente, Satisfactoria, Aceptable, AMejorar, Inaceptable };

        private IMedicionRepository MedicionRepository { get; set; }
        private IIndicadorRepository IndicadorRepository { get; set; }
        private IIndicadorService IndicadorService { get; set; }
        private IIndicadorAutomaticoRepository IndicadorAutomaticoRepository { get; set; }
        private IPersonaRepository PersonaRepository { get; set; }

        public MedicionService(IMedicionRepository medicionRepository,
                               IIndicadorRepository indicadorRepository,
                               IIndicadorService indicadorService,
                               IIndicadorAutomaticoRepository indicadorAutomaticoRepository,
                               IPersonaRepository personaRepository)
        {
            this.MedicionRepository = medicionRepository;
            this.IndicadorRepository = indicadorRepository;
            this.IndicadorService = indicadorService;
            this.IndicadorAutomaticoRepository = indicadorAutomaticoRepository;
            this.PersonaRepository = personaRepository;
        }

        public MedicionViewModel GetByIdNoTask(int id)
        {
            return AutoMapper.Mapper.Map<MedicionViewModel>(MedicionRepository.GetById(id).First());
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

        public IList<MedicionViewModel> BuscarNoTask(MedicionViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<MedicionViewModel>>(MedicionRepository.Buscar(filtro).ToList());
        }

        public async Task<IList<LineViewModel>> ObtenerLineViewModel(long grupo, int anio, PersonaViewModel personaViewModel)
        {
            MedicionViewModel filtro = new MedicionViewModel();
            filtro.Grupo = grupo;
            filtro.Anio = anio;
            filtro.BuscarPorNoAplica = true;
            filtro.NoAplica = false;

            return AutoMapper.Mapper.Map<IList<LineViewModel>>((await MedicionRepository.Buscar(filtro).ToListAsync()).OrderBy(m => m.Mes));
        }

        public async Task<GaugeViewModel> ObtenerGaugeViewModel(long grupo, int anio, PersonaViewModel personaViewModel, bool todasLasAreas = false)
        {
            MedicionViewModel filtro = new MedicionViewModel();
            filtro.Grupo = grupo;
            filtro.Anio = anio;
            filtro.BuscarPorNoAplica = true;
            filtro.NoAplica = false;

            IList<MedicionViewModel> medicionesViewModel = await Buscar(filtro);

            GaugeViewModel gaugeViewModel = new GaugeViewModel();

            if (medicionesViewModel != null && medicionesViewModel.Count > 0)
            {
                MedicionViewModel ultimaMedicionCargada = medicionesViewModel.OrderBy(m => m.Mes).Reverse().First();

                // Obtener el último indicador
                Indicador ultimoIndicador = IndicadorRepository.Buscar(new BuscarIndicadorViewModel { Busqueda = new IndicadorViewModel { Grupo = grupo }, PersonaLogueadaViewModel = personaViewModel, TodasLasAreas = todasLasAreas }).First();

                gaugeViewModel.NombreMes = ultimaMedicionCargada.Mes.ToString();
                gaugeViewModel.NombreIndicador = ultimoIndicador.Nombre;
                gaugeViewModel.Valor = ultimaMedicionCargada.Valor;

                CompletarEscalasGauge(gaugeViewModel, ultimaMedicionCargada);
            }

            return gaugeViewModel;
        }

        public EscalaGraficosViewModel ObtenerEscalasGrafico(IndicadorViewModel indicador)
        {
            EscalaGraficosViewModel escalas = new EscalaGraficosViewModel();

            decimal valorExcelente =
                ObtenerValorEscala(indicador.MetaExcelenteViewModel, indicador.MetaSatisfactoriaViewModel);

            decimal valorSatisfactorio =
                ObtenerValorEscala(indicador.MetaSatisfactoriaViewModel, indicador.MetaAceptableViewModel);

            decimal valorAceptable =
                ObtenerValorEscala(indicador.MetaAceptableViewModel, indicador.MetaAMejorarViewModel);

            decimal valorAMejorar =
                ObtenerValorEscala(indicador.MetaAMejorarViewModel, indicador.MetaInaceptableViewModel);

            if (valorExcelente >= valorSatisfactorio)
            {
                decimal minimoEscala = 0;

                if (!string.IsNullOrEmpty(indicador.MetaInaceptableViewModel.Valor1) &&
                   !string.IsNullOrEmpty(indicador.MetaInaceptableViewModel.Valor2))
                {
                    minimoEscala = decimal.Parse(indicador.MetaInaceptableViewModel.Valor1.Replace(".", ",")) < decimal.Parse(indicador.MetaInaceptableViewModel.Valor2.Replace(".", ",")) ? decimal.Parse(indicador.MetaInaceptableViewModel.Valor1.Replace(".", ",")) : decimal.Parse(indicador.MetaInaceptableViewModel.Valor2.Replace(".", ","));
                }
                else
                {
                    minimoEscala = string.IsNullOrEmpty(indicador.MetaInaceptableViewModel.Valor1) ? decimal.Parse(indicador.MetaInaceptableViewModel.Valor2.Replace(".", ",")) : decimal.Parse(indicador.MetaInaceptableViewModel.Valor1.Replace(".", ","));
                }

                decimal maximoEscala = 0;

                if (!string.IsNullOrEmpty(indicador.MetaExcelenteViewModel.Valor1) &&
                   !string.IsNullOrEmpty(indicador.MetaExcelenteViewModel.Valor2))
                {
                    maximoEscala = decimal.Parse(indicador.MetaExcelenteViewModel.Valor1.Replace(".", ",")) > decimal.Parse(indicador.MetaExcelenteViewModel.Valor2.Replace(".", ",")) ? decimal.Parse(indicador.MetaExcelenteViewModel.Valor1.Replace(".", ",")) : decimal.Parse(indicador.MetaExcelenteViewModel.Valor2.Replace(".", ","));
                }
                else
                {
                    maximoEscala = string.IsNullOrEmpty(indicador.MetaExcelenteViewModel.Valor1) ? decimal.Parse(indicador.MetaExcelenteViewModel.Valor2.Replace(".", ",")) : decimal.Parse(indicador.MetaExcelenteViewModel.Valor1.Replace(".", ","));
                }

                escalas.EscalaValores = new decimal[6] { minimoEscala, valorAMejorar, valorAceptable, valorSatisfactorio, valorExcelente, maximoEscala };
                escalas.EscalaColores = ColorMetaInaceptableExcelente;
                escalas.EscalaDeInaceptableAExcelente = true;
            }
            else
            {
                decimal maximoEscala = 0;

                if (!string.IsNullOrEmpty(indicador.MetaInaceptableViewModel.Valor1) &&
                   !string.IsNullOrEmpty(indicador.MetaInaceptableViewModel.Valor2))
                {
                    maximoEscala = decimal.Parse(indicador.MetaInaceptableViewModel.Valor1.Replace(".", ",")) > decimal.Parse(indicador.MetaInaceptableViewModel.Valor2.Replace(".", ",")) ? decimal.Parse(indicador.MetaInaceptableViewModel.Valor1.Replace(".", ",")) : decimal.Parse(indicador.MetaInaceptableViewModel.Valor2.Replace(".", ","));
                }
                else
                {
                    maximoEscala = string.IsNullOrEmpty(indicador.MetaInaceptableViewModel.Valor1) ? decimal.Parse(indicador.MetaInaceptableViewModel.Valor2.Replace(".", ",")) : decimal.Parse(indicador.MetaInaceptableViewModel.Valor1.Replace(".", ","));
                }

                decimal minimoEscala = 0;

                if (!string.IsNullOrEmpty(indicador.MetaExcelenteViewModel.Valor1) &&
                   !string.IsNullOrEmpty(indicador.MetaExcelenteViewModel.Valor2))
                {
                    minimoEscala = decimal.Parse(indicador.MetaExcelenteViewModel.Valor1.Replace(".", ",")) < decimal.Parse(indicador.MetaExcelenteViewModel.Valor2.Replace(".", ",")) ? decimal.Parse(indicador.MetaExcelenteViewModel.Valor1.Replace(".", ",")) : decimal.Parse(indicador.MetaExcelenteViewModel.Valor2.Replace(".", ","));
                }
                else
                {
                    minimoEscala = string.IsNullOrEmpty(indicador.MetaExcelenteViewModel.Valor1) ? decimal.Parse(indicador.MetaExcelenteViewModel.Valor2.Replace(".", ",")) : decimal.Parse(indicador.MetaExcelenteViewModel.Valor1.Replace(".", ","));
                }

                escalas.EscalaValores = new decimal[6] { minimoEscala, valorExcelente, valorSatisfactorio, valorAceptable, valorAMejorar, maximoEscala };
                escalas.EscalaColores = ColorMetaExcelenteInaceptable;
                escalas.EscalaDeInaceptableAExcelente = false;
            }

            return escalas;
        }

        private void CompletarEscalasGauge(GaugeViewModel gauge, MedicionViewModel medicion)
        {
            EscalaGraficosViewModel escalas = ObtenerEscalasGrafico(medicion.IndicadorViewModel);
            gauge.Escala = escalas.EscalaValores;
            gauge.Colores = escalas.EscalaColores;

            if (decimal.Parse(gauge.Valor.Replace(".", ",")) < gauge.Escala[0])
            {
                string valor = (gauge.Escala[0] != 0 ? gauge.Escala[0].ToString().Replace(",", ".") : "0");
                valor = (valor.Contains(".") ? valor.TrimEnd('0').TrimEnd('.') : valor);

                gauge.Valor = valor;

            }
            else if (decimal.Parse(gauge.Valor.Replace(".", ",")) > gauge.Escala[5])
            {
                string valor = (gauge.Escala[5] != 0 ? gauge.Escala[5].ToString().Replace(",", ".") : "0");
                valor = (valor.Contains(".") ? valor.TrimEnd('0').TrimEnd('.') : valor);

                gauge.Valor = valor;
                
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
            EscalaGraficosViewModel escalas = ObtenerEscalasGrafico(medicion.IndicadorViewModel);

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

            int j = DesempatarColor(medicion, escalas);

            if (j > 0)
                i = j;

            return escalas.EscalaColores[i - 1];
        }

        private int DesempatarColor(MedicionViewModel medicion, EscalaGraficosViewModel escalas)
        {
            decimal valorMedicion = decimal.Parse(medicion.Valor.Replace(".", ","));
            int i = -1;

            if (escalas.EscalaDeInaceptableAExcelente)
            {
                Meta meta = AutoMapper.Mapper.Map<Meta>(medicion.IndicadorViewModel.MetaInaceptableViewModel);
                bool estaEnLaMeta = ValorEnLaMeta(meta, valorMedicion);

                if (estaEnLaMeta)
                {
                    i = 1;
                }
                else
                {
                    meta = AutoMapper.Mapper.Map<Meta>(medicion.IndicadorViewModel.MetaAMejorarViewModel);
                    estaEnLaMeta = ValorEnLaMeta(meta, valorMedicion);

                    if (estaEnLaMeta)
                    {
                        i = 2;
                    }
                    else
                    {
                        meta = AutoMapper.Mapper.Map<Meta>(medicion.IndicadorViewModel.MetaAceptableViewModel);
                        estaEnLaMeta = ValorEnLaMeta(meta, valorMedicion);

                        if (estaEnLaMeta)
                        {
                            i = 3;
                        }
                        else
                        {
                            meta = AutoMapper.Mapper.Map<Meta>(medicion.IndicadorViewModel.MetaSatisfactoriaViewModel);
                            estaEnLaMeta = ValorEnLaMeta(meta, valorMedicion);

                            if (estaEnLaMeta)
                            {
                                i = 4;
                            }
                            else
                            {
                                meta = AutoMapper.Mapper.Map<Meta>(medicion.IndicadorViewModel.MetaExcelenteViewModel);
                                estaEnLaMeta = ValorEnLaMeta(meta, valorMedicion);

                                if (estaEnLaMeta)
                                {
                                    i = 5;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Meta meta = AutoMapper.Mapper.Map<Meta>(medicion.IndicadorViewModel.MetaExcelenteViewModel);
                bool estaEnLaMeta = ValorEnLaMeta(meta, valorMedicion);

                if (estaEnLaMeta)
                {
                    i = 1;
                }
                else
                {
                    meta = AutoMapper.Mapper.Map<Meta>(medicion.IndicadorViewModel.MetaSatisfactoriaViewModel);
                    estaEnLaMeta = ValorEnLaMeta(meta, valorMedicion);

                    if (estaEnLaMeta)
                    {
                        i = 2;
                    }
                    else
                    {
                        meta = AutoMapper.Mapper.Map<Meta>(medicion.IndicadorViewModel.MetaAceptableViewModel);
                        estaEnLaMeta = ValorEnLaMeta(meta, valorMedicion);

                        if (estaEnLaMeta)
                        {
                            i = 3;
                        }
                        else
                        {
                            meta = AutoMapper.Mapper.Map<Meta>(medicion.IndicadorViewModel.MetaAMejorarViewModel);
                            estaEnLaMeta = ValorEnLaMeta(meta, valorMedicion);

                            if (estaEnLaMeta)
                            {
                                i = 4;
                            }
                            else
                            {
                                meta = AutoMapper.Mapper.Map<Meta>(medicion.IndicadorViewModel.MetaInaceptableViewModel);
                                estaEnLaMeta = ValorEnLaMeta(meta, valorMedicion);

                                if (estaEnLaMeta)
                                {
                                    i = 5;
                                }
                            }
                        }
                    }
                }
            }

            return i;
        }

        private bool ValorEnLaMeta(Meta meta, decimal valor)
        {
            bool estaEnLaMeta = false;

            if (meta.Valor1 != null &&
                meta.Valor1 == valor &&
                (meta.Signo1 == Enums.Enum.Signo.Igual ||
                 meta.Signo1 == Enums.Enum.Signo.MayorOIgual ||
                 meta.Signo1 == Enums.Enum.Signo.MenorOIgual)
                )
            {
                estaEnLaMeta = true;
            }
            else if (meta.Valor2 != null &&
                meta.Valor2 == valor &&
                (meta.Signo2 == Enums.Enum.Signo.Igual ||
                 meta.Signo2 == Enums.Enum.Signo.MayorOIgual ||
                 meta.Signo2 == Enums.Enum.Signo.MenorOIgual)
                )
            {
                estaEnLaMeta = true;
            }

            return estaEnLaMeta;
        }

        public async Task<HeatMapViewModel> ObtenerHeatMapViewModel(BuscarIndicadorViewModel buscarIndicadorViewModel)
        {
            Persona persona = await PersonaRepository.GetByUserName(buscarIndicadorViewModel.PersonaLogueadaViewModel.NombreUsuario).FirstOrDefaultAsync();
            IList<IndicadorAutomaticoViewModel> todosIndicadoresAutomaticos = AutoMapper.Mapper.Map<IList<IndicadorAutomaticoViewModel>>(IndicadorAutomaticoRepository.Todos().ToList());

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

                        if (
                            (indicador.FechaInicioValidez == null ||
                            (indicador.FechaInicioValidez != null &&
                             (
                                (indicador.FechaInicioValidez.Value.Year < buscarIndicadorViewModel.AnioTablero) ||
                                    (
                                        indicador.FechaInicioValidez.Value.Year == buscarIndicadorViewModel.AnioTablero &&
                                        indicador.FechaInicioValidez.Value.Month <= (int)mes
                                    )
                                )
                             )
                            ) &&
                            (
                                indicador.FechaFinValidez == null ||
                                (indicador.FechaFinValidez != null &&
                                    (
                                    (indicador.FechaFinValidez.Value.Year > buscarIndicadorViewModel.AnioTablero) ||
                                        (
                                            indicador.FechaFinValidez.Value.Year == buscarIndicadorViewModel.AnioTablero &&
                                            indicador.FechaFinValidez.Value.Month >= (int)mes
                                        )
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
                            celdaHeatMapViewModel.NombreIndicador = indicador.NombreIndicador;
                            celdaHeatMapViewModel.TieneAccesoLecturaEscritura = indicador.TieneAccesoLecturaEscritura;
                            celdaHeatMapViewModel.EsAutomatico = todosIndicadoresAutomaticos.Any(ia => ia.IndicadorViewModel.Grupo == celdaHeatMapViewModel.GrupoIndicador);

                            if (medicionesPorMes.Any(m => m.IndicadorViewModel.Grupo == indicador.Grupo && m.Mes == mes))
                            {
                                MedicionViewModel medicionPorMes = medicionesPorMes.First(m => m.IndicadorViewModel.Grupo == indicador.Grupo && m.Mes == mes);
                                celdaHeatMapViewModel.IdMedicion = medicionPorMes.MedicionId;

                                if (!medicionPorMes.NoAplica)
                                {
                                    celdaHeatMapViewModel.Medicion = medicionPorMes.Valor;
                                    celdaHeatMapViewModel.ColorMeta = ObtenerColorCeldaHeatMap(medicionPorMes);
                                    celdaHeatMapViewModel.MedicionCargada = true;
                                }
                                else
                                {
                                    celdaHeatMapViewModel.NoAplica = true;
                                }
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

        public MedicionViewModel ObtenerMedicionViewModelNoTask(int idIndicador, int mes, int? idMedicion, long grupo, int anio, PersonaViewModel personaViewModel)
        {
            MedicionViewModel medicionViewModel = new MedicionViewModel();
            medicionViewModel.Mes = Helpers.EnumHelper<Enums.Enum.Mes>.Parse(mes.ToString());
            medicionViewModel.IndicadorID = idIndicador;

            // Obtener el nombre del último indicador del grupo.
            IndicadorViewModel indicadorViewModel = IndicadorService.GetUltimoByGrupoNoTask(grupo, personaViewModel);

            if (idMedicion != null)
            {
                medicionViewModel = this.GetByIdNoTask(idMedicion.Value);
            }
            else
            {
                medicionViewModel.IndicadorViewModel = indicadorViewModel;
            }

            medicionViewModel.IndicadorViewModel.Nombre = indicadorViewModel.Nombre;

            return medicionViewModel;
        }

        public async Task<MedicionViewModel> ObtenerMedicionViewModel(int idIndicador, int mes, int? idMedicion, long grupo, int anio, PersonaViewModel personaViewModel, bool buscarTodasLasAreas = false)
        {
            MedicionViewModel medicionViewModel = new MedicionViewModel();
            medicionViewModel.Mes = Helpers.EnumHelper<Enums.Enum.Mes>.Parse(mes.ToString());
            medicionViewModel.IndicadorID = idIndicador;

            // Obtener el nombre del último indicador del grupo.
            IndicadorViewModel indicadorViewModel = await IndicadorService.GetUltimoByGrupo(grupo, personaViewModel, buscarTodasLasAreas);

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

        public async Task<int> Guardar(MedicionViewModel medicionViewModel)
        {
            Medicion medicion = AutoMapper.Mapper.Map<Medicion>(medicionViewModel);
            medicion.Indicador = null;
            return await MedicionRepository.Guardar(medicion);
        }

        public async Task<int> GuardarMedicion(MedicionViewModel medicionViewModel)
        {
            if (!medicionViewModel.NoAplica)
            {
                Medicion medicionActual = await MedicionRepository.GetById(medicionViewModel.MedicionId).FirstOrDefaultAsync();

                string colorActual = null;

                if (medicionActual != null)
                {
                    MedicionViewModel medicionViewModelActual = AutoMapper.Mapper.Map<MedicionViewModel>(medicionActual);
                    colorActual = ObtenerColorCeldaHeatMap(medicionViewModelActual);
                }

                string colorNuevo = ObtenerColorCeldaHeatMap(medicionViewModel);

                if (colorNuevo.Equals(Inaceptable))
                {
                    if (colorActual == null || !colorActual.Equals(colorNuevo))
                    {
                        medicionViewModel.SeDebeNotificar = true;
                    }
                }
            }

            Medicion medicion = AutoMapper.Mapper.Map<Medicion>(medicionViewModel);
            medicion.Indicador = null;

            return await MedicionRepository.Guardar(medicion);
        }

        public int GuardarMedicionNoTask(MedicionViewModel medicionViewModel)
        {
            if (!medicionViewModel.NoAplica)
            {
                Medicion medicionActual = MedicionRepository.GetById(medicionViewModel.MedicionId).FirstOrDefault();

                string colorActual = null;

                if (medicionActual != null)
                {
                    MedicionViewModel medicionViewModelActual = AutoMapper.Mapper.Map<MedicionViewModel>(medicionActual);
                    colorActual = ObtenerColorCeldaHeatMap(medicionViewModelActual);
                }

                string colorNuevo = ObtenerColorCeldaHeatMap(medicionViewModel);

                if (colorNuevo.Equals(Inaceptable))
                {
                    if (colorActual == null || !colorActual.Equals(colorNuevo))
                    {
                        medicionViewModel.SeDebeNotificar = true;
                    }
                }
            }

            Medicion medicion = AutoMapper.Mapper.Map<Medicion>(medicionViewModel);
            medicion.Indicador = null;

            return MedicionRepository.GuardarNoTask(medicion);
        }

        public bool ValidaMedicion(MedicionViewModel medicionViewModel)
        {
            if (medicionViewModel.NoAplica)
            {
                return true;
            }

            EscalaGraficosViewModel escalas = ObtenerEscalasGrafico(medicionViewModel.IndicadorViewModel);

            decimal valor = escalas.EscalaValores[0];
            int i = 0;

            decimal valorMedicion = decimal.Parse(medicionViewModel.Valor.Replace(".", ","));

            while (valorMedicion >= valor && i < 5)
            {
                i++;
                valor = escalas.EscalaValores[i];
            }

            if (i == 0)
                i++;

            int j = DesempatarColor(medicionViewModel, escalas);

            if (j > 0)
                i = j;

            if (i == 1 || i == 5)
            {
                if (escalas.EscalaDeInaceptableAExcelente)
                {
                    if (i == 1)
                    {
                        Meta meta = AutoMapper.Mapper.Map<Meta>(medicionViewModel.IndicadorViewModel.MetaInaceptableViewModel);
                        return ValidaMedicionBorde(meta, valorMedicion);
                    }
                    else
                    {
                        Meta meta = AutoMapper.Mapper.Map<Meta>(medicionViewModel.IndicadorViewModel.MetaExcelenteViewModel);
                        return ValidaMedicionBorde(meta, valorMedicion);
                    }
                }
                else
                {
                    if (i == 1)
                    {
                        Meta meta = AutoMapper.Mapper.Map<Meta>(medicionViewModel.IndicadorViewModel.MetaExcelenteViewModel);
                        return ValidaMedicionBorde(meta, valorMedicion);
                    }
                    else
                    {
                        Meta meta = AutoMapper.Mapper.Map<Meta>(medicionViewModel.IndicadorViewModel.MetaInaceptableViewModel);
                        return ValidaMedicionBorde(meta, valorMedicion);
                    }
                }
            }
            else
            {
                return true;
            }                    
        }

        private bool ValidaMedicionBorde(Meta meta, decimal valor)
        {
            if(meta.Valor1 != null && meta.Valor2 != null)
            {
                if((valor < meta.Valor1 && valor < meta.Valor2) ||
                   (valor > meta.Valor1 && valor > meta.Valor2))
                {
                    return false;
                }
                else if(valor == meta.Valor1 && 
                        meta.Signo1 != Enums.Enum.Signo.Igual &&
                         meta.Signo1 != Enums.Enum.Signo.MayorOIgual && 
                         meta.Signo1 != Enums.Enum.Signo.MenorOIgual)
                {
                    return false;
                }
                else if (valor == meta.Valor2 &&
                        meta.Signo2 != Enums.Enum.Signo.Igual &&
                         meta.Signo2 != Enums.Enum.Signo.MayorOIgual &
                         meta.Signo2 != Enums.Enum.Signo.MenorOIgual)
                {
                    return false;
                }
            }
            else if(meta.Valor1 != null)
            {
                if (meta.Signo1 == Enums.Enum.Signo.Igual && meta.Valor1 != valor)
                    return false;
            }
            else
            {
                if (meta.Signo2 == Enums.Enum.Signo.Igual && meta.Valor2 != valor)
                    return false;
            }

            return true;
        }
    }
}