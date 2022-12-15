using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Entities.Interfaces
{
    public interface IPersonasServices
    {
        Task<ApiResponse> GetPersonas();
        Task<ApiResponse> AddPersona(Personas persona);
        Task<ApiResponse> UpdatePersona(Personas persona);
        Task<ApiResponse> DeletePersona(string identificacion);
    }
}
