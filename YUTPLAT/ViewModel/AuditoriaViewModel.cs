using System;

namespace YUTPLAT.ViewModel
{
    public class AuditoriaViewModel
    {
        public int Id { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Descripcion { get; set; }
        public Enums.Enum.TipoAuditoria? TipoAuditoria { get; set; }
        public PersonaViewModel UsuarioViewModel { get; set; }
    }
}

