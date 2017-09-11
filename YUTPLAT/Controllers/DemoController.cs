using System.Web.Mvc;
using YUTPLAT.Models;

namespace YUTPLAT.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Dashboard()
        {
            DemoViewModel model = new DemoViewModel();
            model.Titulo = "Dashboard";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Users()
        {
            DemoViewModel model = new DemoViewModel();
            model.Titulo = "User profile";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Table()
        {
            DemoViewModel model = new DemoViewModel();
            model.Titulo = "Table list";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Typography()
        {
            DemoViewModel model = new DemoViewModel();
            model.Titulo = "Typography";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Icons()
        {
            DemoViewModel model = new DemoViewModel();
            model.Titulo = "Icons";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Maps()
        {
            DemoViewModel model = new DemoViewModel();
            model.Titulo = "Maps";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Notifications()
        {
            DemoViewModel model = new DemoViewModel();
            model.Titulo = "Notifications";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }
    }
}