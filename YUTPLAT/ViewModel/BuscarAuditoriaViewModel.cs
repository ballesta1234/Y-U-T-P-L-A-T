using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class BuscarAuditoriaViewModel
    {
        public AuditoriaViewModel Busqueda { get; set; }
        public IList<AuditoriaViewModel> Resultados { get; set; }
        
        public BuscarAuditoriaViewModel()
        {
            Busqueda = new AuditoriaViewModel();
        }
    }
}

