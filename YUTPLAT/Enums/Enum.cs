using System.ComponentModel.DataAnnotations;

namespace YUTPLAT.Enums
{
    public static class Enum
    {
        public enum Signo
        {
            [Display(Name = " ")]
            Indefinido = 0,
            [Display(Name = "<")]
            Menor = 1,
            [Display(Name = ">")]
            Mayor = 2,
            [Display(Name = "=")]
            Igual = 3,
            [Display(Name = "<=")]
            MayorOIgual = 4,
            [Display(Name = ">=")]
            MenorOIgual = 5,
        }
    }
}