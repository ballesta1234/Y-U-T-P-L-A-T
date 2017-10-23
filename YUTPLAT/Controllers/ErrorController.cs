using System.Web.Mvc;
using YUTPLAT.Helpers.Filters;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        [EncryptedActionParameter]
        public ActionResult HttpError(string msg)
        {
            ErrorViewModel model = new ErrorViewModel();
            model.Mensaje = msg;
                        
            return View(model);
        }

        [HttpGet]
        [EncryptedActionParameter]
        public ActionResult HttpErrorGeneral(string msg)
        {
            ErrorViewModel model = new ErrorViewModel();
            model.Mensaje = msg;

            return View(model);
        }
    }
}