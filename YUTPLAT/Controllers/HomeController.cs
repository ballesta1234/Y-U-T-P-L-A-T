using System.Web.Mvc;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }       
    }
}