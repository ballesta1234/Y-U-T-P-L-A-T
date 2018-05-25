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
    public class AreaController : Controller
    {
        public IAreaService AreaService { get; set; }

        public AreaController(IAreaService areaService)
        {
            this.AreaService = areaService;
        }

        [HttpGet]
        [EncryptedActionParameter]
        [Authorize(Roles = "admin")]
        public ActionResult Buscar()
        {
            BuscarAreaViewModel model = new BuscarAreaViewModel();
            model.Busqueda.Titulo = "Áreas";
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];
            
            ViewBag.Titulo = model.Busqueda.Titulo;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Buscar(BuscarAreaViewModel model)
        {
            ViewBag.SinResultados = null;

            IList <AreaViewModel> areas = await AreaService.Buscar(model);

            model.Resultados = areas;
            model.Busqueda.Titulo = "Áreas";
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            ViewBag.Titulo = model.Busqueda.Titulo;

            if(areas == null || areas.Count <=0)
                ViewBag.SinResultados = "No se han encontrado áreas para la búsqueda realizada.";

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Crear()
        {
            AreaViewModel model = new AreaViewModel();
            model.Titulo = "Áreas";
            model.FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Crear(AreaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Áreas";

            ViewBag.Titulo = model.Titulo;

            int idArea = await AreaService.Guardar(model);

            return RedirectToAction("Editar", "Area", new { q = MyExtensions.Encrypt(new { id = idArea, msgExito = "El área se ha guardado exitosamente." })});
        }

        [HttpGet]
        [EncryptedActionParameter]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Editar(string id, string msgExito)
        {
            AreaViewModel model = await AreaService.GetById(Int32.Parse(id));

            model.Titulo = "Áreas";            

            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Editar(AreaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Áreas";
            ViewBag.Titulo = model.Titulo;

            model.FechaUltimaModificacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
            model.UltimoUsuarioModifico = User.Identity.Name;

            int idArea = await AreaService.Guardar(model);

            return RedirectToAction("Editar", "Area", new { q = MyExtensions.Encrypt(new { id = idArea, msgExito = "El área se ha guardado exitosamente." }) });
        }

        [HttpGet]
        [EncryptedActionParameter]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Ver(string id)
        {
            AreaViewModel model = await AreaService.GetById(Int32.Parse(id));
            model.Titulo = "Áreas";
            ViewBag.Titulo = model.Titulo;
            
            return View(model);
        }

        [Authorize(Roles = "admin, usuario, operador")]
        public async Task<JsonResult> BuscarAreas(string nombreArea)
        {
            BuscarAreaViewModel filtro = new BuscarAreaViewModel();
            filtro.Busqueda.Nombre = nombreArea;

            return Json(await AreaService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }
    }
}