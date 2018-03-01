using System.Collections.Generic;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;
using System.Threading.Tasks;
using System.Data.Entity;

namespace YUTPLAT.Services.Interface
{
    public class PersonaService : IPersonaService
    {
        private IPersonaRepository PersonaRepository { get; set; }

        public PersonaService(IPersonaRepository personaRepository)
        {
            this.PersonaRepository = personaRepository;
        }

        public async Task<PersonaViewModel> GetById(string id)
        {
            return AutoMapper.Mapper.Map<PersonaViewModel>(await PersonaRepository.GetById(id).FirstAsync());
        }        

        public async Task<IList<PersonaViewModel>> Todas()
        {
            return AutoMapper.Mapper.Map<IList<PersonaViewModel>>(await PersonaRepository.Todas().ToListAsync());            
        }

        public async Task<IList<PersonaViewModel>> Buscar(PersonaViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<PersonaViewModel>>(await PersonaRepository.Buscar(filtro).ToListAsync());           
        }        
    }
}