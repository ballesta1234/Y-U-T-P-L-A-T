using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;
using YUTPLAT.Context;
using YUTPLAT.Repositories.Interface;
using System.Threading.Tasks;
using System.Data.Entity;
using YUTPLAT.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;

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

        public IQueryable<IdentityRole> TodosRoles()
        {
            return this.context.Roles;
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
            if (filtro.NombreRol != null && !string.IsNullOrEmpty(filtro.NombreRol.Trim()))
            {
                queryable = queryable.Where(a => a.Rol.Contains(filtro.NombreRol));
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

        public async Task<bool> ExisteUsuario(string nombreUsuario)
        {
            return await this.context.Users.AnyAsync(u => u.UserName.Equals(nombreUsuario));
        }

        public async Task<string> Guardar(Persona persona, string contrasenia)
        {
            var store = new UserStore<Persona>(context);
            var manager = new UserManager<Persona>(store);

            var user = new Persona {};

            if (!String.IsNullOrEmpty(persona.Id))
            {
                user = await this.context.Users.FirstAsync(u => u.Id.Equals(persona.Id));
                user.UserName = persona.UserName;
                user.Email = persona.Email;
                user.EmailConfirmed = true;
                user.Nombre = persona.Nombre;
                user.Apellido = persona.Apellido;
                user.Rol = persona.Rol;
                user.AreaID = persona.AreaID;
                user.LockoutEnabled = persona.LockoutEnabled;

                var lockoutEndDate = new DateTimeOffset(DateTimeHelper.OntenerFechaActual().AddYears(100));
                await manager.SetLockoutEndDateAsync(user.Id, lockoutEndDate);
                await manager.SetLockoutEnabledAsync(user.Id, user.LockoutEnabled);

                if (!String.IsNullOrEmpty(contrasenia))
                {                    
                    user.PasswordHash = manager.PasswordHasher.HashPassword(contrasenia);                                        
                }
                        
                await manager.UpdateAsync(user);
            }
            else
            {
                user = new Persona
                {
                    UserName = persona.UserName,
                    Email = persona.Email,
                    EmailConfirmed = true,
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    Rol = persona.Rol,
                    AreaID = persona.AreaID,
                    LockoutEnabled = persona.LockoutEnabled               
                };
                              
                await manager.CreateAsync(user, contrasenia);
                await manager.AddToRoleAsync(user.Id, user.Rol);

                var lockoutEndDate = new DateTimeOffset(DateTimeHelper.OntenerFechaActual().AddYears(100));
                await manager.SetLockoutEndDateAsync(user.Id, lockoutEndDate);
                await manager.SetLockoutEnabledAsync(user.Id, user.LockoutEnabled);
            }

            return user.Id;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}