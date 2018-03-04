using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using System.Threading.Tasks;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class MedicionController : Controller
    {
        public IMedicionService MedicionService { get; set; }
       
        public MedicionController(IMedicionService medicionService)
        {
            this.MedicionService = medicionService;
        }

        public async Task<JsonResult> Recalcular(int idIndicador, int mes)
        {
            decimal valor = await MedicionService.CalcularMedicionAutomatica(idIndicador, mes);
            return Json(valor, JsonRequestBehavior.AllowGet);
        }
    }
}