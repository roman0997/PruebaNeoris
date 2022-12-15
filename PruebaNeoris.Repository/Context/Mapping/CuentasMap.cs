using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaNeoris.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Repository.Context.Mapping
{
    public class CuentasMap: IEntityTypeConfiguration<Cuentas>
    {
        public void Configure(EntityTypeBuilder<Cuentas> builder)
        {
            builder.ToTable("Cuentas")
                .HasKey(x => x.NumeroCuenta);
        }
    }
}
