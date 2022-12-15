using PruebaNeoris.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Entities.Interfaces
{
    public interface IClientesRepository
    {
        Task<List<Clientes>> GetClientes();
        Task<bool> AddCliente(Clientes cliente);
        Task<bool> UpdateCliente(Clientes cliente);
        Task<bool> DeleteCliente(int clienteId);
    }
}
