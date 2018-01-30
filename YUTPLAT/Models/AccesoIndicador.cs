using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.Models
{
    public class AccesoIndicador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccesoIndicadorID { get; set; }

        public int IndicadorID { get; set; }
        public virtual Indicador Indicador { get; set; }

        public string PersonaID { get; set; }
        public virtual Persona Persona { get; set; }

        public PermisoIndicador PermisoIndicador { get; set; }
    }
}