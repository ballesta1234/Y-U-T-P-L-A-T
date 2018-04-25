using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class BuscarObjetivoViewModel
    {
        public BuscarObjetivoViewModel()
        {
            Busqueda = new ObjetivoViewModel();
        }

        public ObjetivoViewModel Busqueda { get; set; }

        public PersonaViewModel PersonaLogueadaViewModel { get; set; }

        public IList<ObjetivoViewModel> Resultados { get; set; }
        
    }
}

