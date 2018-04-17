using System.Collections.Generic;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Threading.Tasks;
using System.Data.Entity;

namespace YUTPLAT.Services.Interface
{
    public class AnioTableroService : IAnioTableroService
    {
        private IAnioTableroRepository AnioTableroRepository { get; set; }

        public AnioTableroService(IAnioTableroRepository anioTableroRepository)
        {
            this.AnioTableroRepository = anioTableroRepository;
        }

        public async Task<AnioTableroViewModel> GetById(int id)
        {
            return AutoMapper.Mapper.Map<AnioTableroViewModel>(await AnioTableroRepository.GetById(id).FirstAsync());
        }

        public async Task<AnioTableroViewModel> GetActual()
        {
            return AutoMapper.Mapper.Map<AnioTableroViewModel>(await AnioTableroRepository.GetActual().FirstAsync());
        }

        public async Task<IList<AnioTableroViewModel>> TodosHabilitados()
        {
            return AutoMapper.Mapper.Map<IList<AnioTableroViewModel>>(await AnioTableroRepository.TodosHabilitados().ToListAsync());
        }

        public async Task<IList<AnioTableroViewModel>> Buscar(AnioTableroViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<AnioTableroViewModel>>(await AnioTableroRepository.Buscar(filtro).ToListAsync());           
        }
    }
}