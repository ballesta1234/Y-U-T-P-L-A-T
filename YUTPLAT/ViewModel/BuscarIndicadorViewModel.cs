using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class BuscarIndicadorViewModel
    {
        public IndicadorViewModel Busqueda { get; set; }

        public IList<IndicadorViewModel> Resultados { get; set; }

        public BuscarIndicadorViewModel()
        {
            Busqueda = new IndicadorViewModel();
        }
    }
}

