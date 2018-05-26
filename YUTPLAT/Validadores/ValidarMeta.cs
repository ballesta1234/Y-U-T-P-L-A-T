using System;
using System.ComponentModel.DataAnnotations;
using YUTPLAT.ViewModel;
using static YUTPLAT.Enums.Enum;

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
                if (ValidaSignos(metaViewModel))
                {
                    return null;
                }
                else
                {
                    return new ValidationResult("El campo Meta " + validationContext.DisplayName + " es incorrecto.");
                }
            }
            else
            {
                if (metaViewModel != null && (
                    (!ValidarValor1 && ( (metaViewModel.Signo1 == 0 && !string.IsNullOrEmpty(metaViewModel.Valor1)) || (metaViewModel.Signo1 > 0 && string.IsNullOrEmpty(metaViewModel.Valor1)) ))
                    ||
                    (!ValidarValor2 && ( (metaViewModel.Signo2 == 0 && !string.IsNullOrEmpty(metaViewModel.Valor2)) || (metaViewModel.Signo2 > 0 && string.IsNullOrEmpty(metaViewModel.Valor2)) ))
                   ))
                {
                    return new ValidationResult("El campo Meta " + validationContext.DisplayName + " es incorrecto.");
                }
                else
                {
                    return new ValidationResult("El campo Meta " + validationContext.DisplayName + " es obligatorio.");
                }
            }
        }

        private bool ValidaSignos(MetaViewModel meta)
        {
            if (!string.IsNullOrEmpty(meta.Valor1) && !string.IsNullOrEmpty(meta.Valor2))
            {
                decimal valor1 = Decimal.Parse(meta.Valor1.Replace(".", ","));
                decimal valor2 = Decimal.Parse(meta.Valor2.Replace(".", ","));

                Signo signo1 = meta.Signo1;
                Signo signo2 = meta.Signo2;

                if (valor1 == valor2)
                {
                    return (signo1 == Signo.Igual && signo2 == Signo.Igual) ||
                           (signo1 == Signo.Igual && signo2 == Signo.MayorOIgual) ||
                           (signo1 == Signo.Igual && signo2 == Signo.MenorOIgual) ||
                           (signo1 == Signo.MayorOIgual && signo2 == Signo.Igual) ||
                           (signo1 == Signo.MenorOIgual && signo2 == Signo.Igual) ||
                           (signo1 == Signo.MayorOIgual && signo2 == Signo.MayorOIgual) ||
                           (signo1 == Signo.MayorOIgual && signo2 == Signo.MenorOIgual) ||
                           (signo1 == Signo.MenorOIgual && signo2 == Signo.MenorOIgual) ||
                           (signo1 == Signo.MenorOIgual && signo2 == Signo.MayorOIgual);
                }
                else if(valor1 < valor2)
                {
                    return (signo1 == Signo.Menor && signo2 == Signo.Igual) ||
                           (signo1 == Signo.Menor && signo2 == Signo.Menor) ||
                           (signo1 == Signo.Menor && signo2 == Signo.MenorOIgual) ||
                           (signo1 == Signo.MenorOIgual && signo2 == Signo.MenorOIgual) ||
                           (signo1 == Signo.MenorOIgual && signo2 == Signo.Igual) ||
                           (signo1 == Signo.MenorOIgual && signo2 == Signo.Menor) ||
                           (signo1 == Signo.Igual && signo2 == Signo.Menor) ||
                           (signo1 == Signo.Igual && signo2 == Signo.MenorOIgual); 
                }
                else if(valor1 > valor2)
                {
                    return (signo1 == Signo.Mayor && signo2 == Signo.Igual) ||
                           (signo1 == Signo.Mayor && signo2 == Signo.Mayor) ||
                           (signo1 == Signo.Mayor && signo2 == Signo.MayorOIgual) ||
                           (signo1 == Signo.MayorOIgual && signo2 == Signo.MayorOIgual) ||
                           (signo1 == Signo.MayorOIgual && signo2 == Signo.Igual) ||
                           (signo1 == Signo.MayorOIgual && signo2 == Signo.Mayor) ||
                           (signo1 == Signo.Igual && signo2 == Signo.Mayor) ||
                           (signo1 == Signo.Igual && signo2 == Signo.MayorOIgual);
                }
                else
                {
                    return false;
                }                
            }
            else
            {
                return true;
            }
        }
    }
}