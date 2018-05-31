
using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;
using YUTPLAT.Helpers;
using System.Threading.Tasks;
using System.Data.Entity;

namespace YUTPLAT.Services.Interface
{
    public class IndicadorService : IIndicadorService
    {
        private IIndicadorRepository IndicadorRepository { get; set; }
        private IIndicadorAutomaticoRepository IndicadorAutomaticoRepository { get; set; }     
        private IResponsableIndicadorRepository ResponsableIndicadorRepository { get; set; }
        private IInteresadoIndicadorRepository InteresadoIndicadorRepository { get; set; }
        private IMetaRepository MetaRepository { get; set; }
        private IMedicionRepository MedicionRepository { get; set; }
        private IPersonaRepository PersonaRepository { get; set; }
        private IAuditoriaService AuditoriaService { get; set; }
        private IAccesoIndicadorRepository AccesoIndicadorRepository { get; set; }

        public IndicadorService(IIndicadorRepository indicadorRepository,
                                IIndicadorAutomaticoRepository indicadorAutomaticoRepository,                              
                                IResponsableIndicadorRepository responsableIndicadorRepository,
                                IInteresadoIndicadorRepository interesadoIndicadorRepository,
                                IMetaRepository metaRepository,
                                IAuditoriaService auditoriaService,
                                IMedicionRepository medicionRepository,
                                IPersonaRepository personaRepository,
                                IAccesoIndicadorRepository accesoIndicadorRepository)
        {
            this.IndicadorRepository = indicadorRepository;
            this.IndicadorAutomaticoRepository = indicadorAutomaticoRepository;       
            this.ResponsableIndicadorRepository = responsableIndicadorRepository;
            this.InteresadoIndicadorRepository = interesadoIndicadorRepository;
            this.MetaRepository = metaRepository;
            this.AuditoriaService = auditoriaService;
            this.MedicionRepository = medicionRepository;
            this.PersonaRepository = personaRepository;
            this.AccesoIndicadorRepository = accesoIndicadorRepository;
        }

        public IndicadorViewModel GetUltimoByGrupoNoTask(long grupo, PersonaViewModel personaViewModel)
        {
            // Obtener el nombre del último indicador del grupo.
            Indicador indicador = IndicadorRepository.Buscar(new BuscarIndicadorViewModel { Busqueda = new IndicadorViewModel { Grupo = grupo }, PersonaLogueadaViewModel = personaViewModel }).First();

            IndicadorViewModel indicadorViewModel = AutoMapper.Mapper.Map<IndicadorViewModel>(indicador);
            indicadorViewModel.ObjetivoViewModel = AutoMapper.Mapper.Map<ObjetivoViewModel>(indicador.Objetivo);
            indicadorViewModel.ObjetivoViewModel.AreaViewModel = AutoMapper.Mapper.Map<AreaViewModel>(indicador.Objetivo.Area);
            indicadorViewModel.FrecuenciaMedicionIndicadorViewModel = AutoMapper.Mapper.Map<FrecuenciaMedicionIndicadorViewModel>(indicador.FrecuenciaMedicion);
            indicadorViewModel.Interesados = AutoMapper.Mapper.Map<IList<PersonaViewModel>>(indicador.Interesados.Select(i => i.Persona));
            indicadorViewModel.Responsables = AutoMapper.Mapper.Map<IList<PersonaViewModel>>(indicador.Responsables.Select(i => i.Persona));

            return indicadorViewModel;
        }

        public async Task<IndicadorViewModel> GetUltimoByGrupo(long grupo, PersonaViewModel personaViewModel, bool buscarTodasLasAreas = false)
        {
            // Obtener el nombre del último indicador del grupo.
            Indicador indicador = await IndicadorRepository.Buscar(new BuscarIndicadorViewModel { Busqueda = new IndicadorViewModel { Grupo = grupo }, PersonaLogueadaViewModel = personaViewModel, TodasLasAreas = buscarTodasLasAreas }).FirstAsync();

            IndicadorViewModel indicadorViewModel = AutoMapper.Mapper.Map<IndicadorViewModel>(indicador);
            indicadorViewModel.ObjetivoViewModel = AutoMapper.Mapper.Map<ObjetivoViewModel>(indicador.Objetivo);
            indicadorViewModel.ObjetivoViewModel.AreaViewModel = AutoMapper.Mapper.Map<AreaViewModel>(indicador.Objetivo.Area);
            indicadorViewModel.FrecuenciaMedicionIndicadorViewModel = AutoMapper.Mapper.Map<FrecuenciaMedicionIndicadorViewModel>(indicador.FrecuenciaMedicion);
            indicadorViewModel.Interesados = AutoMapper.Mapper.Map<IList<PersonaViewModel>>(indicador.Interesados.Select(i => i.Persona));
            indicadorViewModel.Responsables = AutoMapper.Mapper.Map<IList<PersonaViewModel>>(indicador.Responsables.Select(i => i.Persona));

            return indicadorViewModel;
        }

        public async Task<IndicadorViewModel> GetById(int id)
        {
            Indicador indicador = await IndicadorRepository.GetById(id).FirstAsync();

            IndicadorViewModel indicadorViewModel = AutoMapper.Mapper.Map<IndicadorViewModel>(indicador);
            indicadorViewModel.ObjetivoViewModel = AutoMapper.Mapper.Map<ObjetivoViewModel>(indicador.Objetivo);
            indicadorViewModel.ObjetivoViewModel.AreaViewModel = AutoMapper.Mapper.Map<AreaViewModel>(indicador.Objetivo.Area);
            indicadorViewModel.FrecuenciaMedicionIndicadorViewModel = AutoMapper.Mapper.Map<FrecuenciaMedicionIndicadorViewModel>(indicador.FrecuenciaMedicion);
            indicadorViewModel.Interesados = AutoMapper.Mapper.Map<IList<PersonaViewModel>>(indicador.Interesados.Select( i=> i.Persona ));
            indicadorViewModel.Responsables = AutoMapper.Mapper.Map<IList<PersonaViewModel>>(indicador.Responsables.Select(i => i.Persona));

            return indicadorViewModel;
        }      
        
        public async Task<IList<IndicadorViewModel>> Buscar(BuscarIndicadorViewModel filtro)
        {
            Persona persona = await PersonaRepository.GetByUserName(filtro.PersonaLogueadaViewModel.NombreUsuario).FirstOrDefaultAsync();
            IList<IndicadorViewModel> indicadores = AutoMapper.Mapper.Map<IList<IndicadorViewModel>>(IndicadorRepository.Buscar(filtro).ToList());

            CargarPermisosAIndicadores(indicadores, persona);

            return indicadores; 
        }

        private void CargarPermisosAIndicadores(IList<IndicadorViewModel> indicadores, Persona persona)
        {
            if(indicadores != null && indicadores.Count > 0)
            {
                foreach(IndicadorViewModel indicador in indicadores)
                {
                    indicador.TieneAccesoLectura = persona.TieneAccesoLectura(indicador.Id);
                    indicador.TieneAccesoLecturaEscritura = persona.TieneAccesoLecturaEscritura(indicador.Id);
                }
            }
        }

        public async Task<int> Guardar(IndicadorViewModel indicadorViewModel, PersonaViewModel personaGuarda)
        {
            bool modificado = false;

            int mesActual = DateTimeHelper.OntenerFechaActual().Month;

            int idIndicadorOriginal = 0;

            if (indicadorViewModel.Id > 0)
            {
                Indicador indicadorOriginal = IndicadorRepository.GetById(indicadorViewModel.Id).First();

                if (HayCambios(indicadorOriginal, indicadorViewModel) && await MedicionRepository.Buscar(new MedicionViewModel { IndicadorID = indicadorViewModel.Id }).AnyAsync( m => (int)m.Mes != mesActual))
                {
                    idIndicadorOriginal = indicadorViewModel.Id;
                    indicadorViewModel.Id = 0;
                    modificado = true;
                }
            }

            // Borrar los responsables previos
            await ResponsableIndicadorRepository.EliminarPorIndicador(indicadorViewModel.Id);

            // Borrar los interesados previos
            await InteresadoIndicadorRepository.EliminarPorIndicador(indicadorViewModel.Id);

            // Borrar los permisos previos
            await AccesoIndicadorRepository.EliminarPorIndicador(indicadorViewModel.Id);

            Indicador indicador = AutoMapper.Mapper.Map<Indicador>(indicadorViewModel);

            if(modificado)
            {
                indicador.FechaCreacion = indicador.FechaCreacion.Value.AddMinutes(1);
            }
                        
            indicador.MetaAceptableMetaID = await GuardarMeta(indicadorViewModel.MetaAceptableViewModel);
            indicador.MetaAMejorarMetaID = await GuardarMeta(indicadorViewModel.MetaAMejorarViewModel);
            indicador.MetaExcelenteMetaID = await GuardarMeta(indicadorViewModel.MetaExcelenteViewModel);
            indicador.MetaInaceptableMetaID = await GuardarMeta(indicadorViewModel.MetaInaceptableViewModel);
            indicador.MetaSatisfactoriaMetaID = await GuardarMeta(indicadorViewModel.MetaSatisfactoriaViewModel);

            // Guardar el indicador
            await IndicadorRepository.Guardar(indicador);

            if (indicador.Grupo == 0)
            {
                indicador.Grupo = indicador.IndicadorID;
                await IndicadorRepository.Guardar(indicador);
            }
            
            if (modificado)
            {
                IndicadorAutomatico indicadorAutomatico = await IndicadorAutomaticoRepository.GetByIdIndicador(idIndicadorOriginal).FirstOrDefaultAsync();

                if(indicadorAutomatico != null)
                {
                    indicadorAutomatico.Indicador = null;
                    indicadorAutomatico.IndicadorID = indicador.IndicadorID;
                    await IndicadorAutomaticoRepository.Guardar(indicadorAutomatico);

                    IndicadorAutomaticoViewModel indicadorAutomaticoViewModel = AutoMapper.Mapper.Map<IndicadorAutomaticoViewModel>(indicadorAutomatico);

                    IndicadorAutomaticoRepository.DetenerJob(indicadorAutomaticoViewModel);
                    IndicadorAutomaticoRepository.IniciarJob(indicadorAutomaticoViewModel);
                }
            }

            // Guardar los responsables
            await GuardarResponsables(indicadorViewModel.Responsables, indicador.IndicadorID);
            
            // Guardar los interesados
            await GuardarInteresados(indicadorViewModel.Interesados, indicador.IndicadorID);
                        
            if (modificado)
            {
                // Si hay mediciones cargadas para el indicador que se esta modificando, actualizar la referencia al nuevo indicador
                IList<Medicion> mediciones = MedicionRepository.Buscar(new MedicionViewModel { IndicadorID = idIndicadorOriginal, Mes = (Enums.Enum.Mes)mesActual }).ToList();

                if (mediciones != null && mediciones.Count > 0)
                {
                    foreach (Medicion medicion in mediciones)
                    {
                        medicion.IndicadorID = indicador.IndicadorID;
                        await MedicionRepository.Guardar(medicion);
                    }
                }
            }

            await AuditarModificacionIndicador(personaGuarda);

            return indicador.IndicadorID;
        }

        private async Task AuditarModificacionIndicador(PersonaViewModel personaViewModel)
        {
            AuditoriaViewModel auditoria = new AuditoriaViewModel();
            auditoria.Descripcion = "Modificación del indicador";
            auditoria.UsuarioViewModel = personaViewModel;
            auditoria.TipoAuditoria = Enums.Enum.TipoAuditoria.ModificacionIndicador;
            auditoria.FechaCreacion = DateTimeHelper.OntenerFechaActual();

            await this.AuditoriaService.Guardar(auditoria);
        }

        private bool HayCambios(Indicador indicadorOriginal, IndicadorViewModel indicadorCargado)
        {
            if (!indicadorOriginal.Nombre.Trim().Equals(indicadorCargado.Nombre.Trim()) ||
                !indicadorOriginal.Descripcion.Trim().Equals(indicadorCargado.Descripcion.Trim()))
            {
                return true;
            }
            if( !indicadorOriginal.ObjetivoID.ToString().Trim().Equals(indicadorCargado.ObjetivoID.Trim()) || 
                !indicadorOriginal.FrecuenciaMedicionIndicadorID.ToString().Trim().Equals(indicadorCargado.FrecuenciaMedicionIndicadorID.Trim()))
            {
                return true;
            }
            if( MetasDiferentes(indicadorOriginal.MetaAceptable, indicadorCargado.MetaAceptableViewModel) ||
                MetasDiferentes(indicadorOriginal.MetaAMejorar, indicadorCargado.MetaAMejorarViewModel) ||
                MetasDiferentes(indicadorOriginal.MetaExcelente, indicadorCargado.MetaExcelenteViewModel) ||
                MetasDiferentes(indicadorOriginal.MetaInaceptable, indicadorCargado.MetaInaceptableViewModel) ||
                MetasDiferentes(indicadorOriginal.MetaSatisfactoria, indicadorCargado.MetaSatisfactoriaViewModel))
            {
                return true;
            }
            if(InteresadosDiferentes(indicadorOriginal.Interesados, indicadorCargado.Interesados))
            {
                return true;
            }
            if (ResponsablesDiferentes(indicadorOriginal.Responsables, indicadorCargado.Responsables))
            {
                return true;
            }
            return false;
        }

        private bool InteresadosDiferentes(ICollection<InteresadoIndicador> interesadosOriginales, IList<PersonaViewModel> interesadosCargados)
        {
            if (interesadosOriginales.Count != interesadosCargados.Count)
                return true;

            foreach(PersonaViewModel interesadoCargado in interesadosCargados)
            {
                if (!interesadosOriginales.Any( i => i.Persona.UserName.Trim().Equals(interesadoCargado.NombreUsuario)))
                    return true;
            }

            return false;
        }

        private bool ResponsablesDiferentes(ICollection<ResponsableIndicador> responsablesOriginales, IList<PersonaViewModel> responsablesCargados)
        {
            if (responsablesOriginales.Count != responsablesCargados.Count)
                return true;

            foreach (PersonaViewModel responsableCargado in responsablesCargados)
            {
                if (!responsablesOriginales.Any(i => i.Persona.UserName.Trim().Equals(responsableCargado.NombreUsuario)))
                    return true;
            }

            return false;
        }

        private bool MetasDiferentes(Meta metaOriginal, MetaViewModel metaCargada)
        {
            if( (metaOriginal.Valor1 == null && !string.IsNullOrEmpty(metaCargada.Valor1)) || 
                (metaOriginal.Valor1 != null && string.IsNullOrEmpty(metaCargada.Valor1)) || 
                (metaOriginal.Valor1 != null && !metaOriginal.Valor1.Value.ToString().Replace(",", ".").TrimEnd('0').TrimEnd('.').Equals(metaCargada.Valor1)))
            {
                return true;
            }
            if ( (metaOriginal.Valor2 == null && !string.IsNullOrEmpty(metaCargada.Valor2)) ||
                 (metaOriginal.Valor2 != null && string.IsNullOrEmpty(metaCargada.Valor2)) ||
                 (metaOriginal.Valor2 != null && !metaOriginal.Valor2.Value.ToString().Replace(",", ".").TrimEnd('0').TrimEnd('.').Equals(metaCargada.Valor2)))
            {
                return true;
            }
            if (!metaOriginal.Signo1.ToString().Trim().Equals(metaCargada.Signo1.ToString().Trim()))
            {
                return true;
            }
            if (!metaOriginal.Signo2.ToString().Trim().Equals(metaCargada.Signo2.ToString().Trim()))
            {
                return true;
            }

            return false;
        } 

        private async Task<int> GuardarMeta(MetaViewModel metaViewModel)
        {
            Meta meta = AutoMapper.Mapper.Map<Meta>(metaViewModel);
            return await MetaRepository.Guardar(meta);
        }

        private async Task GuardarResponsables(IList<PersonaViewModel> responsables, int indicadorID)
        {
            if (responsables != null)
            {                
                foreach (PersonaViewModel responsable in responsables)
                {
                    // Guardar a la persona
                    ResponsableIndicador responsableIndicador = new ResponsableIndicador();
                    responsableIndicador.IndicadorID = indicadorID;
                    responsableIndicador.PersonaID = responsable.Id;
                    await ResponsableIndicadorRepository.Guardar(responsableIndicador);

                    // Guardar los permisos
                    AccesoIndicador acceso = new AccesoIndicador();
                    acceso.IndicadorID = indicadorID;
                    acceso.PersonaID = responsable.Id;
                    acceso.PermisoIndicador = Enums.Enum.PermisoIndicador.LecturaEscritura;
                    await AccesoIndicadorRepository.Guardar(acceso);
                }
            }
        }

        private async Task GuardarInteresados(IList<PersonaViewModel> interesados, int indicadorID)
        {
            if (interesados != null)
            {
                foreach (PersonaViewModel interesado in interesados)
                {
                    // Guardar a la persona
                    InteresadoIndicador interesadoIndicador = new InteresadoIndicador();
                    interesadoIndicador.IndicadorID = indicadorID;
                    interesadoIndicador.PersonaID = interesado.Id;                    
                    await InteresadoIndicadorRepository.Guardar(interesadoIndicador);

                    // Guardar los permisos
                    AccesoIndicador acceso = new AccesoIndicador();
                    acceso.IndicadorID = indicadorID;
                    acceso.PersonaID = interesado.Id;
                    acceso.PermisoIndicador = Enums.Enum.PermisoIndicador.SoloLectura;
                    await AccesoIndicadorRepository.Guardar(acceso);
                }
            }
        }
    }
}