using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
