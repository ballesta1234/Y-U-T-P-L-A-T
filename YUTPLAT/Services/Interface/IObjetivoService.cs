using System.Collections.Generic;
using System.Threading.Tasks;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IObjetivoService
    {
        Task<ObjetivoViewModel> GetById(int id);        

        Task<IList<ObjetivoViewModel>> Buscar(BuscarObjetivoViewModel filtro);

        Task<int> Guardar(ObjetivoViewModel areaViewModel);
    }
}