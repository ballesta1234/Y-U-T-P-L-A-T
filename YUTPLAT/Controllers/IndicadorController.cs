using System;
using System.Collections.Generic;
using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;
using System.Linq;
using YUTPLAT.Helpers.Filters;
using YUTPLAT.Helpers;

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
            string rolAdmin = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Admin);
            string rolUsuario = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Usuario);

            ViewBag.SinResultados = null;

            model.NombreUsuario = User.Identity.Name;
            model.RolUsuario = User.IsInRole(rolAdmin) ? rolAdmin : rolUsuario;

            IList <IndicadorViewModel> indicadores = IndicadorService.Buscar(model);

            model.Resultados = indicadores;
            model.Busqueda.Titulo = "Indicadores";

            ViewBag.Titulo = model.Busqueda.Titulo;

            if (indicadores == null || indicadores.Count <= 0)
                ViewBag.SinResultados = "No se han encontrado indicadores para la búsqueda realizada.";

            return View(model);
        }

        [HttpGet]
        [EncryptedActionParameter]
        public ActionResult Crear(string idObjetivo)
        {
            IndicadorViewModel model = new IndicadorViewModel();
            model.Titulo = "Indicadores";
            model.FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
                        
            Session["InteresadosSeleccionados"] = model.Interesados;
            Session["ResponsablesSeleccionados"] = model.Responsables;

            if (idObjetivo != null)
                model.ObjetivoViewModel = ObjetivoService.GetById(Int32.Parse(idObjetivo));

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]        
        public ActionResult Crear(IndicadorViewModel model)
        {
            model.FrecuenciaMedicionIndicadorViewModel = FrecuenciaMedicionIndicadorService.GetById(Int32.Parse(model.FrecuenciaMedicionIndicadorID));

            if (!String.IsNullOrEmpty(model.ObjetivoID) && !model.ObjetivoID.Equals("0"))
                model.ObjetivoViewModel = ObjetivoService.GetById(Int32.Parse(model.ObjetivoID));

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
            
            int idIndicador = IndicadorService.Guardar(model);
            
            return RedirectToAction("Editar", "Indicador", new { q = MyExtensions.Encrypt(new { id = idIndicador, msgExito = "El indicador se ha guardado exitosamente." }) });
        }

        [HttpGet]
        [EncryptedActionParameter]
        public ActionResult Editar(string id, string msgExito)
        {
            IndicadorViewModel model = IndicadorService.GetById(Int32.Parse(id));
            model.CantidadInteresadosElegidos = model.Interesados.Count;
            model.CantidadResponsablesElegidos = model.Responsables.Count;

            model.Titulo = "Indicadores";

            Session["InteresadosSeleccionados"] = model.Interesados;
            Session["ResponsablesSeleccionados"] = model.Responsables;

            ViewBag.Titulo = model.Titulo;
            ViewBag.MensageExito = msgExito;

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(IndicadorViewModel model)
        {
            model.FrecuenciaMedicionIndicadorViewModel = FrecuenciaMedicionIndicadorService.GetById(Int32.Parse(model.FrecuenciaMedicionIndicadorID));

            if(!String.IsNullOrEmpty(model.ObjetivoID) && !model.ObjetivoID.Equals("0"))
                model.ObjetivoViewModel = ObjetivoService.GetById(Int32.Parse(model.ObjetivoID));

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
            int idIndicador = IndicadorService.Guardar(model);

            return RedirectToAction("Editar", "Indicador", new { q = MyExtensions.Encrypt(new { id = idIndicador, msgExito = "El indicador se ha guardado exitosamente." }) });
        }

        [HttpGet]
        [EncryptedActionParameter]
        public ActionResult Ver(string id)
        {
            IndicadorViewModel model = IndicadorService.GetById(Int32.Parse(id));
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

        public JsonResult BuscarInteresado(string nombreOApellidoONombreUsuario)
        {
            PersonaViewModel filtro = new PersonaViewModel();
            filtro.NombreOApellidoONombreUsuario = nombreOApellidoONombreUsuario;

            IList<PersonaViewModel> interesadosSeleccionados = 
                (IList<PersonaViewModel>)Session["InteresadosSeleccionados"];

            IList<PersonaViewModel> busqueda =
                PersonaService.Buscar(filtro).Except(interesadosSeleccionados, new PersonaViewModelComparer()).ToList();

            return Json(busqueda, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarResponsable(string nombreOApellidoONombreUsuario)
        {
            PersonaViewModel filtro = new PersonaViewModel();
            filtro.NombreOApellidoONombreUsuario = nombreOApellidoONombreUsuario;

            IList<PersonaViewModel> responsablesSeleccionados =
                (IList<PersonaViewModel>)Session["ResponsablesSeleccionados"];

            IList<PersonaViewModel> busqueda =
                PersonaService.Buscar(filtro).Except(responsablesSeleccionados, new PersonaViewModelComparer()).ToList();

            return Json(busqueda, JsonRequestBehavior.AllowGet);
        }
    }
}