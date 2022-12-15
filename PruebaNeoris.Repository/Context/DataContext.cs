using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaNeoris.Entities.Models;
using PruebaNeoris.Repository.Context.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Repository.Context
{
    public class DataContext : DbContext
    {
        private IConfiguration Configuration { get; }

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options) 
        {
            Configuration = configuration;
        }

        public DbSet<Personas> Personas { get; set; }
        public DbSet<Clientes> Clientes { get; set;}
        public DbSet<Cuentas> Cuentas { get; set;}
        public DbSet<Movimientos> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonasMap());
            modelBuilder.ApplyConfiguration(new ClientesMap());
            modelBuilder.ApplyConfiguration(new CuentasMap());
            modelBuilder.ApplyConfiguration(new MovimientosMap());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:PruebaNeoris"]);

        }
    }
}
