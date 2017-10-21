using System.ComponentModel.DataAnnotations;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Validadores
{
    public class ValidarMeta : ValidationAttribute
    {
        public bool ValidarValor1 { get; set; }
        public bool ValidarValor2 { get; set; }
                
        public ValidarMeta()
        {
            ValidarValor1 = true;
            ValidarValor2 = true;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            MetaViewModel metaViewModel = (MetaViewModel)value;

            if (metaViewModel != null && 
                 (
                    ((metaViewModel.Signo1 > 0 && !string.IsNullOrEmpty(metaViewModel.Valor1)) && (metaViewModel.Signo2 > 0 && !string.IsNullOrEmpty(metaViewModel.Valor2)))
                    ||
                    (!ValidarValor1 && metaViewModel.Signo1 == 0 && string.IsNullOrEmpty(metaViewModel.Valor1) && metaViewModel.Signo2 > 0 && !string.IsNullOrEmpty(metaViewModel.Valor2))
                    ||
                    (!ValidarValor2 && metaViewModel.Signo2 == 0 && string.IsNullOrEmpty(metaViewModel.Valor2) && metaViewModel.Signo1 > 0 && !string.IsNullOrEmpty(metaViewModel.Valor1))
                  )
               )
                 
            {
                return null;
            }
            else
            {
                if (metaViewModel != null && (
                    (!ValidarValor1 && ( (metaViewModel.Signo1 == 0 && !string.IsNullOrEmpty(metaViewModel.Valor1)) || (metaViewModel.Signo1 > 0 && string.IsNullOrEmpty(metaViewModel.Valor1)) ))
                    ||
                    (!ValidarValor2 && ( (metaViewModel.Signo2 == 0 && !string.IsNullOrEmpty(metaViewModel.Valor2)) || (metaViewModel.Signo2 > 0 && string.IsNullOrEmpty(metaViewModel.Valor2)) ))
                   ))
                {
                    return new ValidationResult("El campo " + validationContext.DisplayName + " es incorrecto.");
                }
                else
                {
                    return new ValidationResult("El campo " + validationContext.DisplayName + " es obligatorio.");
                }
            }
        }
    }
}