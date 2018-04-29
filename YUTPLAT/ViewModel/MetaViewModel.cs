using System.ComponentModel.DataAnnotations;
using YUTPLAT.Helpers;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.ViewModel
{
    public class MetaViewModel
    {
        public int MetaId { get; set; }

        [RegularExpression("^[-]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?(\\.[0-9]?[0-9]?[0-9]?)?$", ErrorMessage = "El valor tiene que tener hasta 12 dígitos y hasta 3 decimales")]
        public string Valor1 { get; set; }

        [RegularExpression("^[-]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?(\\.[0-9]?[0-9]?[0-9]?)?$", ErrorMessage = "El valor tiene que tener hasta 12 dígitos y hasta 3 decimales")]
        public string Valor2 { get; set; }

        public Signo Signo1 { get; set; }
        public Signo Signo2 { get; set; }

        public override string ToString()
        {
            string meta = "";
            
            if (!string.IsNullOrEmpty(Valor1))
                meta = Valor1;
            if ((int)Signo1 > 0)
                meta += EnumHelper<Enums.Enum.Signo>.GetDisplayValue(Signo1);

            meta += "meta";

            if ((int)Signo2 >0)
                meta += EnumHelper<Enums.Enum.Signo>.GetDisplayValue(Signo2);
            if (!string.IsNullOrEmpty(Valor2))
                meta += Valor2;           

            return meta;
        }
    }
}

