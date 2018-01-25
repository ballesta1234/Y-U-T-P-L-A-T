
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.Models
{
    public class ArchivoSQL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArchivoSQLId { get; set; }

        public string NombreArchivo { get; set; }        
    }
}