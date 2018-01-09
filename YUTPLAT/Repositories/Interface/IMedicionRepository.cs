
using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IMedicionRepository : IDisposable
    {
        IQueryable<Medicion> GetById(string id);        

        IQueryable<Medicion> Todas();

        IQueryable<Medicion> Buscar(MedicionViewModel filtro);        
    }
}