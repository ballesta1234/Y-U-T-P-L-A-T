using System.Collections.Generic;
using System.Threading.Tasks;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IIndicadorService
    {
        Task<IndicadorViewModel> GetById(int id);

        Task<IndicadorViewModel> GetUltimoByGrupo(long grupo, PersonaViewModel personaViewModel);

        Task<IList<IndicadorViewModel>> Buscar(BuscarIndicadorViewModel filtro);

        Task<int> Guardar(IndicadorViewModel indicadorViewModel);        
    }
}