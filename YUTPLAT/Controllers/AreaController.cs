using System;
using System.Collections.Generic;
using System.Web.Mvc;
using YUTPLAT.Models;
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
            IList<AreaViewModel> areas = AreaService.Buscar(model);

            model.Resultados = areas;
            model.Busqueda.Titulo = "Áreas";

            ViewBag.Titulo = model.Busqueda.Titulo;

            if(areas == null || areas.Count <=0)
                ViewBag.SinResultados = "No se han encontrado áreas para la búsqueda realizada.";

            return View(model);
        }

        public ActionResult Crear()
        {
            AreaViewModel model = new AreaViewModel();
            model.Titulo = "Áreas";
            model.FechaCreacion = DateTime.Now.ToString();

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        public ActionResult Crear(AreaViewModel model)
        {   
            model.Titulo = "Áreas";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }
    }
}