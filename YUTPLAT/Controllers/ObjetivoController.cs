using System;
using System.Collections.Generic;
using System.Web.Mvc;
using YUTPLAT.Models;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Controllers
{
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

            ViewBag.Titulo = model.Busqueda.Titulo;

            return View(model);
        }

        [HttpPost]
        public ActionResult Buscar(BuscarObjetivoViewModel model)
        {
            ViewBag.SinResultados = null;

            IList <ObjetivoViewModel> objetivos = ObjetivoService.Buscar(model);

            model.Resultados = objetivos;
            model.Busqueda.Titulo = "Objetivos";

            ViewBag.Titulo = model.Busqueda.Titulo;

            if (objetivos == null || objetivos.Count <= 0)
                ViewBag.SinResultados = "No se han encontrado objetivos para la búsqueda realizada.";

            return View(model);
        }

        [HttpGet]
        public ActionResult Crear(int? idArea)
        {
            ObjetivoViewModel model = new ObjetivoViewModel();
            model.Titulo = "Objetivos";
            model.FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");

            if(idArea != null)
                model.AreaViewModel = AreaService.GetById(idArea.Value);

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }       

        [HttpPost]
        public ActionResult Crear(ObjetivoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Objetivos";

            ViewBag.Titulo = model.Titulo;

            int idObjetivo = ObjetivoService.Guardar(model);

            return RedirectToAction("Editar", "Objetivo", new { id = idObjetivo, msgExito = "El objetivo se ha guardado exitosamente." });
        }

        [HttpGet]
        public ActionResult Editar(int id, string msgExito)
        {
            ObjetivoViewModel model = ObjetivoService.GetById(id);

            model.Titulo = "Objetivos";

            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ObjetivoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Objetivos";
            ViewBag.Titulo = model.Titulo;

            model.FechaUltimaModificacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
            model.UltimoUsuarioModifico = User.Identity.Name;

            int idObjetivo = ObjetivoService.Guardar(model);

            return RedirectToAction("Editar", "Objetivo", new { id = idObjetivo, msgExito = "El objetivo se ha guardado exitosamente." });
        }

        [HttpGet]
        public ActionResult Ver(int id)
        {
            ObjetivoViewModel model = ObjetivoService.GetById(id);
            model.Titulo = "Objetivos";
            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public JsonResult BuscarObjetivos(string nombreObjetivo)
        {
            BuscarObjetivoViewModel filtro = new BuscarObjetivoViewModel();
            filtro.Busqueda.Nombre = nombreObjetivo;

            return Json(ObjetivoService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }
    }
}