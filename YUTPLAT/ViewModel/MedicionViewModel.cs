﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.ViewModel
{
    public class MedicionViewModel
    {
        public int MedicionId { get; set; }

        public IndicadorViewModel IndicadorViewModel { get; set; }
        public int IndicadorID { get; set; }
        public long Grupo { get; set; }        
        public Mes Mes { get; set; }
        public int Anio { get; set; }

        [Required]
        [RegularExpression("^[-]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?(\\.[0-9]?[0-9]?[0-9]?)?$", ErrorMessage = "El valor tiene que tener hasta 12 dígitos y hasta 3 decimales")]
        [Display(Name = "Valor")]
        public string Valor { get; set; }

        public string FechaCarga { get; set; }
        public string UsuarioCargo { get; set; }

        public bool? SeDebeNotificar { get; set; }

        [StringLength(2000)]
        [Display(Name = "Comentario")]
        [AllowHtml]
        public string Comentario { get; set; }

        [Display(Name = "No aplica")]
        public bool NoAplica { get; set; }

        public bool BuscarPorNoAplica { get; set; }

        public bool EsIndicadorAutomatico { get; set; }
    }
}

