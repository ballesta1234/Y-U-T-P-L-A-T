using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using YUTPLAT.Helpers;
using YUTPLAT.Helpers.Filters;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class TableroController : Controller
    {
        public IMedicionService MedicionService { get; set; }
        public IAnioTableroService AnioTableroService { get; set; }

        public TableroController(IMedicionService medicionService,
                                 IAnioTableroService anioTableroService)
        {
            this.MedicionService = medicionService;
            this.AnioTableroService = anioTableroService;
        }

        [HttpGet]
        [EncryptedActionParameter]
        public async Task<ActionResult> Ver(string msgExito)
        {
            TableroViewModel model = new TableroViewModel();
            model.Titulo = "Tablero de comando ";

            if (Session["IdAnioTablero"] != null)
            {
                model.AnioTableroViewModel = await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]));
            }

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
            model.Titulo = "Tablero de comando";
            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerHeatMapViewModel(string nombre)
        {
            string rolAdmin = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Admin);
            string rolUsuario = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Usuario);

            BuscarIndicadorViewModel model = new BuscarIndicadorViewModel();

            model.NombreUsuario = User.Identity.Name;
            model.RolUsuario = User.IsInRole(rolAdmin) ? rolAdmin : rolUsuario;
            model.AnioTablero = (await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]))).Anio;

            return Json(await MedicionService.ObtenerHeatMapViewModel(model), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerGaugeViewModel(long grupo)
        {
            return Json(await MedicionService.ObtenerGaugeViewModel(grupo), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerLineViewModel(long grupo)
        {
            return Json(await MedicionService.ObtenerLineViewModel(grupo), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CargarMedicion(MedicionViewModel model)
        {
            if (!ModelState.IsValidField("Valor") ||
                !ModelState.IsValidField("Comentario") ||
                !MedicionService.ValidaMedicion(model))
            {
                ModelState.AddModelError(string.Empty, "Verifique que todos los campos estén cargados y sean correctos.");
                return PartialView("Medicion/_Crear", model);
            }

            model.FechaCarga = DateTimeHelper.OntenerFechaActual().ToString("dd/MM/yyyy HH:mm tt");
            model.UsuarioCargo = User.Identity.Name;

            await MedicionService.GuardarMedicion(model);
            return Json(new { success = true });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CargarMedicionAutomatica(MedicionViewModel model)
        {
            if (!ModelState.IsValidField("Comentario") ||
                !MedicionService.ValidaMedicion(model))
            {
                ModelState.AddModelError(string.Empty, "Verifique que todos los campos estén cargados y sean correctos.");
                return PartialView("Medicion/_CrearAutomatico", model);
            }

            model.FechaCarga = DateTimeHelper.OntenerFechaActual().ToString("dd/MM/yyyy HH:mm tt");
            model.UsuarioCargo = User.Identity.Name;

            await MedicionService.GuardarMedicion(model);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<ActionResult> AbrirModalCargaMedicion(int idIndicador, int mes, int? idMedicion, long grupo, bool tieneAccesoEscritura, bool esAutomatico)
        {
            string view = "Medicion/_Crear";

            if ((idMedicion != null && mes != DateTimeHelper.OntenerFechaActual().Month) || !tieneAccesoEscritura)
            {
                view = "Medicion/_Ver";
            }
            else if (esAutomatico)
            {
                view = "Medicion/_CrearAutomatico";
            }


            return PartialView(view, await MedicionService.ObtenerMedicionViewModel(idIndicador, mes, idMedicion, grupo));
        }

        public async Task<JsonResult> BuscarAnios(string nombreAnio)
        {
            AnioTableroViewModel filtro = new AnioTableroViewModel();
            filtro.Descripcion = nombreAnio;
            filtro.Habilitado = true;

            return Json(await AnioTableroService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CambiarAnioTablero(string idAnio)
        {
            Session["IdAnioTablero"] = idAnio;
            return Json(new { success = true });
        }

    }
}