using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using YUTPLAT.Helpers;
using YUTPLAT.Helpers.Filters;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;
using System.Linq;

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
        [Authorize(Roles = "admin, usuario")]
        public ActionResult Buscar()
        {
            BuscarUsuarioViewModel model = new BuscarUsuarioViewModel();
            model.Busqueda.Titulo = "Usuarios";
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            ViewBag.Titulo = model.Busqueda.Titulo;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, usuario")]
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
        [Authorize(Roles = "admin, usuario")]
        public ActionResult Crear()
        {
            PersonaViewModel model = new PersonaViewModel();

            PersonaViewModel personaLogueadaViewModel = (PersonaViewModel)Session["Persona"];
            model.EsAdmin = personaLogueadaViewModel.EsAdmin;

            if (personaLogueadaViewModel.AreaViewModel != null)
            {
                model.AreaViewModel = personaLogueadaViewModel.AreaViewModel;
                model.IdArea = model.AreaViewModel.Id.ToString();

                model.NombreRol = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Operador);
            }

            model.Titulo = "Usuarios";
            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, usuario")]
        public async Task<ActionResult> Crear(PersonaViewModel model)
        {
            PersonaViewModel personaLogueadaViewModel = (PersonaViewModel)Session["Persona"];
            model.EsAdmin = personaLogueadaViewModel.EsAdmin;

            if (personaLogueadaViewModel.AreaViewModel != null)
            {
                model.AreaViewModel = personaLogueadaViewModel.AreaViewModel;
                model.IdArea = model.AreaViewModel.Id.ToString();

                model.NombreRol = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Operador);
            }

            if (!String.IsNullOrEmpty(model.IdArea) && !model.IdArea.Equals("0"))
                model.AreaViewModel = await AreaService.GetById(Int32.Parse(model.IdArea));

            if (EnumHelper<Enums.Enum.Rol>.Parse(model.NombreRol.ToString()) == Enums.Enum.Rol.Admin)
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

        [HttpGet]
        [EncryptedActionParameter]
        [Authorize(Roles = "admin, usuario")]
        public async Task<ActionResult> Editar(string id, string msgExito)
        {
            PersonaViewModel model = await PersonaService.GetById(id);

            PersonaViewModel personaLogueadaViewModel = (PersonaViewModel)Session["Persona"];
            model.EsAdmin = personaLogueadaViewModel.EsAdmin;
            
            if (personaLogueadaViewModel.AreaViewModel != null)
            {
                model.AreaViewModel = personaLogueadaViewModel.AreaViewModel;
                model.IdArea = model.AreaViewModel.Id.ToString();

                if (personaLogueadaViewModel.Id.Equals(model.Id))
                {
                    model.NombreRol = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Usuario);
                }
                else
                {
                    model.NombreRol = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Operador);
                }
            }

            model.Titulo = "Usuarios";
            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, usuario")]
        public async Task<ActionResult> Editar(PersonaViewModel model)
        {
            PersonaViewModel personaLogueadaViewModel = (PersonaViewModel)Session["Persona"];
            model.EsAdmin = personaLogueadaViewModel.EsAdmin;
            
            if (personaLogueadaViewModel.AreaViewModel != null)
            {
                model.AreaViewModel = personaLogueadaViewModel.AreaViewModel;
                model.IdArea = model.AreaViewModel.Id.ToString();

                if (personaLogueadaViewModel.Id.Equals(model.Id))
                {
                    model.NombreRol = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Usuario);
                }
                else
                {
                    model.NombreRol = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Operador);
                }
            }

            if (!String.IsNullOrEmpty(model.IdArea) && !model.IdArea.Equals("0"))
                model.AreaViewModel = await AreaService.GetById(Int32.Parse(model.IdArea));

            if (EnumHelper<Enums.Enum.Rol>.Parse(model.NombreRol.ToString()) == Enums.Enum.Rol.Admin)
            {
                ModelState.Remove("IdArea");
            }

            if (String.IsNullOrEmpty(model.Contrasenia) && String.IsNullOrEmpty(model.ConfirmarContrasenia))
            {
                ModelState.Remove("Contrasenia");
                ModelState.Remove("ConfirmarContrasenia");
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

        [HttpGet]
        [EncryptedActionParameter]
        [Authorize(Roles = "admin, usuario")]
        public async Task<ActionResult> Ver(string id)
        {
            PersonaViewModel model = await PersonaService.GetById(id);           
            model.Titulo = "Usuarios";
            ViewBag.Titulo = model.Titulo;
            return View(model);
        }

        public async Task<JsonResult> BuscarRoles(string nombreRol, bool considerarArea)
        {
            IList<RolViewModel> roles = await PersonaService.TodosRoles();

            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> BuscarPersonas(string nombreOApellidoONombreUsuario)
        {
            PersonaViewModel filtro = new PersonaViewModel();
            filtro.NombreOApellidoONombreUsuario = nombreOApellidoONombreUsuario;

            return Json(await PersonaService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> ValidarNombreUsuario(string NombreUsuario, string NombreUsuarioOriginal)
        {
            if ((String.IsNullOrEmpty(NombreUsuarioOriginal) || !NombreUsuario.Equals(NombreUsuarioOriginal)) &&
                (await PersonaService.ExisteUsuario(NombreUsuario)))
            {
                return Json("El Nombre de usuario ya existe.", JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}