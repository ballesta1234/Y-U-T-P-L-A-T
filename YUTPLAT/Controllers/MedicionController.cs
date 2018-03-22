using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using System.Threading.Tasks;
using YUTPLAT.Helpers;
using System.Collections.Generic;

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
            List<Technology> technologies = new List<Technology>{
                     new Technology{Name="ASP.NET", Project=12,Developer=50, TeamLeader=6},
                    new Technology{Name="Php", Project=40,Developer=60, TeamLeader=9},
                    new Technology{Name="iOS", Project=11,Developer=5, TeamLeader=1},
                     new Technology{Name="Android", Project=20,Developer=26, TeamLeader=2}
                };
            
            string[] columns = { "Name", "Project", "Developer" };
            byte[] filecontent = ExcelExportHelper.ExportExcel(technologies, "Technology", true, columns);
            return File(filecontent, ExcelExportHelper.ExcelContentType, "Technologies.xlsx");
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