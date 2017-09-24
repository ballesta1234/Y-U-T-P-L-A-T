
using System;
using System.Linq;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories.Interface
{
    public interface IAreaRepository : IDisposable
    {
        IQueryable<Area> Todas();
    }
}