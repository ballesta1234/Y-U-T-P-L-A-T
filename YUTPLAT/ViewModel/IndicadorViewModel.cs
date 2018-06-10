using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using YUTPLAT.Validadores;

namespace YUTPLAT.ViewModel
{
    [ValidarIndicador]
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

        [AllowHtml]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(150)]
        [AllowHtml]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Objetivo")]
        [AllowHtml]
        public string ObjetivoID { get; set; }

        [Display(Name = "Área")]
        [AllowHtml]
        public string AreaID { get; set; }

        [Required]
        [Display(Name = "Frecuencia de medición")]
        [AllowHtml]
        public string FrecuenciaMedicionIndicadorID { get; set; }

        public FrecuenciaMedicionIndicadorViewModel FrecuenciaMedicionIndicadorViewModel { get; set; }

        public ObjetivoViewModel ObjetivoViewModel { get; set; }
                
        public IList<PersonaViewModel> Responsables { get; set; }

        [Display(Name = "Responsables")]
        [ValidarLista]
        public int CantidadResponsablesElegidos { get; set; }

        [Display(Name = "Responsables")]
        [AllowHtml]
        public string ResponsableID { get; set; }
                
        public IList<PersonaViewModel> Interesados { get; set; }

        public long Grupo { get; set; }

        [Display(Name = "Interesados")]
        [ValidarLista]
        public int CantidadInteresadosElegidos { get; set; }

        [Display(Name = "Interesados")]
        [AllowHtml]
        public string InteresadoID { get; set; }

        [StringLength(2000)]
        [Display(Name = "Descripción")]
        [AllowHtml]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha creación")]
        [AllowHtml]
        public string FechaCreacion { get; set; }

        [Display(Name = "Fecha inicio validez")]
        [Required]
        [AllowHtml]
        public string FechaInicioValidez { get; set; }

        [Display(Name = "Fecha fin validez")]
        [AllowHtml]
        public string FechaFinValidez { get; set; }
        
        [Display(Name = "Último usuario modificó")]
        [AllowHtml]
        public string UltimoUsuarioModifico { get; set; }

        [Display(Name = "Fecha modificación")]
        [AllowHtml]
        public string FechaUltimaModificacion { get; set; }
                
        [ValidarMeta(ValidarValor1 = false, ValidarValor2 = false)]
        [Display(Name = "Inaceptable")]
        public MetaViewModel MetaInaceptableViewModel { get; set; }

        [ValidarMeta]
        [Display(Name = "A mejorar")]
        public MetaViewModel MetaAMejorarViewModel { get; set; }

        [ValidarMeta]
        [Display(Name = "Aceptable")]
        public MetaViewModel MetaAceptableViewModel { get; set; }

        [ValidarMeta]
        [Display(Name = "Satisfactoria")]
        public MetaViewModel MetaSatisfactoriaViewModel { get; set; }

        [ValidarMeta(ValidarValor1 = false, ValidarValor2 = false)]
        [Display(Name = "Excelente")]
        public MetaViewModel MetaExcelenteViewModel { get; set; }

        public PersonaViewModel PersonaLogueadaViewModel { get; set; }
    }
}

