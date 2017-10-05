using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YUTPLAT.Models
{
    public class InteresadoIndicador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InteresadoIndicadorID { get; set; }

        public int IndicadorID { get; set; }
        public virtual Indicador Indicador { get; set; }

        public string PersonaID { get; set; }
        public virtual Persona Persona { get; set; }
    }
}