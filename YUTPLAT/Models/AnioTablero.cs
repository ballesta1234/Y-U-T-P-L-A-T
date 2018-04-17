using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YUTPLAT.Models
{
    public class AnioTablero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnioTableroID { get; set; }
        
        public string Descripcion { get; set; }
        public int Anio { get; set; }
        public bool Habilitado { get; set; }
    }
}