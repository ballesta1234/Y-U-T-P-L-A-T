using System.Collections.Generic;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IIndicadorAutomaticoStrategy
    {
        void EjecutarIndicador(IndicadorViewModel indicadorViewModel);
        IList<MedicionExportarDTO> ObtenerDetallesMediciones();
        decimal RecalcularIndicador(int mes);
    }
}