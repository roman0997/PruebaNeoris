using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Request;
using PruebaNeoris.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Services
{
    public class ClientesServices: IClientesServices
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IPersonasRepository personasRepository;

        public ClientesServices(IClientesRepository _clientesRepository, IPersonasRepository _personasRepository)
        {
            clientesRepository = _clientesRepository;
            personasRepository = _personasRepository;
        }

        public async Task<ApiResponse> GetClientes()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                List<Clientes> clientes = clientesRepository.GetClientes().Result;
                response.StatusCode = HttpStatusCode.OK.GetHashCode();
                response.Data = clientes;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ApiResponse> AddCliente(ClientesRequest cliente)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                Personas objPersona = new Personas()
                {
                    Direccion = cliente.Direccion,
                    Edad = cliente.Edad,
                    Genero = cliente.Genero,
                    Identificacion = cliente.Identificacion,
                    Nombre = cliente.Nombre,
                    Telefono = cliente.Telefono
                };
                bool resultPersona = personasRepository.AddPersona(objPersona).Result;
                if(!resultPersona)
                {
                    response.Errors.Add(new Error(HttpStatusCode.BadRequest.GetHashCode().ToString(), "ya existe un usuario registrado con esta identificacion"));
                    return response;
                }
                Clientes objCliente = new Clientes()
                {
                    Contrasena = cliente.Contrasena,
                    Estado = cliente.Estado,
                    PersonaId = cliente.Identificacion,
                };
                bool result = clientesRepository.AddCliente(objCliente).Result;
                response.StatusCode = result ? HttpStatusCode.OK.GetHashCode() : HttpStatusCode.InternalServerError.GetHashCode();
                response.Data = result;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ApiResponse> UpdateCliente(ClientesRequest cliente)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                Personas objPersona = new Personas()
                {
                    Direccion = cliente.Direccion,
                    Edad = cliente.Edad,
                    Genero = cliente.Genero,
                    Identificacion = cliente.Identificacion,
                    Nombre = cliente.Nombre,
                    Telefono = cliente.Telefono
                };
                bool resultPersona = personasRepository.UpdatePersona(objPersona).Result;

                Clientes objCliente = new Clientes()
                {
                    Contrasena = cliente.Contrasena,
                    Estado = cliente.Estado,
                    PersonaId = cliente.Identificacion,
                };
                bool result = clientesRepository.UpdateCliente(objCliente).Result;
                response.StatusCode = result ? HttpStatusCode.OK.GetHashCode() : HttpStatusCode.InternalServerError.GetHashCode();
                response.Data = result;
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public async Task<ApiResponse> DeleteCliente(int clienteId)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                bool result = clientesRepository.DeleteCliente(clienteId).Result;
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
