using DesarrolloIntegral.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<tbCuentaBancaria> Cuentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<tbCuentaBancaria>()
                .HasIndex(c => new { c.NombreBanco, c.NumeroCuenta })
                .IsUnique();
        }
    }
}
