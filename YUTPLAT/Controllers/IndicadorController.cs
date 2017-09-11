using System.Web.Mvc;
using YUTPLAT.Models;

namespace YUTPLAT.Controllers
{
    public class IndicadorController : Controller
    {
        public ActionResult Buscar()
        {
            IndicadorViewModel model = new IndicadorViewModel();
            model.Titulo = "Indicadores";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }
    }
}