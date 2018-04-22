using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using YUTPLAT.Helpers;
using System.Linq;

namespace YUTPLAT.Models
{
    public class Persona : IdentityUser
    {
        private string rolAdmin = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Admin);
        private string rolUsuario = EnumHelper<Enums.Enum.Rol>.GetDisplayValue(Enums.Enum.Rol.Usuario);

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }

        public int? AreaID { get; set; }
        public virtual Area Area { get; set; }

        public virtual ICollection<AccesoIndicador> AccesosIndicadores { get; set; }

        public Persona() : base()
        {                        
            this.AccesosIndicadores = new HashSet<AccesoIndicador>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Persona> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public bool EsAdmin()
        {
            return Rol.Equals(rolAdmin);
        }

        public bool EsUsuario()
        {
            return Rol.Equals(rolUsuario);
        }

        public bool TieneAccesoLectura(int idIndicador)
        {
            return EsAdmin() || TieneAccesoLecturaEscritura(idIndicador) || AccesosIndicadores.Any(ai => ai.IndicadorID == idIndicador && 
                                                                                                   ai.PermisoIndicador == Enums.Enum.PermisoIndicador.SoloLectura);
        }

        public bool TieneAccesoLecturaEscritura(int idIndicador)
        {
            return EsAdmin() || AccesosIndicadores.Any(ai => ai.IndicadorID == idIndicador &&
                                                             ai.PermisoIndicador == Enums.Enum.PermisoIndicador.LecturaEscritura);
        }
    }
}