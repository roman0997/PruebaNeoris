using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Services
{
    public class PersonasServices: IPersonasServices
    {
        private readonly IPersonasRepository personasRepository;

        public PersonasServices(IPersonasRepository _personasRepository)
        {
            personasRepository = _personasRepository;
        }

        public async Task<ApiResponse> GetPersonas()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                List<Personas> Personas = personasRepository.GetPersonas().Result;
                response.StatusCode = HttpStatusCode.OK.GetHashCode();
                response.Data = Personas;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ApiResponse> AddPersona(Personas persona)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                bool result = personasRepository.AddPersona(persona).Result;
                response.StatusCode = result ? HttpStatusCode.OK.GetHashCode() : HttpStatusCode.InternalServerError.GetHashCode();
                response.Data = result;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ApiResponse> UpdatePersona(Personas persona)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                bool result = personasRepository.UpdatePersona(persona).Result;
                response.StatusCode = result ? HttpStatusCode.OK.GetHashCode() : HttpStatusCode.InternalServerError.GetHashCode();
                response.Data = result;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ApiResponse> DeletePersona(string identificacion)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                bool result = personasRepository.DeletePersona(identificacion).Result;
                response.StatusCode = result ? HttpStatusCode.OK.GetHashCode() : HttpStatusCode.InternalServerError.GetHashCode();
                response.Data = result;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
    }
}
