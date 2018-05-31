using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YUTPLAT.Models
{
    public class Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }
        public Enums.Enum.TipoAuditoria TipoAuditoria { get; set; }
        
        public virtual Persona Usuario { get; set; }
        public string UsuarioID { get; set; }
    }
}