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

        public enum Mes
        {
            Enero = 1,
            Febrero = 2,
            Marzo = 3,
            Abril = 4,
            Mayo = 5,
            Junio = 6,
            Julio = 7,
            Agosto = 8,
            Septiembre = 9,
            Octubre = 10,
            Noviembre = 11,
            Diciembre = 12,
        }
    }
}