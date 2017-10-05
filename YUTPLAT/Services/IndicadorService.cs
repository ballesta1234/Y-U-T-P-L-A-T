
using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public class IndicadorService : IIndicadorService
    {
        private IIndicadorRepository IndicadorRepository { get; set; }

        public IndicadorService(IIndicadorRepository indicadorRepository)
        {
            this.IndicadorRepository = indicadorRepository;
        }

        public IndicadorViewModel GetById(int id)
        {
            return AutoMapper.Mapper.Map<IndicadorViewModel>(IndicadorRepository.GetById(id).First());
        }

        public IList<IndicadorViewModel> Todas()
        {
            return AutoMapper.Mapper.Map<IList<IndicadorViewModel>>(IndicadorRepository.Todas().ToList());            
        }

        public IList<IndicadorViewModel> Buscar(BuscarIndicadorViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<IndicadorViewModel>>(IndicadorRepository.Buscar(filtro.Busqueda).ToList());           
        }

        public int Guardar(IndicadorViewModel indicadorViewModel)
        {
            Indicador indicador = AutoMapper.Mapper.Map<Indicador>(indicadorViewModel);

            IndicadorRepository.Guardar(indicador);

            return indicador.IndicadorID;
        }
    }
}