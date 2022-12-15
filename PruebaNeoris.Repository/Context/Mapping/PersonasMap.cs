using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaNeoris.Entities.Models;

namespace PruebaNeoris.Repository.Context.Mapping
{
    public class PersonasMap: IEntityTypeConfiguration<Personas>
    {
        public void Configure(EntityTypeBuilder<Personas> builder)
        {
            builder.ToTable("Personas")
                .HasKey(x => x.Identificacion);
        }
    }
}
