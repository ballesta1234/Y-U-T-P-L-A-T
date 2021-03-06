﻿using System;
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
        public IAreaService AreaService { get; set; }
        public ITableroService TableroService { get; set; }

        public TableroController(IMedicionService medicionService,
                                 IAnioTableroService anioTableroService,
                                 IAreaService areaService,
                                 ITableroService tableroService)
        {
            this.MedicionService = medicionService;
            this.AnioTableroService = anioTableroService;
            this.AreaService = areaService;
            this.TableroService = tableroService;
        }

        [HttpGet]
        [EncryptedActionParameter]
        public async Task<ActionResult> Ver(string msgExito)
        {
            LimpiarSession();

            TableroViewModel model = new TableroViewModel();
            model.Titulo = "Tablero de comando ";

            if (Session["IdAnioTablero"] != null)
            {
                model.AnioTableroViewModel = await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]));
            }
            
            string idAreaTablero = (string)Session["IdAreaTablero"];

            if (idAreaTablero != null && !idAreaTablero.Equals("0"))
            {
                model.AreaTableroViewModel = await AreaService.GetById(Int32.Parse(idAreaTablero));
            }
            else
            {
                model.AreaTableroViewModel = new AreaViewModel { Id = 0, Nombre ="Todas las áreas"};
            }
            
            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

            await TableroService.AuditarVisualizacionTablero((PersonaViewModel)Session["Persona"]);

            return View(model);
        }

        public ActionResult Gauge()
        {
            LimpiarSession();

            DemoViewModel model = new DemoViewModel();
            model.Titulo = "Dashboard";
            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Tablero()
        {
            LimpiarSession();

            TableroViewModel model = new TableroViewModel();
            model.Titulo = "Tablero de comando";
            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerHeatMapViewModel(string nombre)
        { 
            LimpiarSession();

            BuscarIndicadorViewModel model = new BuscarIndicadorViewModel();

            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];            
            model.AnioTablero = (await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]))).Anio;

            string idAreaTablero = (string)Session["IdAreaTablero"];

            if (idAreaTablero != null && !idAreaTablero.Equals("0"))
            {
                model.Busqueda.AreaID = idAreaTablero;
            }
            else
            {
                model.TodasLasAreas = true; ;
            }
            
            return Json(await MedicionService.ObtenerHeatMapViewModel(model), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerGaugeViewModel(long grupo)
        {
            LimpiarSession();

            PersonaViewModel personaViewModel = (PersonaViewModel)Session["Persona"];
            int anio = (await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]))).Anio;
            return Json(await MedicionService.ObtenerGaugeViewModel(grupo, anio, personaViewModel, true), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerLineViewModel(long grupo)
        {
            LimpiarSession();

            PersonaViewModel personaViewModel = (PersonaViewModel)Session["Persona"];
            int anio = (await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]))).Anio;
            return Json(await MedicionService.ObtenerLineViewModel(grupo, anio, personaViewModel), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CargarMedicion(MedicionViewModel model)
        {            
            if ( (!model.NoAplica && !ModelState.IsValidField("Valor")) ||
                !ModelState.IsValidField("Comentario") ||
                !MedicionService.ValidaMedicion(model))
            {
                ModelState.AddModelError(string.Empty, "Verifique que todos los campos estén cargados y sean correctos.");
                return PartialView("Medicion/_Crear", model);
            }

            LimpiarSession();

            model.Anio = (await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]))).Anio;
            model.FechaCarga = DateTimeHelper.OntenerFechaActual().ToString("dd/MM/yyyy HH:mm tt");
            model.UsuarioCargo = User.Identity.Name;

            await MedicionService.GuardarMedicion(model);
            return Json(new { success = true });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CargarMedicionAutomatica(MedicionViewModel model)
        {
            if (!ModelState.IsValidField("Valor") ||
                !ModelState.IsValidField("Comentario") ||
                !MedicionService.ValidaMedicion(model))
            {
                ModelState.AddModelError(string.Empty, "Verifique que todos los campos estén cargados y sean correctos.");
                return PartialView("Medicion/_CrearAutomatico", model);
            }

            LimpiarSession();

            model.Anio = (await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]))).Anio;
            model.FechaCarga = DateTimeHelper.OntenerFechaActual().ToString("dd/MM/yyyy HH:mm tt");
            model.UsuarioCargo = User.Identity.Name;

            await MedicionService.GuardarMedicion(model);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<ActionResult> AbrirModalCargaMedicion(int idIndicador, int mes, int idAnio, int? idMedicion, long grupo, bool tieneAccesoEscritura, bool esAutomatico)
        {
            LimpiarSession();

            PersonaViewModel personaViewModel = (PersonaViewModel)Session["Persona"];            
            AnioTableroViewModel anioViewModel = await AnioTableroService.GetById(idAnio);
            MedicionViewModel medicionViewModel = await MedicionService.ObtenerMedicionViewModel(idIndicador, mes, idMedicion, grupo, anioViewModel.Anio, personaViewModel, true);
            medicionViewModel.EsIndicadorAutomatico = esAutomatico;

            DateTime fechaActual = DateTimeHelper.OntenerFechaActual();

            string view = "Medicion/_Crear";
            
            if (
                (anioViewModel.Anio != fechaActual.Year && !(fechaActual.Month == 1 && mes == 12)) 
                || 
                (!personaViewModel.EsJefeArea && !tieneAccesoEscritura)
                ||
                (!tieneAccesoEscritura && personaViewModel.EsJefeArea && !personaViewModel.AreaViewModel.Id.ToString().Equals(medicionViewModel.IndicadorViewModel.AreaID))
               )
            {
                view = "Medicion/_Ver";
            }
            else if (esAutomatico)
            {
                view = "Medicion/_CrearAutomatico";
            }
           
            Session["FrenarRevision_" + personaViewModel.NombreUsuario] = true;

            return PartialView(view, medicionViewModel);
        }

        public async Task<JsonResult> BuscarAnios(string nombreAnio)
        {
            LimpiarSession();

            AnioTableroViewModel filtro = new AnioTableroViewModel();
            filtro.Descripcion = nombreAnio;
            filtro.Habilitado = true;

            return Json(await AnioTableroService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CambiarAnioTablero(string idAnio)
        {
            LimpiarSession();

            Session["IdAnioTablero"] = idAnio;
            return Json(new { success = true });
        }

        public ActionResult CambiarAreaTablero(string idArea)
        {
            LimpiarSession();

            Session["IdAreaTablero"] = idArea;
            return Json(new { success = true });
        }

        public async Task<JsonResult> Revisar()
        {
            PersonaViewModel personaViewModel = (PersonaViewModel)Session["Persona"];

            bool frenarRevision = (bool)Session["FrenarRevision_" + personaViewModel.NombreUsuario];

            if (!frenarRevision)
            {
                return Json(new { success = await TableroService.ActualizarTablero(personaViewModel) });
            }

            return Json(new { success = false });
        }

        public JsonResult CerrarPopup()
        {
            LimpiarSession();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        private void LimpiarSession()
        {
            PersonaViewModel personaViewModel = (PersonaViewModel)Session["Persona"];

            if (personaViewModel != null)
            {
                Session["FrenarRevision_" + personaViewModel.NombreUsuario] = false;
            }
        }

    }
}