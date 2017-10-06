using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using YUTPLAT.Context;

namespace YUTPLAT.Repositories
{
    public class FrecuenciaMedicionIndicadorRepository : IFrecuenciaMedicionIndicadorRepository
    {
        YutplatDbContext context;

        public FrecuenciaMedicionIndicadorRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<FrecuenciaMedicionIndicador> GetById(int id)
        {
            return this.context.FrecuenciasMedicionIndicadores.Where(a => a.FrecuenciaMedicionIndicadorID == id);
        }
        
        public IQueryable<FrecuenciaMedicionIndicador> Todas()
        {
            return this.context.FrecuenciasMedicionIndicadores;
        }

        public IQueryable<FrecuenciaMedicionIndicador> Buscar(FrecuenciaMedicionIndicadorViewModel filtro)
        {
            IQueryable<FrecuenciaMedicionIndicador> queryable = this.context.FrecuenciasMedicionIndicadores;

            if (filtro.Descripcion != null && !string.IsNullOrEmpty(filtro.Descripcion.Trim()))
            {
                queryable = queryable.Where(a => a.Descripcion.Contains(filtro.Descripcion.Trim()));
            }
                        
            return queryable;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}