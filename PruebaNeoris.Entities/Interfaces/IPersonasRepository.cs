using PruebaNeoris.Entities.Models;

namespace PruebaNeoris.Entities.Interfaces
{
    public interface IPersonasRepository
    {
        Task<List<Personas>> GetPersonas();
        Task<bool> AddPersona(Personas persona);
        Task<bool> UpdatePersona(Personas persona);
        Task<bool> DeletePersona(string identificacion);
    }
}
