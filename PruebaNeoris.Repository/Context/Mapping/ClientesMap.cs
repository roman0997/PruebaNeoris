using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaNeoris.Entities.Models;

namespace PruebaNeoris.Repository.Context.Mapping
{
    public class ClientesMap : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("Clientes")
                .HasKey(x => x.ClienteId);
            
        }
    }
}


