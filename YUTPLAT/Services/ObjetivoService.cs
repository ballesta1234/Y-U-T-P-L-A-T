using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;
using System.Data.Entity;
using System.Threading.Tasks;

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

        public async Task<ObjetivoViewModel> GetById(int id)
        {
            return ToObjetivoViewModel(await ObjetivoRepository.GetById(id).FirstAsync());
        }
        
        public async Task<IList<ObjetivoViewModel>> Buscar(BuscarObjetivoViewModel filtro)
        {
            IList<Objetivo> objetivos = await ObjetivoRepository.Buscar(filtro.Busqueda).ToListAsync();

            IList<ObjetivoViewModel> dtos = new List<ObjetivoViewModel>();

            foreach (Objetivo objetivo in objetivos)
            {
                dtos.Add(ToObjetivoViewModel(objetivo));
            }

            return dtos;
        }

        public async Task<int> Guardar(ObjetivoViewModel objetivoViewModel)
        {
            Objetivo objetivo = AutoMapper.Mapper.Map<Objetivo>(objetivoViewModel);

            await ObjetivoRepository.Guardar(objetivo);

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