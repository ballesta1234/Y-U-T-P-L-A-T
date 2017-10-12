
using System;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories.Interface
{
    public interface IMetaRepository : IDisposable
    {
        int Guardar(Meta meta);
    }
}