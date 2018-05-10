using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using YUTPLAT.Helpers;
using YUTPLAT.Helpers.Filters;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class PersonaController : Controller
    {
        public IPersonaService PersonaService { get; set; }
        public IAreaService AreaService { get; set; }

        public PersonaController(IPersonaService personaService,
                                 IAreaService areaService)
        {
            this.PersonaService = personaService;
            this.AreaService = areaService;
        }

        [HttpGet]
        [EncryptedActionParameter]
        public ActionResult Buscar()
        {
            BuscarUsuarioViewModel model = new BuscarUsuarioViewModel();
            model.Busqueda.Titulo = "Usuarios";
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            ViewBag.Titulo = model.Busqueda.Titulo;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Buscar(BuscarUsuarioViewModel model)
        {
            ViewBag.SinResultados = null;

            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];
            model.Busqueda.AreaViewModel = model.PersonaLogueadaViewModel.AreaViewModel;

            IList<PersonaViewModel> personas = await PersonaService.Buscar(model.Busqueda);

            model.Resultados = personas;
            model.Busqueda.Titulo = "Usuarios";

            ViewBag.Titulo = model.Busqueda.Titulo;

            if (personas == null || personas.Count <= 0)
                ViewBag.SinResultados = "No se han encontrado usuarios para la búsqueda realizada.";

            return View(model);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            PersonaViewModel model = new PersonaViewModel();

            model.Titulo = "Usuarios";
            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(PersonaViewModel model)
        {
            if (!String.IsNullOrEmpty(model.IdArea) && !model.IdArea.Equals("0"))
                model.AreaViewModel = await AreaService.GetById(Int32.Parse(model.IdArea));

            if (model.Rol == Enums.Enum.Rol.Admin)
            {
                ModelState.Remove("IdArea");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Usuarios";

            ViewBag.Titulo = model.Titulo;

            string idPersona = await PersonaService.Guardar(model);

            return RedirectToAction("Editar", "Persona", new { q = MyExtensions.Encrypt(new { id = idPersona, msgExito = "El usuario se ha guardado exitosamente." }) });
        }

        public async Task<JsonResult> BuscarRoles(string nombreRol)
        {   /*
            BuscarAreaViewModel filtro = new BuscarAreaViewModel();
            filtro.Busqueda.Nombre = nombreArea;
            */
            return Json(await PersonaService.TodosRoles(), JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> BuscarPersonas(string nombreOApellidoONombreUsuario)
        {
            PersonaViewModel filtro = new PersonaViewModel();
            filtro.NombreOApellidoONombreUsuario = nombreOApellidoONombreUsuario;

            return Json(await PersonaService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> ValidarNombreUsuario(string NombreUsuario)
        {
            if (!(await PersonaService.ExisteUsuario(NombreUsuario)))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("El Nombre de usuario ya existe.", JsonRequestBehavior.AllowGet);
            }
        }
    }
}