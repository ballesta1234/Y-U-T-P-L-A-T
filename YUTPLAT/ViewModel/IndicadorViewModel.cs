﻿using System.ComponentModel.DataAnnotations;

namespace YUTPLAT.ViewModel
{
    public class IndicadorViewModel
    {
        public IndicadorViewModel()
        {
            this.ObjetivoViewModel = new ObjetivoViewModel();
        }

        public int Id { get; set; }

        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Objetivo")]
        public string IdObjetivo { get; set; }

        [Required]
        [Display(Name = "Frecuencia de medición")]
        public string IdFrecuenciaMedicionIndicador { get; set; }

        public ObjetivoViewModel ObjetivoViewModel { get; set; }

        [StringLength(2000)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha creación")]
        public string FechaCreacion { get; set; }

        [Display(Name = "Último usuario modificó")]
        public string UltimoUsuarioModifico { get; set; }

        [Display(Name = "Fecha última modificación")]
        public string FechaUltimaModificacion { get; set; }
    }
}

