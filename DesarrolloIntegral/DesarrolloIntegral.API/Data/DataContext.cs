using DesarrolloIntegral.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace DesarrolloIntegral.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<CuentaBancaria> Cuentas { get; set; }
        public DbSet<Banco> Bancos{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CuentaBancaria>()
                .HasIndex(c => new { c.NombreBanco, c.NumeroCuenta })
                .IsUnique();

            modelBuilder.Entity<Banco>()
                .HasIndex(b => b.IdBanco)
                .IsUnique();
        }
    }
}
