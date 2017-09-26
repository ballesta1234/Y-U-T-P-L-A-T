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
            IList<AreaViewModel> areas = AreaService.Todas();

            model.Resultados = areas;
            model.Busqueda.Titulo = "Áreas";

            ViewBag.Titulo = model.Busqueda.Titulo;

            return View(model);
        }
    }
}