
using System.Collections.Generic;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IIndicadorService
    {
        IndicadorViewModel GetById(int id);

        IList<IndicadorViewModel> Todas();

        IList<IndicadorViewModel> Buscar(BuscarIndicadorViewModel filtro);

        int Guardar(IndicadorViewModel indicadorViewModel);        
    }
}