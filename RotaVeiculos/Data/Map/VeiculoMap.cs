using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaVeiculos.Models;

namespace RotaVeiculos.Data.Map
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Preco).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Quilometragem).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Placa).IsRequired().HasMaxLength(10);
            builder.Property(x => x.DocumentosEmDia).IsRequired();
            builder.Property(x => x.Imagem).IsRequired().HasMaxLength(250);
        }
    }
}
