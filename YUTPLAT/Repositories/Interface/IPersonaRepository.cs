using System;
using System.Linq;
using System.Threading.Tasks;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Repositories.Interface
{
    public interface IPersonaRepository : IDisposable
    {
        IQueryable<Persona> GetById(string id);

        Task<Persona> GetByUserName(string userName);

        IQueryable<Persona> Todas();

        IQueryable<Persona> Buscar(PersonaViewModel filtro);        
    }
}