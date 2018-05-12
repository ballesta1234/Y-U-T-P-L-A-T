using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;
using YUTPLAT.Context;
using YUTPLAT.Repositories.Interface;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace YUTPLAT.Repositories
{
    public class MedicionRepository : IMedicionRepository
    {
        YutplatDbContext context;

        public MedicionRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Guardar(Medicion medicion)
        {
            this.context.Mediciones.AddOrUpdate(medicion);
            await this.context.SaveChangesAsync();
            return medicion.MedicionId;
        }

        public int GuardarNoTask(Medicion medicion)
        {
            this.context.Mediciones.AddOrUpdate(medicion);
            this.context.SaveChanges();
            return medicion.MedicionId;
        }

        public IQueryable<Medicion> GetById(int id)
        {
            return this.context.Mediciones.Where(m => m.MedicionId == id);
        }
         
        public IQueryable<Medicion> Todas(int anio)
        {
            return this.context.Mediciones.Where( m => m.Anio == anio);
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
            if (filtro.Mes > 0)
            {
                queryable = queryable.Where(m => m.Mes == filtro.Mes);
            }
            if (filtro.Anio > 0)
            {
                queryable = queryable.Where(m => m.Anio == filtro.Anio);
            }
            if(filtro.SeDebeNotificar != null)
            {
                queryable = queryable.Where(m => m.SeDebeNotificar == filtro.SeDebeNotificar.Value);
            }

            return queryable;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}