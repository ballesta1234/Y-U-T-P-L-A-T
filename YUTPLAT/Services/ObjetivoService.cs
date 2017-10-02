
using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;
using System;

namespace YUTPLAT.Services.Interface
{
    public class ObjetivoService : IObjetivoService
    {
        private IObjetivoRepository ObjetivoRepository { get; set; }
        private IAreaRepository AreaRepository { get; set; }

        public ObjetivoService(IObjetivoRepository objetivoRepository, IAreaRepository areaRepository)
        {
            this.ObjetivoRepository = objetivoRepository;
            this.AreaRepository = areaRepository;
        }

        public ObjetivoViewModel GetById(int id)
        {
            return AutoMapper.Mapper.Map<ObjetivoViewModel>(ObjetivoRepository.GetById(id).First());
        }

        public IList<ObjetivoViewModel> Todas()
        {
            return AutoMapper.Mapper.Map<IList<ObjetivoViewModel>>(ObjetivoRepository.Todas().ToList());            
        }

        public IList<ObjetivoViewModel> Buscar(BuscarObjetivoViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<ObjetivoViewModel>>(ObjetivoRepository.Buscar(filtro.Busqueda).ToList());           
        }

        public int Guardar(ObjetivoViewModel objetivoViewModel)
        {
            Objetivo objetivo = AutoMapper.Mapper.Map<Objetivo>(objetivoViewModel);
            
            ObjetivoRepository.Guardar(objetivo);

            return objetivo.Id;
        }
    }
}