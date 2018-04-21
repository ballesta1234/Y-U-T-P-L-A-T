using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YUTPLAT.Validadores;

namespace YUTPLAT.ViewModel
{
    public class IndicadorViewModel
    {
        public IndicadorViewModel()
        {
            this.ObjetivoViewModel = new ObjetivoViewModel();
            this.FrecuenciaMedicionIndicadorViewModel = new FrecuenciaMedicionIndicadorViewModel();
            this.Interesados = new List<PersonaViewModel>();
            this.Responsables = new List<PersonaViewModel>();
        }

        public bool TieneAccesoLectura { get; set; }

        public bool TieneAccesoLecturaEscritura { get; set; }

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
        [ValidarLista]
        public int CantidadResponsablesElegidos { get; set; }

        [Display(Name = "Responsables")]
        public string ResponsableID { get; set; }
                
        public IList<PersonaViewModel> Interesados { get; set; }

        public long Grupo { get; set; }

        [Display(Name = "Interesados")]
        [ValidarLista]
        public int CantidadInteresadosElegidos { get; set; }

        [Display(Name = "Interesados")]
        public string InteresadoID { get; set; }

        [StringLength(2000)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha creación")]
        public string FechaCreacion { get; set; }

        [Display(Name = "Fecha validez")]
        public string FechaValidez { get; set; }

        [Display(Name = "Último usuario modificó")]
        public string UltimoUsuarioModifico { get; set; }

        [Display(Name = "Fecha modificación")]
        public string FechaUltimaModificacion { get; set; }
                
        [ValidarMeta(ValidarValor1 = false, ValidarValor2 = false)]
        [Display(Name = "Meta inaceptable")]
        public MetaViewModel MetaInaceptableViewModel { get; set; }

        [ValidarMeta]
        [Display(Name = "Meta a mejorar")]
        public MetaViewModel MetaAMejorarViewModel { get; set; }

        [ValidarMeta]
        [Display(Name = "Meta aceptable")]
        public MetaViewModel MetaAceptableViewModel { get; set; }

        [ValidarMeta]
        [Display(Name = "Meta satisfactoria")]
        public MetaViewModel MetaSatisfactoriaViewModel { get; set; }

        [ValidarMeta(ValidarValor1 = false, ValidarValor2 = false)]
        [Display(Name = "Meta excelente")]
        public MetaViewModel MetaExcelenteViewModel { get; set; }
    }
}

