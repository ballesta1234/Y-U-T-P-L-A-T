using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class GaugeViewModel
    {        
        public string NombreIndicador { get; set; }
        public string NombreMes { get; set; }    
        public string Valor { get; set; }
        public decimal[] Escala { get; set; }
        public string[] Colores { get; set; }
    }
}

