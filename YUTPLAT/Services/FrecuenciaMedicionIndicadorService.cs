using System.Collections.Generic;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;
using System.Threading.Tasks;
using System.Data.Entity;

namespace YUTPLAT.Services.Interface
{
    public class FrecuenciaMedicionIndicadorService : IFrecuenciaMedicionIndicadorService
    {
        private IFrecuenciaMedicionIndicadorRepository FrecuenciaMedicionIndicadorRepository { get; set; }

        public FrecuenciaMedicionIndicadorService(IFrecuenciaMedicionIndicadorRepository frecuenciaMedicionIndicadorRepository)
        {
            this.FrecuenciaMedicionIndicadorRepository = frecuenciaMedicionIndicadorRepository;
        }

        public async Task<FrecuenciaMedicionIndicadorViewModel> GetById(int id)
        {
            return AutoMapper.Mapper.Map<FrecuenciaMedicionIndicadorViewModel>(await FrecuenciaMedicionIndicadorRepository.GetById(id).FirstAsync());
        }
        
        public async Task<IList<FrecuenciaMedicionIndicadorViewModel>> Buscar(FrecuenciaMedicionIndicadorViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<FrecuenciaMedicionIndicadorViewModel>>(await FrecuenciaMedicionIndicadorRepository.Buscar(filtro).ToListAsync());           
        }
    }
}