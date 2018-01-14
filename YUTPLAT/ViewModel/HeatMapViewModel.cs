using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class HeatMapViewModel
    {
        public IList<string> Meses { get; set; }
        public IList<FilaHeatMapViewModel> FilasHeatMapViewModel { get; set; }        
        public IList<CeldaHeatMapViewModel> Celdas { get; set; }       
    }
}

