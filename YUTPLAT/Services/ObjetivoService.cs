
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
            return ToObjetivoViewModel(ObjetivoRepository.GetById(id).First());
        }

        public IList<ObjetivoViewModel> Todas()
        {
            IList<Objetivo> objetivos = ObjetivoRepository.Todas().ToList();

            IList<ObjetivoViewModel> dtos = new List<ObjetivoViewModel>();

            foreach (Objetivo objetivo in objetivos)
            {
                dtos.Add(ToObjetivoViewModel(objetivo));
            }

            return dtos;
        }

        public IList<ObjetivoViewModel> Buscar(BuscarObjetivoViewModel filtro)
        {
            IList<Objetivo> objetivos = ObjetivoRepository.Buscar(filtro.Busqueda).ToList();

            IList<ObjetivoViewModel> dtos = new List<ObjetivoViewModel>();

            foreach (Objetivo objetivo in objetivos)
            {
                dtos.Add(ToObjetivoViewModel(objetivo));
            }

            return dtos;
        }

        public int Guardar(ObjetivoViewModel objetivoViewModel)
        {
            Objetivo objetivo = AutoMapper.Mapper.Map<Objetivo>(objetivoViewModel);

            ObjetivoRepository.Guardar(objetivo);

            return objetivo.Id;
        }

        public ObjetivoViewModel ToObjetivoViewModel(Objetivo objetivo)
        {
            ObjetivoViewModel objetivoViewModel = AutoMapper.Mapper.Map<ObjetivoViewModel>(objetivo);
            objetivoViewModel.AreaViewModel = AutoMapper.Mapper.Map<AreaViewModel>(objetivo.Area);

            return objetivoViewModel;
        }
    }
}