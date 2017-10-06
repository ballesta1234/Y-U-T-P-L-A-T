
using System.Collections.Generic;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public class FrecuenciaMedicionIndicadorService : IFrecuenciaMedicionIndicadorService
    {
        private IFrecuenciaMedicionIndicadorRepository FrecuenciaMedicionIndicadorRepository { get; set; }

        public FrecuenciaMedicionIndicadorService(IFrecuenciaMedicionIndicadorRepository frecuenciaMedicionIndicadorRepository)
        {
            this.FrecuenciaMedicionIndicadorRepository = frecuenciaMedicionIndicadorRepository;
        }

        public FrecuenciaMedicionIndicadorViewModel GetById(int id)
        {
            return AutoMapper.Mapper.Map<FrecuenciaMedicionIndicadorViewModel>(FrecuenciaMedicionIndicadorRepository.GetById(id).First());
        }

        public IList<FrecuenciaMedicionIndicadorViewModel> Todas()
        {
            return AutoMapper.Mapper.Map<IList<FrecuenciaMedicionIndicadorViewModel>>(FrecuenciaMedicionIndicadorRepository.Todas().ToList());            
        }

        public IList<FrecuenciaMedicionIndicadorViewModel> Buscar(FrecuenciaMedicionIndicadorViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<FrecuenciaMedicionIndicadorViewModel>>(FrecuenciaMedicionIndicadorRepository.Buscar(filtro).ToList());           
        }
    }
}