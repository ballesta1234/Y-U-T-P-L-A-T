namespace YUTPLAT.ViewModel
{
    public class CeldaHeatMapViewModel
    {
        public int IndiceIndicador { get; set; }
        public int IdIndicador { get; set; }
        public int Mes { get; set; }
        public string Medicion { get; set; }
        public string ColorMeta { get; set; } 
        public bool MedicionCargada { get; set; }   
        
        public CeldaHeatMapViewModel()
        {
            this.Medicion = "0";
            this.ColorMeta = "#E6E6E6";
        }
    }
}

