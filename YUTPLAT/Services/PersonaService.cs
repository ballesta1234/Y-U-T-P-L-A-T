using System.Collections.Generic;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using YUTPLAT.Models;

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

        public async Task<IList<RolViewModel>> TodosRoles()
        {
            return AutoMapper.Mapper.Map<IList<RolViewModel>>(await PersonaRepository.TodosRoles().ToListAsync());
        }

        public async Task<PersonaViewModel> GetByUserName(string userName)
        {
            return AutoMapper.Mapper.Map<PersonaViewModel>(await PersonaRepository.GetByUserName(userName).FirstAsync());
        }

        public async Task<IList<PersonaViewModel>> Todas()
        {
            return AutoMapper.Mapper.Map<IList<PersonaViewModel>>(await PersonaRepository.Todas().ToListAsync());            
        }

        public async Task<IList<PersonaViewModel>> Buscar(PersonaViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<PersonaViewModel>>(await PersonaRepository.Buscar(filtro).ToListAsync());           
        }

        public async Task<string> Guardar(PersonaViewModel personaViewModel)
        {
            Persona persona = AutoMapper.Mapper.Map<Persona>(personaViewModel);
            return await PersonaRepository.Guardar(persona, personaViewModel.Contrasenia);
        }

        public async Task<bool> ExisteUsuario(string nombreUsuario)
        {
            return await PersonaRepository.ExisteUsuario(nombreUsuario);
        }

    }
}