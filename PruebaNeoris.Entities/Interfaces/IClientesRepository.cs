using PruebaNeoris.Entities.Models;

namespace PruebaNeoris.Entities.Interfaces
{
    public interface IClientesRepository
    {
        Task<List<Clientes>> GetClientes();
        Task<Clientes> GetClienteById(int clienteId);
        Task<bool> AddCliente(Clientes cliente);
        Task<bool> UpdateCliente(Clientes cliente);
        Task<bool> DeleteCliente(int clienteId);
    }
}
