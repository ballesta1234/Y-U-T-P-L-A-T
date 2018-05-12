using System.ComponentModel.DataAnnotations;
using static YUTPLAT.Enums.Enum;

namespace YUTPLAT.Validadores
{
    public class ValidarEnumRol : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            Rol rol = YUTPLAT.Helpers.EnumHelper<Enums.Enum.Rol>.Parse(value.ToString());
            
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