
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YUTPLAT.Models
{
    public class Objetivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UltimoUsuarioModifico { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
        public virtual Area Area { get; set; }

        public int AreaID { get; set; }
    }
}