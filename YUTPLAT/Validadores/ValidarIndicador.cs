using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Validadores
{
    public class ValidarIndicador : ValidationAttribute
    {
        public ValidarIndicador()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IndicadorViewModel indicadorViewModel = (IndicadorViewModel)value;

            if (indicadorViewModel != null && indicadorViewModel.Id > 0)
            {
                IMedicionService medicionService = DependencyResolver.Current.GetService<IMedicionService>();

                EscalaGraficosViewModel escalas = medicionService.ObtenerEscalasGrafico(indicadorViewModel);

                decimal[] escalaValores = escalas.EscalaValores;

                if (escalaValores[0] <= escalaValores[1] &&
                   escalaValores[1] <= escalaValores[2] &&
                   escalaValores[2] <= escalaValores[3] &&
                   escalaValores[3] <= escalaValores[4] &&
                   escalaValores[4] <= escalaValores[5])
                {
                    return null;
                }
                else
                {
                    return new ValidationResult("Verifique que los rangos de las metas sean correctos.");
                }
            }
            else
            {
                return null;
            }
        }
    }
}