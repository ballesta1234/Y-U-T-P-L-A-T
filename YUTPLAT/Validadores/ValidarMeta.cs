using System.ComponentModel.DataAnnotations;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Validadores
{
    public class ValidarMeta : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            MetaViewModel metaViewModel = (MetaViewModel)value;

            if (metaViewModel != null && 
                metaViewModel.Signo1 > 0 && 
                metaViewModel.Signo2 > 0 &&
                !string.IsNullOrEmpty(metaViewModel.Valor1) &&
                !string.IsNullOrEmpty(metaViewModel.Valor2))
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