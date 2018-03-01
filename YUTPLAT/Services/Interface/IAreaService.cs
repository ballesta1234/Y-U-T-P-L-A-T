
using System.Collections.Generic;
using System.Threading.Tasks;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IAreaService
    {
        Task<AreaViewModel> GetById(int id);

        Task<AreaViewModel> GetByIdObjetivo(int idObjetivo);

        Task<IList<AreaViewModel>> Todas();

        Task<IList<AreaViewModel>> Buscar(BuscarAreaViewModel filtro);

        Task<int> Guardar(AreaViewModel areaViewModel);
    }
}