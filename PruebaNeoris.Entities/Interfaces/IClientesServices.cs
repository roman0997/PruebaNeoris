using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Request;
using PruebaNeoris.Entities.Utils;

namespace PruebaNeoris.Entities.Interfaces
{
    public interface IClientesServices
    {
        Task<ApiResponse> GetClientes();
        Task<ApiResponse> AddCliente(ClientesRequest cliente);
        Task<ApiResponse> UpdateCliente(ClientesRequest cliente);
        Task<ApiResponse> DeleteCliente(int clienteId);
    }
}
