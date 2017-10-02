
using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public class AreaService : IAreaService
    {
        private IAreaRepository AreaRepository { get; set; }

        public AreaService(IAreaRepository areaRepository)
        {
            this.AreaRepository = areaRepository;
        }

        public AreaViewModel GetById(int id)
        {
            return AutoMapper.Mapper.Map<AreaViewModel>(AreaRepository.GetById(id).First());
        }

        public IList<AreaViewModel> Todas()
        {
            return AutoMapper.Mapper.Map<IList<AreaViewModel>>(AreaRepository.Todas().ToList());            
        }

        public IList<AreaViewModel> Buscar(BuscarAreaViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<AreaViewModel>>(AreaRepository.Buscar(filtro.Busqueda).ToList());           
        }

        public int Guardar(AreaViewModel areaViewModel)
        {
            Area area = AutoMapper.Mapper.Map<Area>(areaViewModel);

            AreaRepository.Guardar(area);

            return area.Id;
        }
    }
}