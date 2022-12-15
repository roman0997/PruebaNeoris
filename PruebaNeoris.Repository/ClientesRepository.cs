using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly DataContext db;
        private readonly IConfiguration Configuration;

        public ClientesRepository(IConfiguration configuration)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();
            this.db = new DataContext(optionBuilder.Options, configuration);
            Configuration = configuration;
        }

        public async Task<List<Clientes>> GetClientes()
        {
            return await this.db.Clientes.ToListAsync();
        }

        public async Task<bool> AddCliente(Clientes cliente)
        {
            bool response;
            try
            {
                db.Add(cliente);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> UpdateCliente(Clientes cliente)
        {
            bool response;
            try
            {
                db.Update(cliente);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> DeleteCliente(int clienteId)
        {
            bool response;
            try
            {
                Clientes cliente = db.Clientes.Find(clienteId);
                db.Remove(cliente);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }
    }
}
