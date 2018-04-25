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
    public class ObjetivoController : Controller
    {
        public IObjetivoService ObjetivoService { get; set; }
        public IAreaService AreaService { get; set; }

        public ObjetivoController(IObjetivoService objetivoService, IAreaService areaService)
        {
            this.ObjetivoService = objetivoService;
            this.AreaService = areaService;
        }

        [HttpGet]
        public ActionResult Buscar()
        {
            BuscarObjetivoViewModel model = new BuscarObjetivoViewModel();
            model.Busqueda.Titulo = "Objetivos";
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            if (model.PersonaLogueadaViewModel.AreaViewModel != null)
            {
                model.Busqueda.AreaViewModel = model.PersonaLogueadaViewModel.AreaViewModel;
                model.Busqueda.IdArea = model.Busqueda.AreaViewModel.Id.ToString();
            }

            ViewBag.Titulo = model.Busqueda.Titulo;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Buscar(BuscarObjetivoViewModel model)
        {
            ViewBag.SinResultados = null;

            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            if (model.PersonaLogueadaViewModel.AreaViewModel != null)
            {
                model.Busqueda.AreaViewModel = model.PersonaLogueadaViewModel.AreaViewModel;
                model.Busqueda.IdArea = model.Busqueda.AreaViewModel.Id.ToString();
            }

            IList<ObjetivoViewModel> objetivos = await ObjetivoService.Buscar(model);

            model.Resultados = objetivos;
            model.Busqueda.Titulo = "Objetivos";
            
            ViewBag.Titulo = model.Busqueda.Titulo;

            if (objetivos == null || objetivos.Count <= 0)
                ViewBag.SinResultados = "No se han encontrado objetivos para la búsqueda realizada.";

            return View(model);
        }

        [HttpGet]
        [EncryptedActionParameter]
        public async Task<ActionResult> Crear(string idArea)
        {
            ObjetivoViewModel model = new ObjetivoViewModel();
            model.Titulo = "Objetivos";
            model.FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            if (model.PersonaLogueadaViewModel.AreaViewModel != null)
            {
                model.AreaViewModel = model.PersonaLogueadaViewModel.AreaViewModel;
                model.IdArea = model.AreaViewModel.Id.ToString();
            }

            if (idArea != null)
                model.AreaViewModel = await AreaService.GetById(Int32.Parse(idArea));

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(ObjetivoViewModel model)
        {
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            if (model.PersonaLogueadaViewModel.AreaViewModel != null)
            {
                model.AreaViewModel = model.PersonaLogueadaViewModel.AreaViewModel;
                model.IdArea = model.AreaViewModel.Id.ToString();
            }
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Objetivos";            
            ViewBag.Titulo = model.Titulo;

            int idObjetivo = await ObjetivoService.Guardar(model);

            return RedirectToAction("Editar", "Objetivo", new { id = idObjetivo, msgExito = "El objetivo se ha guardado exitosamente." });
        }

        [HttpGet]
        [EncryptedActionParameter]
        public async Task<ActionResult> Editar(string id, string msgExito)
        {   
            ObjetivoViewModel model = await ObjetivoService.GetById(Int32.Parse(id));

            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];
            model.Titulo = "Objetivos";

            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(ObjetivoViewModel model)
        {
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Objetivos";
            ViewBag.Titulo = model.Titulo;

            model.FechaUltimaModificacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
            model.UltimoUsuarioModifico = User.Identity.Name;

            int idObjetivo = await ObjetivoService.Guardar(model);

            return RedirectToAction("Editar", "Objetivo", new { q = MyExtensions.Encrypt(new { id = idObjetivo, msgExito = "El objetivo se ha guardado exitosamente." }) });
        }

        [HttpGet]
        [EncryptedActionParameter]
        public async Task<ActionResult> Ver(string id)
        {
            ObjetivoViewModel model = await ObjetivoService.GetById(Int32.Parse(id));
            model.Titulo = "Objetivos";
            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public async Task<JsonResult> BuscarObjetivos(string nombreObjetivo, string idArea)
        {
            BuscarObjetivoViewModel filtro = new BuscarObjetivoViewModel();
            filtro.Busqueda.Nombre = nombreObjetivo;
            filtro.Busqueda.IdArea = idArea;

            return Json(await ObjetivoService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> BuscarArea(string idObjetivo)
        {
            return Json(await AreaService.GetByIdObjetivo(Int32.Parse(idObjetivo)), JsonRequestBehavior.AllowGet);
        }
    }
}