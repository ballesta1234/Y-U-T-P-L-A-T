using System.Threading.Tasks;
using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class PersonaController : Controller
    {
        public IPersonaService PersonaService { get; set; }
        
        public PersonaController(IPersonaService personaService)
        {
            this.PersonaService = personaService;            
        }

        public async Task<JsonResult> BuscarPersonas(string nombreOApellidoONombreUsuario)
        {
            PersonaViewModel filtro = new PersonaViewModel();
            filtro.NombreOApellidoONombreUsuario = nombreOApellidoONombreUsuario;

            return Json(await PersonaService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }
    }
}