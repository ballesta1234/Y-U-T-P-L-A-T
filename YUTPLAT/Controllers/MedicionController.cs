using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using System.Threading.Tasks;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class MedicionController : Controller
    {
        public IMedicionService MedicionService { get; set; }
        public IIndicadorAutomaticoStrategy IndicadorAutomaticoCPIStrategy { get; set; }

        public MedicionController(IMedicionService medicionService,
                                  IIndicadorAutomaticoStrategy indicadorAutomaticoCPIStrategy)
        {
            this.MedicionService = medicionService;
            IndicadorAutomaticoCPIStrategy = indicadorAutomaticoCPIStrategy;
        }

        public JsonResult Recalcular(int idIndicador, int mes)
        {
            // Por el momento solo es automático el indicador para CPI
            decimal valor = IndicadorAutomaticoCPIStrategy.RecalcularIndicador(mes);
            return Json(valor, JsonRequestBehavior.AllowGet);
        }
    }
}