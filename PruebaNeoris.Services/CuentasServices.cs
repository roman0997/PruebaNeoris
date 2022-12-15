using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Resources;
using PruebaNeoris.Entities.Utils;
using System.Net;

namespace PruebaNeoris.Services
{
    public class CuentasServices: ICuentasServices
    {
        private readonly ICuentasRepository cuentasRepository;

        public CuentasServices(ICuentasRepository _cuentasRepository)
        {
            cuentasRepository = _cuentasRepository;
        }

        public async Task<ApiResponse> GetCuentas()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                List<Cuentas> cuentas = cuentasRepository.GetCuentas().Result;
                response.StatusCode = HttpStatusCode.OK.GetHashCode();
                response.Data = cuentas;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                response.Errors.Add(new Error(HttpStatusCode.InternalServerError.GetHashCode(), MessagesResources.Error));
            }
            return response;
        }

        public async Task<ApiResponse> AddCuenta(Cuentas cuenta)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                bool result = cuentasRepository.AddCuenta(cuenta).Result;
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

        public async Task<ApiResponse> UpdateCuenta(Cuentas cuenta)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                bool result = cuentasRepository.UpdateCuenta(cuenta).Result;
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

        public async Task<ApiResponse> DeleteCuenta(string numeroCuenta)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                bool result = cuentasRepository.DeleteCuenta(numeroCuenta).Result;
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
    }
}
