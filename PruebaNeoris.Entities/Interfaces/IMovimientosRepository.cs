using PruebaNeoris.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Entities.Interfaces
{
    public interface IMovimientosRepository
    {
        Task<List<Movimientos>> GetMovimientos();
        Task<bool> AddMovimiento(Movimientos movimiento);
        Task<bool> UpdateMovimiento(Movimientos movimiento);
        Task<bool> DeleteMovimiento(int movimientoId);
        Task<List<Movimientos>> GetEstadoCuenta(DateTime startDate, DateTime endDate, string identificacion);
    }
}
