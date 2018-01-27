using System.ComponentModel.DataAnnotations;
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

        [Required]
        [RegularExpression("^[-]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?(\\.[0-9]?[0-9]?[0-9]?)?$", ErrorMessage = "El valor tiene que tener hasta 12 dígitos y hasta 3 decimales")]
        [Display(Name = "Valor de la medición")]
        public string Valor { get; set; }

        public string FechaCarga { get; set; }
        public string UsuarioCargo { get; set; }

        [StringLength(2000)]
        [Display(Name = "Comentario")]
        public string Comentario { get; set; }
    }
}

