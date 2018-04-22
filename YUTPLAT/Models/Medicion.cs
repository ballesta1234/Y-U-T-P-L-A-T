
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.Models
{
    public class Medicion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicionId { get; set; }

        public virtual Indicador Indicador { get; set; }
        public int IndicadorID { get; set; }
        public int Anio { get; set; }
        public Mes Mes { get; set; }
        public decimal Valor { get; set; }        
        public DateTime? FechaCarga { get; set; }
        public string UsuarioCargo { get; set; }

        public string Comentario { get; set; }

    }
}