using System.Threading.Tasks;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public interface ITableroService
    {
        Task AuditarVisualizacionTablero(PersonaViewModel personaViewModel);
        Task<bool> ActualizarTablero(PersonaViewModel personaViewModel);
    }
}