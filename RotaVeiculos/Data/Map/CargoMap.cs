using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaVeiculos.Models;

namespace RotaVeiculos.Data.Map
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeCargo).IsRequired().HasMaxLength(100);
        }
    }
}
