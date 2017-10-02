using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class BuscarObjetivoViewModel
    {
        public ObjetivoViewModel Busqueda { get; set; }

        public IList<ObjetivoViewModel> Resultados { get; set; }

        public BuscarObjetivoViewModel()
        {
            Busqueda = new ObjetivoViewModel();
        }
    }
}

