
using System.Collections.Generic;
using System.Threading.Tasks;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IFrecuenciaMedicionIndicadorService
    {
        Task<FrecuenciaMedicionIndicadorViewModel> GetById(int id);
        
        Task<IList<FrecuenciaMedicionIndicadorViewModel>> Buscar(FrecuenciaMedicionIndicadorViewModel filtro);
    }
}