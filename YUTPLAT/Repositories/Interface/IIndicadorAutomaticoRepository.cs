using System;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IIndicadorAutomaticoRepository : IDisposable
    {
        IQueryable<IndicadorAutomatico> Todos();

        Task<int> Guardar(IndicadorAutomatico indicadorAutomatico);

        IQueryable<IndicadorAutomatico> GetByIdIndicador(int idIndicador);

        void IniciarJob(IndicadorAutomaticoViewModel indicadorAutomatico);
        void DetenerJob(IndicadorAutomaticoViewModel indicadorAutomatico);
    }
}