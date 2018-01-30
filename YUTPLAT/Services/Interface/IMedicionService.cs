
using System.Collections.Generic;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IMedicionService
    {
        MedicionViewModel GetById(int id);

        IList<MedicionViewModel> Todas();

        IList<MedicionViewModel> Buscar(MedicionViewModel filtro);
        
        HeatMapViewModel ObtenerHeatMapViewModel();

        GaugeViewModel ObtenerGaugeViewModel(long grupo);

        IList<LineViewModel> ObtenerLineViewModel(long grupo);

        MedicionViewModel ObtenerMedicionViewModel(int idIndicador, int mes, int? idMedicion, long grupo);

        void GuardarMedicion(MedicionViewModel medicionViewModel);
    }
}