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
        public IIndicadorAutomaticoService IndicadorAutomaticoService { get; set; }
        public IAnioTableroService AnioTableroService { get; set; }

        public MedicionController(IMedicionService medicionService,
                                  IIndicadorAutomaticoService indicadorAutomaticoService,
                                  AnioTableroService anioTableroService)
        {
            this.MedicionService = medicionService;
            IndicadorAutomaticoService = indicadorAutomaticoService;
            AnioTableroService = anioTableroService;
        }

        public async Task<JsonResult> Recalcular(int idIndicador, int mes)
        {
            int anio = (await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]))).Anio;
                        
            decimal valor = IndicadorAutomaticoService.RecalcularIndicador(anio, mes, idIndicador);
            return Json(valor, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [EncryptedActionParameter]
        public async Task<FileContentResult> ExportToExcel(string mes, string idIndicador)
        {
            int anio = (await AnioTableroService.GetById(Int32.Parse((string)Session["IdAnioTablero"]))).Anio;
            return File(IndicadorAutomaticoService.ObtenerArchivo(anio, Int32.Parse(mes), Int32.Parse(idIndicador)), ExcelExportHelper.ExcelContentType, "DetalleIndicador.xlsx");
        }
    }    
}