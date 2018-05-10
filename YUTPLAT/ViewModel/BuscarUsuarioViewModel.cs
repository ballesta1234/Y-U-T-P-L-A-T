using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class BuscarUsuarioViewModel
    {
        public PersonaViewModel Busqueda { get; set; }
        public IList<PersonaViewModel> Resultados { get; set; }
        public PersonaViewModel PersonaLogueadaViewModel { get; set; }

        public BuscarUsuarioViewModel()
        {
            Busqueda = new PersonaViewModel();
        }
    }
}

