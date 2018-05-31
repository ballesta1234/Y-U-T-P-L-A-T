using YUTPLAT.ViewModel;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Helpers;

namespace YUTPLAT.Services.Interface
{
    public class TableroService : ITableroService
    {
        public IAuditoriaService AuditoriaService { get; set; }

        public TableroService(IAuditoriaService auditoriaService)
        {
            this.AuditoriaService = auditoriaService;
        }

        public async Task<bool> ActualizarTablero(PersonaViewModel personaViewModel)
        {
            bool actualizar = false;

            BuscarAuditoriaViewModel busqueda = new BuscarAuditoriaViewModel();            
            busqueda.Busqueda.TipoAuditoria = Enums.Enum.TipoAuditoria.ModificacionIndicador;

            AuditoriaViewModel auditoriaModificacionIndicador = (await this.AuditoriaService.Buscar(busqueda)).LastOrDefault();

            if(auditoriaModificacionIndicador != null)
            {
                busqueda = new BuscarAuditoriaViewModel();
                busqueda.Busqueda.UsuarioViewModel = personaViewModel;
                busqueda.Busqueda.TipoAuditoria = Enums.Enum.TipoAuditoria.UltimaActualizacionVistaTablero;

                AuditoriaViewModel auditoriaVistaTablero = (await this.AuditoriaService.Buscar(busqueda)).FirstOrDefault();

                if(auditoriaVistaTablero != null)
                {
                    actualizar = auditoriaVistaTablero.FechaCreacion.Value < auditoriaModificacionIndicador.FechaCreacion.Value;
                }
            }

            return actualizar;
        }

        public async Task AuditarVisualizacionTablero(PersonaViewModel personaViewModel)
        {
            BuscarAuditoriaViewModel busqueda = new BuscarAuditoriaViewModel();
            busqueda.Busqueda.UsuarioViewModel = personaViewModel;
            busqueda.Busqueda.TipoAuditoria = Enums.Enum.TipoAuditoria.UltimaActualizacionVistaTablero;

            AuditoriaViewModel auditoria =  (await this.AuditoriaService.Buscar(busqueda)).FirstOrDefault();

            if (auditoria == null)
                auditoria = new AuditoriaViewModel();

            auditoria.Descripcion = "Acceso al tablero";
            auditoria.UsuarioViewModel = personaViewModel;
            auditoria.TipoAuditoria = Enums.Enum.TipoAuditoria.UltimaActualizacionVistaTablero;
            auditoria.FechaCreacion = DateTimeHelper.OntenerFechaActual();

            await this.AuditoriaService.Guardar(auditoria);
        }


    }
}