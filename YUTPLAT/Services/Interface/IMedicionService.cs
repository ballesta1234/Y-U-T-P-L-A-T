using System.Collections.Generic;
using System.Threading.Tasks;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IMedicionService
    {
        Task<MedicionViewModel> GetById(int id);

        Task<IList<MedicionViewModel>> Todas(int anio);

        Task<IList<MedicionViewModel>> Buscar(MedicionViewModel filtro);

        Task<HeatMapViewModel> ObtenerHeatMapViewModel(BuscarIndicadorViewModel buscarIndicadorViewModel);

        Task<GaugeViewModel> ObtenerGaugeViewModel(long grupo, int anio);

        Task<IList<LineViewModel>> ObtenerLineViewModel(long grupo, int anio);

        Task<MedicionViewModel> ObtenerMedicionViewModel(int idIndicador, int mes, int? idMedicion, long grupo, int anio);

        Task<int> GuardarMedicion(MedicionViewModel medicionViewModel);

        bool ValidaMedicion(MedicionViewModel medicionViewModel);  
    }
}