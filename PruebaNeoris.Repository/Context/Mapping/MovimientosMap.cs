using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaNeoris.Entities.Models;

namespace PruebaNeoris.Repository.Context.Mapping
{
    public class MovimientosMap: IEntityTypeConfiguration<Movimientos>
    {
        public void Configure(EntityTypeBuilder<Movimientos> builder)
        {
            builder.ToTable("Movimientos")
                .HasKey(x => x.MovimientoId);
        }
    }
}
