using System.Collections.Generic;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IIndicadorAutomaticoStrategy
    {
        void EjecutarIndicador(IndicadorViewModel indicadorViewModel);        
        decimal RecalcularIndicador(int mes, int anio, int idIndicador);
        byte[] ObtenerArchivo(int anio, int mes, int idIndicador);
    }
}