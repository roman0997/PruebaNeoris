using PruebaNeoris.Entities.Models;
using PruebaNeoris.Entities.Request;
using PruebaNeoris.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
