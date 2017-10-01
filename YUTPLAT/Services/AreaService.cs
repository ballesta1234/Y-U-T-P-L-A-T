
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

        public IList<AreaViewModel> Todas()
        {
            return AutoMapper.Mapper.Map<IList<AreaViewModel>>(AreaRepository.Todas().ToList());            
        }

        public IList<AreaViewModel> Buscar(BuscarAreaViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<AreaViewModel>>(AreaRepository.Buscar(filtro.Busqueda).ToList());           
        }
    }
}