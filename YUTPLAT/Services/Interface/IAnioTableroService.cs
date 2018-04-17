using System.Collections.Generic;
using System.Threading.Tasks;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IAnioTableroService
    {
        Task<AnioTableroViewModel> GetById(int id);        
        Task<IList<AnioTableroViewModel>> Buscar(AnioTableroViewModel filtro);
        Task<IList<AnioTableroViewModel>> TodosHabilitados();
    }
}