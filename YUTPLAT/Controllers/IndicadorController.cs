using System;
using System.Collections.Generic;
using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Controllers
{
    public class IndicadorController : Controller
    {
        public IIndicadorService IndicadorService { get; set; }
        public IFrecuenciaMedicionIndicadorService FrecuenciaMedicionIndicadorService { get; set; }

        public IndicadorController(IIndicadorService indicadorService, IFrecuenciaMedicionIndicadorService frecuenciaMedicionIndicadorService)
        {
            this.IndicadorService = indicadorService;
            this.FrecuenciaMedicionIndicadorService = frecuenciaMedicionIndicadorService;
        }

        [HttpGet]
        public ActionResult Buscar()
        {
            BuscarIndicadorViewModel model = new BuscarIndicadorViewModel();
            model.Busqueda.Titulo = "Indicadores";

            ViewBag.Titulo = model.Busqueda.Titulo;

            return View(model);
        }

        [HttpPost]
        public ActionResult Buscar(BuscarIndicadorViewModel model)
        {
            ViewBag.SinResultados = null;

            IList<IndicadorViewModel> indicadors = IndicadorService.Buscar(model);

            model.Resultados = indicadors;
            model.Busqueda.Titulo = "Indicadores";

            ViewBag.Titulo = model.Busqueda.Titulo;

            if (indicadors == null || indicadors.Count <= 0)
                ViewBag.SinResultados = "No se han encontrado indicadores para la búsqueda realizada.";

            return View(model);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            IndicadorViewModel model = new IndicadorViewModel();
            model.Titulo = "Indicadores";
            model.FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        public ActionResult Crear(IndicadorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Indicadores";

            ViewBag.Titulo = model.Titulo;

            int idIndicador = IndicadorService.Guardar(model);

            return RedirectToAction("Editar", "Indicador", new { id = idIndicador, msgExito = "El indicador se ha guardado exitosamente." });
        }

        [HttpGet]
        public ActionResult Editar(int id, string msgExito)
        {
            IndicadorViewModel model = IndicadorService.GetById(id);

            model.Titulo = "Indicadores";

            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(IndicadorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Titulo = "Indicadores";
            ViewBag.Titulo = model.Titulo;

            model.FechaUltimaModificacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
            model.UltimoUsuarioModifico = User.Identity.Name;

            int idIndicador = IndicadorService.Guardar(model);

            return RedirectToAction("Editar", "Indicador", new { id = idIndicador, msgExito = "El área se ha guardado exitosamente." });
        }

        [HttpGet]
        public ActionResult Ver(int id)
        {
            IndicadorViewModel model = IndicadorService.GetById(id);
            model.Titulo = "Indicadores";
            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public JsonResult BuscarFrecuencias(string nombreFrecuencia)
        {
            FrecuenciaMedicionIndicadorViewModel filtro = new FrecuenciaMedicionIndicadorViewModel();
            filtro.Descripcion = nombreFrecuencia;

            return Json(FrecuenciaMedicionIndicadorService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }
    }
}