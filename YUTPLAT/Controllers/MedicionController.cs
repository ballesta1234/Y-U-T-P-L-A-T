using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using System.Threading.Tasks;
using YUTPLAT.Helpers;
using System.Collections.Generic;
using YUTPLAT.ViewModel;

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


        [HttpGet]
        public FileContentResult ExportToExcel()
        {
            List<MedicionExportarDTO> mediciones = (List<MedicionExportarDTO>)IndicadorAutomaticoCPIStrategy.ObtenerDetallesMediciones();           
                        
            string[] columnas = { "Proyecto", "Mes", "Valor" };
            byte[] filecontent = ExcelExportHelper.ExportExcel(mediciones, "Detalles Indicador CPI", false, columnas);
            return File(filecontent, ExcelExportHelper.ExcelContentType, "DetalleIndicador.xlsx");
        }

    }

    public class Technology
    {
        public string Name { get; set; }
        public int Project { get; set; }
        public int Developer { get; set; }
        public int TeamLeader { get; set; }
    }
}