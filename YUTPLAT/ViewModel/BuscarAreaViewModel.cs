﻿using System.Collections.Generic;

namespace YUTPLAT.ViewModel
{
    public class BuscarAreaViewModel
    {
        public AreaViewModel Busqueda { get; set; }
        public IList<AreaViewModel> Resultados { get; set; }
        public PersonaViewModel PersonaLogueadaViewModel { get; set; }

        public BuscarAreaViewModel()
        {
            Busqueda = new AreaViewModel();
        }
    }
}

