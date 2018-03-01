using System;
using System.Threading.Tasks;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories.Interface
{
    public interface IMetaRepository : IDisposable
    {
        Task<int> Guardar(Meta meta);
    }
}