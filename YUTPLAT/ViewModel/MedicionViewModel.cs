using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.ViewModel
{
    public class MedicionViewModel
    {
        public int MedicionId { get; set; }

        public IndicadorViewModel IndicadorViewModel { get; set; }
        public int IndicadorID { get; set; }

        public Mes Mes { get; set; }
        public string Valor { get; set; }
        public string FechaCarga { get; set; }
        public string UsuarioCargo { get; set; }
    }
}

