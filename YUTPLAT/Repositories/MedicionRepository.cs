using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;
using YUTPLAT.Context;
using YUTPLAT.Repositories.Interface;

namespace YUTPLAT.Repositories
{
    public class MedicionRepository : IMedicionRepository
    {
        YutplatDbContext context;

        public MedicionRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Medicion> GetById(string id)
        {
            return this.context.Mediciones.Where(m => m.MedicionId.Equals(id));
        }
         
        public IQueryable<Medicion> Todas()
        {
            return this.context.Mediciones;
        }

        public IQueryable<Medicion> Buscar(MedicionViewModel filtro)
        {
            IQueryable<Medicion> queryable = this.context.Mediciones;
                        
            if (filtro.Grupo > 0)
            {
                queryable = queryable.Where(a => a.Indicador.Grupo == filtro.Grupo);
            }

            if (filtro.IndicadorID > 0)
            {
                queryable = queryable.Where(m => m.IndicadorID == filtro.IndicadorID);
            }

            return queryable;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}