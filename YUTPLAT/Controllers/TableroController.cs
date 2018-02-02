using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using YUTPLAT.Helpers;
using YUTPLAT.Helpers.Filters;
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

        [HttpGet]
        [EncryptedActionParameter]
        public ActionResult Ver(string msgExito)
        {
            TableroViewModel model = new TableroViewModel();
            model.Titulo = "Tablero";

            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

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
            string rolAdmin = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Admin);
            string rolUsuario = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Usuario);

            BuscarIndicadorViewModel model = new BuscarIndicadorViewModel();

            model.NombreUsuario = User.Identity.Name;
            model.RolUsuario = User.IsInRole(rolAdmin) ? rolAdmin : rolUsuario;

            return Json(MedicionService.ObtenerHeatMapViewModel(model), JsonRequestBehavior.AllowGet);
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
        public ActionResult CargarMedicion(MedicionViewModel model)
        {
            if (!ModelState.IsValidField("Valor") || !ModelState.IsValidField("Comentario"))
            {
                ModelState.AddModelError(string.Empty, "Verifique que todos los campos estén cargados y sean correctos.");
                return PartialView("Medicion/_Crear", model);
            }

            model.FechaCarga = DateTimeHelper.OntenerFechaActual().ToString("dd/MM/yyyy HH:mm tt");
            model.UsuarioCargo = User.Identity.Name;

            MedicionService.GuardarMedicion(model);
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult AbrirModalCargaMedicion(int idIndicador, int mes, int? idMedicion, long grupo, bool tieneAccesoEscritura)
        {
            string view = "Medicion/_Crear";

            if ( (idMedicion != null && mes != DateTimeHelper.OntenerFechaActual().Month) || !tieneAccesoEscritura)
            {
                view = "Medicion/_Ver";
            }

            return PartialView(view, MedicionService.ObtenerMedicionViewModel(idIndicador, mes, idMedicion, grupo));
        }

        
    }
}