using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YUTPLAT.Models
{
    public class FrecuenciaMedicionIndicador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FrecuenciaMedicionIndicadorID { get; set; }
        
        public string Descripcion { get; set; }        
    }
}