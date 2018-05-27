using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using System.Threading.Tasks;
using YUTPLAT.Helpers;
using System;
using YUTPLAT.Helpers.Filters;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class MedicionController : Controller
    {
        public IMedicionService MedicionService { get; set; }
        public IIndicadorAutomaticoStrategy IndicadorAutomaticoCPIStrategy { get; set; }
        public IAnioTableroService AnioTableroService { get; set; }

        public MedicionController(IMedicionService medicionService,
                                  IIndicadorAutomaticoStrategy indicadorAutomaticoCPIStrategy,
                                  AnioTableroService anioTableroService)
        {
            this.MedicionService = medicionService;
            IndicadorAutomaticoCPIStrategy = indicadorAutomaticoCPIStrategy;
            AnioTableroService = anioTableroService;
        }

        public async Task<JsonResult> Recalcular(int idIndicador, int mes)
        {
            int anio = (await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]))).Anio;

            // Por el momento solo es automático el indicador para CPI
            decimal valor = IndicadorAutomaticoCPIStrategy.RecalcularIndicador(mes, anio);
            return Json(valor, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [EncryptedActionParameter]
        public async Task<FileContentResult> ExportToExcel(string mes)
        {
            int anio = (await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]))).Anio;
            return File(MedicionService.ObtenerArchivo(anio, Int32.Parse(mes)), ExcelExportHelper.ExcelContentType, "DetalleIndicador.xlsx");
        }
    }    
}