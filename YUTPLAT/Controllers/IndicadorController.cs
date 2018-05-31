using System;
using System.Collections.Generic;
using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;
using System.Linq;
using YUTPLAT.Helpers.Filters;
using YUTPLAT.Helpers;
using System.Threading.Tasks;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class IndicadorController : Controller
    {
        public IIndicadorService IndicadorService { get; set; }
        public IPersonaService PersonaService { get; set; }
        public IObjetivoService ObjetivoService { get; set; }
        public IFrecuenciaMedicionIndicadorService FrecuenciaMedicionIndicadorService { get; set; }

        public IndicadorController(IIndicadorService indicadorService, 
                                   IFrecuenciaMedicionIndicadorService frecuenciaMedicionIndicadorService,
                                   IPersonaService personaService,
                                   IObjetivoService objetivoService)
        {
            this.IndicadorService = indicadorService;
            this.PersonaService = personaService;
            this.ObjetivoService = objetivoService;
            this.FrecuenciaMedicionIndicadorService = frecuenciaMedicionIndicadorService;
        }
        
        [HttpGet]
        [EncryptedActionParameter]
        public ActionResult Buscar(string msgExito)
        {
            BuscarIndicadorViewModel model = new BuscarIndicadorViewModel();
            model.Busqueda.Titulo = "Indicadores";
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            if(!model.PersonaLogueadaViewModel.EsAdmin)
            {
                model.Busqueda.AreaID = model.PersonaLogueadaViewModel.AreaViewModel.Id.ToString();
            }

            ViewBag.Titulo = model.Busqueda.Titulo;
            ViewBag.MensageExito = msgExito;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Buscar(BuscarIndicadorViewModel model)
        {            
            ViewBag.SinResultados = null;
            
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            if (!model.PersonaLogueadaViewModel.EsAdmin)
            {
                model.Busqueda.AreaID = model.PersonaLogueadaViewModel.AreaViewModel.Id.ToString();
            }

            IList <IndicadorViewModel> indicadores = await IndicadorService.Buscar(model);

            model.Resultados = indicadores;
            model.Busqueda.Titulo = "Indicadores";

            ViewBag.Titulo = model.Busqueda.Titulo;

            if (indicadores == null || indicadores.Count <= 0)
                ViewBag.SinResultados = "No se han encontrado indicadores para la búsqueda realizada.";

            return View(model);
        }

        [HttpGet]
        [EncryptedActionParameter]
        [Authorize(Roles = "admin, usuario")]
        public async Task<ActionResult> Crear(string idObjetivo)
        {
            IndicadorViewModel model = new IndicadorViewModel();
            model.Titulo = "Indicadores";
            model.FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");

            // Por el momento solo frecuencias mensuales
            model.FrecuenciaMedicionIndicadorViewModel = (await FrecuenciaMedicionIndicadorService.Buscar(new FrecuenciaMedicionIndicadorViewModel { Descripcion = "Mensual"})).FirstOrDefault();
            
            Session["InteresadosSeleccionados"] = model.Interesados;
            Session["ResponsablesSeleccionados"] = model.Responsables;

            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            if (model.PersonaLogueadaViewModel.AreaViewModel != null)
            {
                model.ObjetivoViewModel.AreaViewModel = model.PersonaLogueadaViewModel.AreaViewModel;
                model.AreaID = model.ObjetivoViewModel.AreaViewModel.Id.ToString();
            }

            if (idObjetivo != null)
                model.ObjetivoViewModel = await ObjetivoService.GetById(Int32.Parse(idObjetivo));

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, usuario")]
        public async Task<ActionResult> Crear(IndicadorViewModel model)
        {
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            if (model.PersonaLogueadaViewModel.AreaViewModel != null)
            {
                model.ObjetivoViewModel.AreaViewModel = model.PersonaLogueadaViewModel.AreaViewModel;
                model.AreaID = model.ObjetivoViewModel.AreaViewModel.Id.ToString();
            }

            model.FrecuenciaMedicionIndicadorViewModel = await FrecuenciaMedicionIndicadorService.GetById(Int32.Parse(model.FrecuenciaMedicionIndicadorID));

            if (!String.IsNullOrEmpty(model.ObjetivoID) && !model.ObjetivoID.Equals("0"))
                model.ObjetivoViewModel = await ObjetivoService.GetById(Int32.Parse(model.ObjetivoID));

            model.Interesados = (IList<PersonaViewModel>)Session["InteresadosSeleccionados"];
            model.Responsables = (IList<PersonaViewModel>)Session["ResponsablesSeleccionados"];

            model.CantidadInteresadosElegidos = model.Interesados.Count;
            model.CantidadResponsablesElegidos = model.Responsables.Count;

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Verifique que todos los campos estén cargados y sean correctos.");
                return View(model);
            }

            model.Titulo = "Indicadores";

            ViewBag.Titulo = model.Titulo;

            PersonaViewModel persona =  (PersonaViewModel)Session["Persona"];

            int idIndicador = await IndicadorService.Guardar(model, persona);
            
            object parametros = new { q = MyExtensions.Encrypt(new { id = idIndicador, msgExito = "El indicador se ha guardado exitosamente." }) };
            
            return RedirectToAction("Editar", "Indicador", parametros);           
        }

        [HttpGet]
        [EncryptedActionParameter]
        [Authorize(Roles = "admin, usuario")]
        public async Task<ActionResult> Editar(string id, string msgExito)
        {
            IndicadorViewModel model = await IndicadorService.GetById(Int32.Parse(id));

            model.CantidadInteresadosElegidos = model.Interesados.Count;
            model.CantidadResponsablesElegidos = model.Responsables.Count;
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];
            model.Titulo = "Indicadores";

            Session["InteresadosSeleccionados"] = model.Interesados;
            Session["ResponsablesSeleccionados"] = model.Responsables;

            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, usuario")]
        public async Task<ActionResult> Editar(IndicadorViewModel model)
        {
            model.FrecuenciaMedicionIndicadorViewModel = await FrecuenciaMedicionIndicadorService.GetById(Int32.Parse(model.FrecuenciaMedicionIndicadorID));
            model.PersonaLogueadaViewModel = (PersonaViewModel)Session["Persona"];

            if (!String.IsNullOrEmpty(model.ObjetivoID) && !model.ObjetivoID.Equals("0"))
                model.ObjetivoViewModel = await ObjetivoService.GetById(Int32.Parse(model.ObjetivoID));

            model.Interesados = (IList<PersonaViewModel>)Session["InteresadosSeleccionados"];
            model.Responsables = (IList<PersonaViewModel>)Session["ResponsablesSeleccionados"];

            model.CantidadInteresadosElegidos = model.Interesados.Count;
            model.CantidadResponsablesElegidos = model.Responsables.Count;

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Verifique que todos los campos estén cargados y sean correctos.");
                return View(model);
            }

            model.Titulo = "Indicadores";
            ViewBag.Titulo = model.Titulo;

            model.FechaUltimaModificacion = DateTimeHelper.OntenerFechaActual().ToString("dd/MM/yyyy HH:mm tt");
            model.UltimoUsuarioModifico = User.Identity.Name;

            PersonaViewModel persona =  (PersonaViewModel)Session["Persona"];

            int idIndicador = await IndicadorService.Guardar(model, persona);
            
            object parametros = new { q = MyExtensions.Encrypt(new { id = idIndicador, msgExito = "El indicador se ha guardado exitosamente." }) };
                        
            return RedirectToAction("Editar", "Indicador", parametros);            
        }

        [HttpGet]
        [EncryptedActionParameter]
        public async Task<ActionResult> Ver(string id, string msgExito)
        {
            IndicadorViewModel model = await IndicadorService.GetById(Int32.Parse(id));
            model.Titulo = "Indicadores";

            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

            return View(model);
        }

        public async Task<JsonResult> BuscarFrecuencias(string nombreFrecuencia)
        {
            FrecuenciaMedicionIndicadorViewModel filtro = new FrecuenciaMedicionIndicadorViewModel();
            filtro.Descripcion = nombreFrecuencia;

            return Json(await FrecuenciaMedicionIndicadorService.Buscar(filtro), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AgregarInteresado(string idPersona, string nombre)
        {
            PersonaViewModel interesado = new PersonaViewModel();
            interesado.Id = idPersona;
            interesado.Nombre = nombre;

            IList<PersonaViewModel> interesados = (IList<PersonaViewModel>)Session["InteresadosSeleccionados"];
            interesados.Add(interesado);

            return Json(interesados, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AgregarResponsable(string idPersona, string nombre)
        {
            PersonaViewModel responsable = new PersonaViewModel();
            responsable.Id = idPersona;
            responsable.Nombre = nombre;

            IList<PersonaViewModel> responsables = (IList<PersonaViewModel>)Session["ResponsablesSeleccionados"];
            responsables.Add(responsable);

            return Json(responsables, JsonRequestBehavior.AllowGet);
        }

        public JsonResult QuitarInteresado(string idPersona)
        {
            PersonaViewModel interesado = new PersonaViewModel();
            interesado.Id = idPersona;
           
            IList<PersonaViewModel> interesados = (IList<PersonaViewModel>)Session["InteresadosSeleccionados"];
            interesados.Remove(interesados.First(i => i.Id.Equals(idPersona)));

            return Json(interesados, JsonRequestBehavior.AllowGet);
        }

        public JsonResult QuitarResponsable(string idPersona)
        {
            PersonaViewModel responsable = new PersonaViewModel();
            responsable.Id = idPersona;

            IList<PersonaViewModel> responsables = (IList<PersonaViewModel>)Session["ResponsablesSeleccionados"];
            responsables.Remove(responsables.First(i => i.Id.Equals(idPersona)));

            return Json(responsables, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> BuscarInteresado(string nombreOApellidoONombreUsuario)
        {
            PersonaViewModel filtro = new PersonaViewModel();
            filtro.NombreOApellidoONombreUsuario = nombreOApellidoONombreUsuario;

            IList<PersonaViewModel> interesadosSeleccionados = 
                (IList<PersonaViewModel>)Session["InteresadosSeleccionados"];

            IList<PersonaViewModel> busqueda =
                (await PersonaService.Buscar(filtro)).Except(interesadosSeleccionados, new PersonaViewModelComparer()).ToList();

            return Json(busqueda, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> BuscarResponsable(string nombreOApellidoONombreUsuario)
        {
            PersonaViewModel filtro = new PersonaViewModel();
            filtro.NombreOApellidoONombreUsuario = nombreOApellidoONombreUsuario;

            IList<PersonaViewModel> responsablesSeleccionados =
                (IList<PersonaViewModel>)Session["ResponsablesSeleccionados"];

            IList<PersonaViewModel> busqueda =
                (await PersonaService.Buscar(filtro)).Except(responsablesSeleccionados, new PersonaViewModelComparer()).ToList();

            return Json(busqueda, JsonRequestBehavior.AllowGet);
        }
    }
}