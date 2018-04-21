using System;
using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class FilaHeatMapViewModel
    {
        public int IdIndicador { get; set; }
        public long Grupo { get; set; }
        public string NombreIndicador { get; set; }
        public string NombreArea { get; set; }
        public bool TieneAccesoLecturaEscritura { get; set; }
        public bool EsAutomatico { get; set; }
        public DateTime? FechaValidez { get; set; }

    }
}

