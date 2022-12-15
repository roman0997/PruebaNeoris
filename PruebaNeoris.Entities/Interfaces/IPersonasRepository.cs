using PruebaNeoris.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
