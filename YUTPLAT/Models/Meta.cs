using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static YUTPLAT.Enums.Enum;

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
    }
}