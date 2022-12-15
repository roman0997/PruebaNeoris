using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils;

namespace PruebaNeoris.Entities.Interfaces
{
    public interface ICuentasServices
    {
        Task<ApiResponse> GetCuentas();
        Task<ApiResponse> AddCuenta(Cuentas cuenta);
        Task<ApiResponse> UpdateCuenta(Cuentas cuenta);
        Task<ApiResponse> DeleteCuenta(string numeroCuenta);
    }
}
