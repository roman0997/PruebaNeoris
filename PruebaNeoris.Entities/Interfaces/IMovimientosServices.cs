using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Utils;

namespace PruebaNeoris.Entities.Interfaces
{
    public interface IMovimientosServices
    {
        Task<ApiResponse> GetMovimientos();
        Task<ApiResponse> AddMovimiento(Movimientos movimiento);
        Task<ApiResponse> UpdateMovimiento(Movimientos movimiento);
        Task<ApiResponse> DeleteMovimiento(int movimientoId);
        Task<ApiResponse> Reporte(string startDate, string endDate, string identificacion);
    }
}
