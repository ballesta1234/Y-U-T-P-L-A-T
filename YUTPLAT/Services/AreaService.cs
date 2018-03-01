
using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;
using System.Threading.Tasks;
using System.Data.Entity;
    
namespace YUTPLAT.Services.Interface
{
    public class AreaService : IAreaService
    {
        private IAreaRepository AreaRepository { get; set; }

        public AreaService(IAreaRepository areaRepository)
        {
            this.AreaRepository = areaRepository;
        }

        public async Task<AreaViewModel> GetById(int id)
        {
            return AutoMapper.Mapper.Map<AreaViewModel>(await AreaRepository.GetById(id).FirstAsync());
        }

        public async Task<AreaViewModel> GetByIdObjetivo(int idObjetivo)
        {
            return AutoMapper.Mapper.Map<AreaViewModel>(await AreaRepository.GetByIdObjetivo(idObjetivo).FirstAsync());
        }

        public async Task<IList<AreaViewModel>> Todas()
        {
            return AutoMapper.Mapper.Map<IList<AreaViewModel>>(await AreaRepository.Todas().ToListAsync());            
        }

        public async Task<IList<AreaViewModel>> Buscar(BuscarAreaViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<AreaViewModel>>(await AreaRepository.Buscar(filtro.Busqueda).ToListAsync());           
        }

        public async Task<int> Guardar(AreaViewModel areaViewModel)
        {
            Area area = AutoMapper.Mapper.Map<Area>(areaViewModel);

            await AreaRepository.Guardar(area);

            return area.Id;
        }
    }
}