
using System.Collections.Generic;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IFrecuenciaMedicionIndicadorService
    {
        FrecuenciaMedicionIndicadorViewModel GetById(int id);

        IList<FrecuenciaMedicionIndicadorViewModel> Todas();

        IList<FrecuenciaMedicionIndicadorViewModel> Buscar(FrecuenciaMedicionIndicadorViewModel filtro);
    }
}