using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using YUTPLAT.Context;
using YUTPLAT.Helpers;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace YUTPLAT.Repositories
{
    public class AnioTableroRepository : IAnioTableroRepository
    {
        YutplatDbContext context;

        public AnioTableroRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<AnioTablero> GetActual()
        {
            int anioActual = DateTimeHelper.OntenerFechaActual().Year;
            return this.context.AniosTablero.Where(a => a.Anio == anioActual);             
        }

        public IQueryable<AnioTablero> GetById(int id)
        {
            return this.context.AniosTablero.Where(a => a.AnioTableroID == id);
        }
        
        public IQueryable<AnioTablero> TodosHabilitados()
        {
            return this.context.AniosTablero.Where(a => a.Habilitado);
        }

        public IQueryable<AnioTablero> Buscar(AnioTableroViewModel filtro)
        {
            IQueryable<AnioTablero> queryable = this.context.AniosTablero;

            if (filtro.Descripcion != null && !string.IsNullOrEmpty(filtro.Descripcion.Trim()))
            {
                queryable = queryable.Where(a => a.Descripcion.Contains(filtro.Descripcion.Trim()));
            }

            queryable = queryable.Where(a => a.Habilitado == filtro.Habilitado);

            return queryable;
        }

        public async Task<int> HabilitarAnio(int anio)
       {
            AnioTablero anioSiguiente = this.context.AniosTablero.Where(a => a.Anio == anio).FirstOrDefault();
            anioSiguiente.Habilitado = true;

            this.context.AniosTablero.AddOrUpdate(anioSiguiente);
            await this.context.SaveChangesAsync();
            return anioSiguiente.AnioTableroID;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}