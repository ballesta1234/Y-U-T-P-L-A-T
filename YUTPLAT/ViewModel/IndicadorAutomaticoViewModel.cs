using System.ComponentModel.DataAnnotations;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.ViewModel
{
    public class IndicadorAutomaticoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public CategoriaIndicadorAutomatico CategoriaIndicadorAutomatico { get; set; }
        public IndicadorViewModel IndicadorViewModel { get; set; }
    }
}

