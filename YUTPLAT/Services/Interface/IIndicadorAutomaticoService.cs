using System.Collections.Generic;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IIndicadorAutomaticoService
    {
        void GenerarJobsTareasAutomaticas();
        IList<IndicadorAutomaticoViewModel> Todos();

        byte[] ObtenerArchivo(int anio, int mes, int idIndicador);
        decimal RecalcularIndicador(int anio, int mes, int idIndicador);
    }
}