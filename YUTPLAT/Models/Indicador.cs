
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YUTPLAT.Models
{
    public class Indicador
    {
        public Indicador()
        {
            this.Responsables = new HashSet<ResponsableIndicador>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndicadorID { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UltimoUsuarioModifico { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

        public virtual ICollection<ResponsableIndicador> Responsables { get; set; }
    }
}