using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Threading.Tasks;
using System.Data.Entity;

namespace YUTPLAT.Services.Interface
{
    public class AuditoriaService : IAuditoriaService
    {
        private IAuditoriaRepository AuditoriaRepository { get; set; }

        public AuditoriaService(IAuditoriaRepository auditoriaRepository)
        {
            this.AuditoriaRepository = auditoriaRepository;
        }
        
        public async Task<IList<AuditoriaViewModel>> Buscar(BuscarAuditoriaViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<AuditoriaViewModel>>(await AuditoriaRepository.Buscar(filtro.Busqueda).ToListAsync());           
        }       

        public async Task<int> Guardar(AuditoriaViewModel auditoriaViewModel)
        {
            Auditoria auditoria = AutoMapper.Mapper.Map<Auditoria>(auditoriaViewModel);
            auditoria.Usuario = null;
            await AuditoriaRepository.Guardar(auditoria);

            return auditoria.Id;
        }
    }
}