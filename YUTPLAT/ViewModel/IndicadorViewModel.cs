using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YUTPLAT.ViewModel
{
    public class IndicadorViewModel
    {
        public IndicadorViewModel()
        {
            this.ObjetivoViewModel = new ObjetivoViewModel();
            this.Interesados = new List<PersonaViewModel>();
            this.Responsables = new List<PersonaViewModel>();
        }

        public int Id { get; set; }

        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Objetivo")]
        public string ObjetivoID { get; set; }

        [Display(Name = "Área")]
        public string AreaID { get; set; }

        [Required]
        [Display(Name = "Frecuencia de medición")]
        public string FrecuenciaMedicionIndicadorID { get; set; }

        public FrecuenciaMedicionIndicadorViewModel FrecuenciaMedicionIndicadorViewModel { get; set; }

        public ObjetivoViewModel ObjetivoViewModel { get; set; }
        
        public IList<PersonaViewModel> Responsables { get; set; }

        [Display(Name = "Responsables")]
        public string ResponsableID { get; set; }

        public IList<PersonaViewModel> Interesados { get; set; }

        [Display(Name = "Interesados")]
        public string InteresadoID { get; set; }

        [StringLength(2000)]
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

