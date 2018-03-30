using System.ComponentModel.DataAnnotations;

namespace YUTPLAT.ViewModel
{
    public class ObjetivoViewModel
    {
        public ObjetivoViewModel()
        {
            this.AreaViewModel = new AreaViewModel();
        }

        public int Id { get; set; }

        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Área")]
        public string IdArea { get; set; }
                
        public AreaViewModel AreaViewModel { get; set; }

        [StringLength(2000)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha creación")]
        public string FechaCreacion { get; set; }

        [Display(Name = "Último usuario modificó")]
        public string UltimoUsuarioModifico { get; set; }

        [Display(Name = "Fecha modificación")]
        public string FechaUltimaModificacion { get; set; }
    }
}

