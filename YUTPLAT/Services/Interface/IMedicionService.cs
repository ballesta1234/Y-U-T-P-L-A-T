
using System.Collections.Generic;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IMedicionService
    {
        MedicionViewModel GetById(string id);

        IList<MedicionViewModel> Todas();

        IList<MedicionViewModel> Buscar(MedicionViewModel filtro);
        
        HeatMapViewModel ObtenerHeatMapViewModel();

        GaugeViewModel ObtenerGaugeViewModel(int idIndicador);
    }
}