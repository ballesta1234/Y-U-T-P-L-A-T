using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class TableroController : Controller
    {
        public IMedicionService MedicionService { get; set; }

        public TableroController(IMedicionService medicionService)
        {
            this.MedicionService = medicionService;
        }

        public ActionResult Ver()
        {
            TableroViewModel model = new TableroViewModel();
            model.Titulo = "Tablero";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Gauge()
        {
            DemoViewModel model = new DemoViewModel();
            model.Titulo = "Dashboard";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Tablero()
        {
            TableroViewModel model = new TableroViewModel();
            model.Titulo = "Tablero";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        public ActionResult ObtenerHeatMapViewModel(string nombre)
        {
            return Json(MedicionService.ObtenerHeatMapViewModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ObtenerGaugeViewModel(long grupo)
        {
            return Json(MedicionService.ObtenerGaugeViewModel(grupo), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ObtenerLineViewModel(long grupo)
        {
            return Json(MedicionService.ObtenerLineViewModel(grupo), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CargarMedicion(TableroViewModel model, string returnUrl)
        {
            return RedirectToAction("Ver", "Tablero", new { q = new { id = 12, msgExito = "El indicador se ha guardado exitosamente." } });
                        
        }

        [HttpPost]
        public ActionResult AbrirModalCargaMedicion(int idIndicador, int mes)
        {
            CargarMedicionViewModel entities = new CargarMedicionViewModel { Titulo = "matiasssssssssssss" };
            return PartialView("_ModalCargarMedicion", entities);
        }

        
    }
}