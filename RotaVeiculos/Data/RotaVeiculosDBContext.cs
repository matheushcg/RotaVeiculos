using Microsoft.EntityFrameworkCore;
using RotaVeiculos.Data.Map;
using RotaVeiculos.Models;

namespace RotaVeiculos.Data
{
    public class RotaVeiculosDBContext : DbContext
    {
        public RotaVeiculosDBContext(DbContextOptions<RotaVeiculosDBContext> options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
