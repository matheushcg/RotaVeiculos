using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Models;

namespace RotaVeiculos.Data.Map
{
    public class FinancaMap : IEntityTypeConfiguration<Financa>
    {
        public void Configure(EntityTypeBuilder<Financa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Valor).IsRequired().HasMaxLength(15);
            builder.HasOne(x => x.TipoFinanca)
                .WithMany()
                .HasForeignKey(x => x.TipoFinancaId)
                .HasConstraintName("FK_Tipo_Financeiro").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
