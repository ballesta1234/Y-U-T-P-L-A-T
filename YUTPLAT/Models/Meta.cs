using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YUTPLAT.Models
{
    public class Meta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MetaId { get; set; }

        public decimal Valor1 { get; set; }
        public decimal Valor2 { get; set; }
        public Signo Signo1 { get; set; }
        public Signo Signo2 { get; set; }
        
        public enum Signo
        {
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