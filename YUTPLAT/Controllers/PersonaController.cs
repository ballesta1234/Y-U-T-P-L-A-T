using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class PersonaController : Controller
    {
        public IPersonaService PersonaService { get; set; }
        
        public PersonaController(IPersonaService areaService)
        {
            this.PersonaService = areaService;            
        }

        public JsonResult BuscarPersonas(string nombreOApellidoONombreUsuario)
        {
            PersonaViewModel filtro = new PersonaViewModel();
            filtro.NombreOApellidoONombreUsuario = nombreOApellidoONombreUsuario;

            return Json(PersonaService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }
    }
}