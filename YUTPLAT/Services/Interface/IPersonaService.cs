
using System.Collections.Generic;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IPersonaService
    {
        PersonaViewModel GetById(string id);

        IList<PersonaViewModel> Todas();

        IList<PersonaViewModel> Buscar(PersonaViewModel filtro);        
    }
}