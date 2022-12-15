using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Repository
{
    public class MovimientosRepository : IMovimientosRepository
    {
        private readonly DataContext db;
        private readonly IConfiguration Configuration;

        public MovimientosRepository(IConfiguration configuration)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();
            this.db = new DataContext(optionBuilder.Options, configuration);
            Configuration = configuration;
        }

        public async Task<List<Movimientos>> GetMovimientos()
        {
            return await this.db.Movimientos.ToListAsync();
        }

        public async Task<bool> AddMovimiento(Movimientos movimiento)
        {
            bool response;
            try
            {
                db.Add(movimiento);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> UpdateMovimiento(Movimientos movimiento)
        {
            bool response;
            try
            {
                db.Update(movimiento);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> DeleteMovimiento(int movimientoId)
        {
            bool response;
            try
            {
                Movimientos movimiento = db.Movimientos.Find(movimientoId);
                db.Remove(movimiento);
                db.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                response = false;
            }
            return response;
        }

        public async Task<List<Movimientos>> GetEstadoCuenta(DateTime startDate, DateTime endDate, string identificacion)
        {
            return await this.db.Movimientos.Include("Cuenta.Cliente.Persona").Where(x => x.Cuenta.Cliente.Persona.Identificacion == identificacion).ToListAsync();
        }
    }
}
