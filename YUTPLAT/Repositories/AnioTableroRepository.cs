using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using YUTPLAT.Context;

namespace YUTPLAT.Repositories
{
    public class AnioTableroRepository : IAnioTableroRepository
    {
        YutplatDbContext context;

        public AnioTableroRepository(YutplatDbContext context)
        {
            this.context = context;
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

        public void Dispose()
        {
            context.Dispose();
        }
    }
}