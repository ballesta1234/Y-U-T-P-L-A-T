using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace YUTPLAT.Models
{
    public class Persona : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Persona> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}