using System.ComponentModel.DataAnnotations;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.ViewModel
{
    public class MetaViewModel
    {
        public int MetaId { get; set; }

        [RegularExpression("^[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?(\\.[0-9][0-9]?)?$", ErrorMessage = "El valor tiene que tener hasta 12 dígitos y hasta 2 decimales")]
        public string Valor1 { get; set; }

        [RegularExpression("[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?(\\.[0-9][0-9]?)?$", ErrorMessage = "El valor tiene que tener hasta 12 dígitos y hasta 2 decimales")]
        public string Valor2 { get; set; }

        public Signo Signo1 { get; set; }
        public Signo Signo2 { get; set; }
    }
}

