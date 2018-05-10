using System.ComponentModel.DataAnnotations;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.Validadores
{
    public class ValidarEnumRol : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            Rol rol = (Rol)value;

            if (rol != Rol.Indefinido)
            {
                return null;
            }
            else
            {
                return new ValidationResult("El campo " + validationContext.DisplayName + " es obligatorio.");
            }
        }
    }
}