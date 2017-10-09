using System.ComponentModel.DataAnnotations;

namespace YUTPLAT.Validadores
{
    public class ValidarLista : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            int lista = (int)value;

            if (lista > 0)
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