using System.Web.Mvc;
using YUTPLAT.Models;

namespace YUTPLAT.Controllers
{
    public class AreaController : Controller
    {
        public ActionResult Buscar()
        {
            AreaViewModel model = new AreaViewModel();
            model.Titulo = "Áreas";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }
    }
}