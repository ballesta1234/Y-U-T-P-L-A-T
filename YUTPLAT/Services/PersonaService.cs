
using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public class PersonaService : IPersonaService
    {
        private IPersonaRepository PersonaRepository { get; set; }

        public PersonaService(IPersonaRepository personaRepository)
        {
            this.PersonaRepository = personaRepository;
        }

        public PersonaViewModel GetById(string id)
        {
            return AutoMapper.Mapper.Map<PersonaViewModel>(PersonaRepository.GetById(id).First());
        }        

        public IList<PersonaViewModel> Todas()
        {
            return AutoMapper.Mapper.Map<IList<PersonaViewModel>>(PersonaRepository.Todas().ToList());            
        }

        public IList<PersonaViewModel> Buscar(PersonaViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<PersonaViewModel>>(PersonaRepository.Buscar(filtro).ToList());           
        }        
    }
}