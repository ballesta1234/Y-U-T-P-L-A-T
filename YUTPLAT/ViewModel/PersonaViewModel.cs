using System;
using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class PersonaViewModel
    {
        public string Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreOApellidoONombreUsuario { get; set; }
        public bool EsAdmin { get; set; }
        public bool EsUsuario { get; set; }
        public AreaViewModel AreaViewModel { get; set; }

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
            get { return EsAdmin || EsUsuario; }
        }
    }
            
    // Custom comparer for the Product class
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

