using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;
using YUTPLAT.Context;
using YUTPLAT.Repositories.Interface;

namespace YUTPLAT.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        YutplatDbContext context;

        public PersonaRepository(YutplatDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Persona> GetById(string id)
        {
            return this.context.Users.Where(a => a.Id.Equals(id));
        }
         
        public IQueryable<Persona> Todas()
        {
            return this.context.Users;
        }

        public IQueryable<Persona> Buscar(PersonaViewModel filtro)
        {
            IQueryable<Persona> queryable = this.context.Users;

            if (filtro.Nombre != null && !string.IsNullOrEmpty(filtro.Nombre.Trim()))
            {
                queryable = queryable.Where(a => a.Nombre.Contains(filtro.Nombre.Trim()));
            }
            if (filtro.Apellido != null && !string.IsNullOrEmpty(filtro.Apellido.Trim()))
            {
                queryable = queryable.Where(a => a.Apellido.Contains(filtro.Apellido.Trim()));
            }
            if (filtro.NombreUsuario != null && !string.IsNullOrEmpty(filtro.NombreUsuario.Trim()))
            {
                queryable = queryable.Where(a => a.UserName.Contains(filtro.NombreUsuario.Trim()));
            }
            if (filtro.NombreOApellidoONombreUsuario != null && !string.IsNullOrEmpty(filtro.NombreOApellidoONombreUsuario.Trim()))
            {
                queryable = queryable.Where(a => a.UserName.Contains(filtro.NombreOApellidoONombreUsuario.Trim()) ||
                                                 a.Nombre.Contains(filtro.NombreOApellidoONombreUsuario.Trim()) ||
                                                 a.Apellido.Contains(filtro.NombreOApellidoONombreUsuario.Trim()));
            }

            return queryable;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}