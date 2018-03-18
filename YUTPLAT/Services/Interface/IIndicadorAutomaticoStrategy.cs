using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IIndicadorAutomaticoStrategy
    {
        void EjecutarIndicador(IndicadorViewModel indicadorViewModel);
        decimal RecalcularIndicador(int mes);
    }
}