using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Request;
using PruebaNeoris.Entities.Resources;
using PruebaNeoris.Entities.Utils;
using System.Net;

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
            catch (Exception e)
            {
                response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                response.Errors.Add(new Error(HttpStatusCode.InternalServerError.GetHashCode(), MessagesResources.Error));
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
                    response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                    response.Errors.Add(new Error(HttpStatusCode.BadRequest.GetHashCode(), "ya existe un usuario registrado con esta identificacion"));
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
            catch (Exception e)
            {
                response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                response.Errors.Add(new Error(HttpStatusCode.InternalServerError.GetHashCode(), MessagesResources.Error));
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
                response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                response.Errors.Add(new Error(HttpStatusCode.InternalServerError.GetHashCode(), MessagesResources.Error));
            }
            return response;
        }

        public async Task<ApiResponse> DeleteCliente(int clienteId)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                Clientes cliente = clientesRepository.GetClienteById(clienteId).Result;
                bool result = clientesRepository.DeleteCliente(clienteId).Result;
                bool resultPersona = false;
                if(result)
                {
                    resultPersona = personasRepository.DeletePersona(cliente.PersonaId).Result;
                }
                response.StatusCode = resultPersona ? HttpStatusCode.OK.GetHashCode() : HttpStatusCode.InternalServerError.GetHashCode();
                response.Data = resultPersona;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                response.Errors.Add(new Error(HttpStatusCode.InternalServerError.GetHashCode(), MessagesResources.Error));
            }
            return response;
        }
    }
}
