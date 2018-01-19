
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
            this.Interesados = new HashSet<InteresadoIndicador>();

            this.Grupo = 1; 
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndicadorID { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UltimoUsuarioModifico { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
        public long Grupo { get; set; }
        public int ObjetivoID { get; set; }
        public virtual Objetivo Objetivo { get; set; }

        public int FrecuenciaMedicionIndicadorID { get; set; }
        public virtual FrecuenciaMedicionIndicador FrecuenciaMedicion { get; set; }

        public int? MetaInaceptableMetaID { get; set; }
        public virtual Meta MetaInaceptable { get; set; }

        public int? MetaAMejorarMetaID { get; set; }
        public virtual Meta MetaAMejorar { get; set; }

        public int? MetaAceptableMetaID { get; set; }
        public virtual Meta MetaAceptable { get; set; }

        public int? MetaSatisfactoriaMetaID { get; set; }
        public virtual Meta MetaSatisfactoria { get; set; }

        public int? MetaExcelenteMetaID { get; set; }
        public virtual Meta MetaExcelente { get; set; }

        public virtual ICollection<ResponsableIndicador> Responsables { get; set; }
        public virtual ICollection<InteresadoIndicador> Interesados { get; set; }
    }
}