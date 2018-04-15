using System.Collections.Generic;
using System.Threading.Tasks;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IPersonaService
    {
        Task<PersonaViewModel> GetById(string id);

        Task<PersonaViewModel> GetByUserName(string userName);
            
        Task<IList<PersonaViewModel>> Todas();

        Task<IList<PersonaViewModel>> Buscar(PersonaViewModel filtro);        
    }
}