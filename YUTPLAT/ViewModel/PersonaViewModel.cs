using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YUTPLAT.Validadores;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.ViewModel
{
    public class PersonaViewModel
    {
        public PersonaViewModel()
        {
            Habilitado = true;
        }

        public string Id { get; set; }
        public string Titulo { get; set; }
        
        [Required]
        [Display(Name = "Nombre de usuario")]
        [StringLength(15)]
        [System.Web.Mvc.Remote("ValidarNombreUsuario", "Persona", AdditionalFields = "NombreUsuarioOriginal")]
        [System.Web.Mvc.AllowHtml]
        public string NombreUsuario { get; set; }

        [System.Web.Mvc.AllowHtml]
        public string NombreUsuarioOriginal { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(100)]
        [System.Web.Mvc.AllowHtml]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        [StringLength(100)]
        [System.Web.Mvc.AllowHtml]
        public string Apellido { get; set; }
        
        [Required]
        [Display(Name = "Contraseña")]
        [StringLength(15, MinimumLength = 6)]
        public string Contrasenia { get; set; }
        
        [Required]
        [Display(Name = "Confirmar contraseña")]        
        [Compare("Contrasenia", ErrorMessage = "La confirmación de la contraseña no coincide.")]
        public string ConfirmarContrasenia { get; set; }

        [Required]
        [Display(Name = "Área")]
        public string IdArea { get; set; }

        public string NombreOApellidoONombreUsuario { get; set; }
        public bool EsAdmin { get; set; }
        public bool? EsUsuario { get; set; }
        public AreaViewModel AreaViewModel { get; set; }
        
        [Display(Name = "Rol")]
        [Required]
        [ValidarEnumRol]
        [System.Web.Mvc.AllowHtml]
        public string NombreRol { get; set; }

        [Display(Name = "Estado")]
        public bool Habilitado { get; set; }

        public string NombreApellido
        {
            get
            {
                string nombreApellido = "";

                if (!String.IsNullOrEmpty(this.Nombre))
                    nombreApellido += this.Nombre;

                if (!String.IsNullOrEmpty(this.Apellido))
                    nombreApellido += " " + this.Apellido;

                return nombreApellido;
            }
        }

        public bool EsJefeArea
        {
            get { return EsAdmin || (EsUsuario != null && EsUsuario.Value); }
        }

        public PersonaViewModel PersonaLogueadaViewModel { get; set; }
    }
                
    class PersonaViewModelComparer : IEqualityComparer<PersonaViewModel>
    {
        public bool Equals(PersonaViewModel x, PersonaViewModel y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(PersonaViewModel personaViewModel)
        {
            if (Object.ReferenceEquals(personaViewModel, null)) return 0;

            int hashProductId = personaViewModel.Id == null ? 0 : personaViewModel.Id.GetHashCode();

            return hashProductId;
        }

    }
}

