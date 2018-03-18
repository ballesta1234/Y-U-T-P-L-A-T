using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.Models
{
    public class IndicadorAutomatico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public virtual Indicador Indicador { get; set; }
        public int IndicadorID { get; set; }
        public CategoriaIndicadorAutomatico CategoriaIndicadorAutomatico { get; set; }
    }
}