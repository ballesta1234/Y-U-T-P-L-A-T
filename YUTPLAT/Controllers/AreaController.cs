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
            IList<AreaViewModel> areas = AreaService.Todas();

            AreaViewModel model = new AreaViewModel();
            model.Titulo = "Áreas";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }
    }
}