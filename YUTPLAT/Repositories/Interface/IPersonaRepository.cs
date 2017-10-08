
using System;
using System.Linq;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IPersonaRepository : IDisposable
    {
        IQueryable<Persona> GetById(string id);        

        IQueryable<Persona> Todas();

        IQueryable<Persona> Buscar(PersonaViewModel filtro);        
    }
}