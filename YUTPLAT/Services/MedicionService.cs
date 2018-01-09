
using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public class MedicionService : IMedicionService
    {
        private IMedicionRepository MedicionRepository { get; set; }

        public MedicionService(IMedicionRepository medicionRepository)
        {
            this.MedicionRepository = medicionRepository;
        }

        public MedicionViewModel GetById(string id)
        {
            return AutoMapper.Mapper.Map<MedicionViewModel>(MedicionRepository.GetById(id).First());
        }        

        public IList<MedicionViewModel> Todas()
        {
            return AutoMapper.Mapper.Map<IList<MedicionViewModel>>(MedicionRepository.Todas().ToList());            
        }

        public IList<MedicionViewModel> Buscar(MedicionViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<MedicionViewModel>>(MedicionRepository.Buscar(filtro).ToList());           
        }        
    }
}