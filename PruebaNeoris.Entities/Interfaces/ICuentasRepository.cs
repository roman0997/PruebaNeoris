using PruebaNeoris.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Entities.Interfaces
{
    public interface ICuentasRepository
    {
        Task<List<Cuentas>> GetCuentas();
        Task<Cuentas> GetCuentaById(string numeroCuenta);
        Task<bool> AddCuenta(Cuentas cuenta);
        Task<bool> UpdateCuenta(Cuentas cuenta);
        Task<bool> DeleteCuenta(string numeroCuenta);
    }
}
