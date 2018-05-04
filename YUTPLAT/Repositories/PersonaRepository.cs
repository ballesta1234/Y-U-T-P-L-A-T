using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;
using YUTPLAT.Context;
using YUTPLAT.Repositories.Interface;
using System.Threading.Tasks;
using System.Data.Entity;
using YUTPLAT.Helpers;

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

        public IQueryable<Persona> GetByUserName(string userName)
        {
            return this.context.Users.Where(a => a.UserName.Equals(userName));
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
            if (filtro.EsUsuario != null)
            {
                string rolUsuario = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Usuario);
                queryable = queryable.Where(a => a.Rol.Equals(rolUsuario));
            }
            if (filtro.NombreOApellidoONombreUsuario != null && !string.IsNullOrEmpty(filtro.NombreOApellidoONombreUsuario.Trim()))
            {
                queryable = queryable.Where(a => a.UserName.Contains(filtro.NombreOApellidoONombreUsuario.Trim()) ||
                                                 a.Nombre.Contains(filtro.NombreOApellidoONombreUsuario.Trim()) ||
                                                 a.Apellido.Contains(filtro.NombreOApellidoONombreUsuario.Trim()));
            }
            if (filtro.AreaViewModel != null && filtro.AreaViewModel.Id > 0)
            {
                queryable = queryable.Where(a => a.AreaID == filtro.AreaViewModel.Id);
            }

            return queryable;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}