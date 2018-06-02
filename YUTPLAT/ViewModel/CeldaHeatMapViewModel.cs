namespace YUTPLAT.ViewModel
{
    public class CeldaHeatMapViewModel
    {
        public int IndiceIndicador { get; set; }
        public int IdIndicador { get; set; }
        public string NombreMes { get; set; }
        public string NombreIndicador { get; set; }
        public long GrupoIndicador { get; set; }
        public int? IdMedicion { get; set; }
        public bool TieneAccesoLecturaEscritura {get; set;}
        public bool EsAutomatico { get; set; }
        public int Mes { get; set; }
        public string Medicion { get; set; }
        public string ColorMeta { get; set; } 
        public bool MedicionCargada { get; set; }
        public bool NoAplica { get; set; }

        public CeldaHeatMapViewModel()
        {
            this.Medicion = "0";
            this.ColorMeta = "#E6E6E6";
        }
    }
}

