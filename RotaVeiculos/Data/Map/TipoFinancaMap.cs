using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaVeiculos.Models;

namespace RotaVeiculos.Data.Map
{
    public class TipoFinancaMap : IEntityTypeConfiguration<TipoFinanca>
    {
        public void Configure(EntityTypeBuilder<TipoFinanca> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeTipoFinanca).IsRequired().HasMaxLength(20);
        }
    }
}
