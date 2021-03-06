﻿using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class BuscarIndicadorViewModel
    {
        public IndicadorViewModel Busqueda { get; set; }
        public bool UltimoDeCadaGrupo { get; set; }
        
        public int AnioTablero { get; set; }
        public PersonaViewModel PersonaLogueadaViewModel { get; set; }
        public bool TodasLasAreas { get; set; }

        public IList<IndicadorViewModel> Resultados { get; set; }

        public BuscarIndicadorViewModel()
        {
            UltimoDeCadaGrupo = true;
            Busqueda = new IndicadorViewModel();
        }
    }
}

