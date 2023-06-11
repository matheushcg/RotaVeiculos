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
            builder.Property(x => x.Preco).IsRequired();
            builder.Property(x => x.ManutencaoRealizada).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.Veiculo)
                .WithMany()
                .HasForeignKey(x => x.VeiculoId)
                .HasConstraintName("FK_Veiculo").OnDelete(DeleteBehavior.NoAction);
        }
    }
}