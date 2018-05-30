using System.Collections.Generic;
using System.Threading.Tasks;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IAuditoriaService
    {
        Task<IList<AuditoriaViewModel>> Buscar(BuscarAuditoriaViewModel filtro);

        Task<int> Guardar(AuditoriaViewModel auditoriaViewModel);
    }
}