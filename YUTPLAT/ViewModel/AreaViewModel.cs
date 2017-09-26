using System.ComponentModel.DataAnnotations;

namespace YUTPLAT.ViewModel
{
    public class AreaViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha creación")]
        public string FechaCreacion { get; set; }

        [Display(Name = "Último usuario modificó")]
        public string UltimoUsuarioModifico { get; set; }

        [Display(Name = "Fecha última modificación")]
        public string FechaUltimaModificacion { get; set; }
    }
}

