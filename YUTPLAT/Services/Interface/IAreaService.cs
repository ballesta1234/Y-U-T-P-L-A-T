
using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface IAreaService
    {
        IList<AreaViewModel> Todas();

        IList<AreaViewModel> Buscar(BuscarAreaViewModel filtro);
    }
}