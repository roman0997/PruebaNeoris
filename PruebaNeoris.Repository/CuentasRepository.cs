using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Repository.Context;

namespace PruebaNeoris.Repository
{
    public class CuentasRepository : ICuentasRepository
    {
        private readonly DataContext db;
        private readonly IConfiguration Configuration;

        public CuentasRepository(IConfiguration configuration)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();
            this.db = new DataContext(optionBuilder.Options, configuration);
            Configuration = configuration;
        }

        public async Task<List<Cuentas>> GetCuentas()
        {
            return await this.db.Cuentas.ToListAsync();
        }

        public async Task<Cuentas> GetCuentaById(string numeroCuenta)
        {
            return await this.db.Cuentas.FirstOrDefaultAsync(x => x.NumeroCuenta == numeroCuenta);
        }

        public async Task<bool> AddCuenta(Cuentas cuenta)
        {
            bool response;
            try
            {
                db.Add(cuenta);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> UpdateCuenta(Cuentas cuenta)
        {
            bool response;
            try
            {
                db.Update(cuenta);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> DeleteCuenta(string numeroCuenta)
        {
            bool response;
            try
            {
                Cuentas cuenta = db.Cuentas.Find(numeroCuenta);
                db.Remove(cuenta);
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
