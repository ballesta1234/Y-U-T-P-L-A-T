
using System.Collections.Generic;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IObjetivoService
    {
        ObjetivoViewModel GetById(int id);

        IList<ObjetivoViewModel> Todas();

        IList<ObjetivoViewModel> Buscar(BuscarObjetivoViewModel filtro);

        int Guardar(ObjetivoViewModel areaViewModel);
    }
}