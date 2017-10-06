using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
        public ActionResult Buscar()
        {
            BuscarAreaViewModel model = new BuscarAreaViewModel();
            model.Busqueda.Titulo = "Áreas";

            ViewBag.Titulo = model.Busqueda.Titulo;

            return View(model);
        }

        [HttpPost]
        public ActionResult Buscar(BuscarAreaViewModel model)
        {
            ViewBag.SinResultados = null;

            IList <AreaViewModel> areas = AreaService.Buscar(model);

            model.Resultados = areas;
            model.Busqueda.Titulo = "Áreas";

            ViewBag.Titulo = model.Busqueda.Titulo;

            if(areas == null || areas.Count <=0)
                ViewBag.SinResultados = "No se han encontrado áreas para la búsqueda realizada.";

            return View(model);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            AreaViewModel model = new AreaViewModel();
            model.Titulo = "Áreas";
            model.FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        public ActionResult Crear(AreaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Áreas";

            ViewBag.Titulo = model.Titulo;

            int idArea = AreaService.Guardar(model);

            return RedirectToAction("Editar", "Area", new { id = idArea, msgExito = "El área se ha guardado exitosamente." });
        }

        [HttpGet]
        public ActionResult Editar(int id, string msgExito)
        {
            AreaViewModel model = AreaService.GetById(id);

            model.Titulo = "Áreas";            

            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(AreaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Áreas";
            ViewBag.Titulo = model.Titulo;

            model.FechaUltimaModificacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
            model.UltimoUsuarioModifico = User.Identity.Name;

            int idArea = AreaService.Guardar(model);

            return RedirectToAction("Editar", "Area", new { id = idArea, msgExito = "El área se ha guardado exitosamente." });
        }

        [HttpGet]
        public ActionResult Ver(int id)
        {
            AreaViewModel model = AreaService.GetById(id);
            model.Titulo = "Áreas";
            ViewBag.Titulo = model.Titulo;
            
            return View(model);
        }

        public JsonResult BuscarAreas(string nombreArea)
        {
            BuscarAreaViewModel filtro = new BuscarAreaViewModel();
            filtro.Busqueda.Nombre = nombreArea;

            return Json(AreaService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }
    }
}