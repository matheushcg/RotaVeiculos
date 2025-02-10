using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaVeiculos.Models;

namespace RotaVeiculos.Data.Map
{
    public class ManutencaoMap : IEntityTypeConfiguration<Manutencao>
    {
        public void Configure(EntityTypeBuilder<Manutencao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Preco).IsRequired();
            builder.Property(x => x.ManutencaoRealizada).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Placa).IsRequired().HasMaxLength(8);
            builder.Property(x => x.NomeImagem).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Imagem).IsRequired().HasMaxLength(250);
        }
    }
}