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

        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Linea> Lineas { get; set; }

        public DbSet<PerfilUsuario> PerfilesUsuario { get; set; }

        public DbSet<Puesto> Puestos { get; set; }

        public DbSet<Personal> Personal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CuentaBancaria>()
                .HasIndex("NumeroCuenta", "BancoId")
                .IsUnique();

            modelBuilder.Entity<Banco>()
                .HasIndex(b => b.Nombre)
                .IsUnique();

            modelBuilder.Entity<Empresa>()
                .HasIndex(b => b.Nombre)
                .IsUnique();

            modelBuilder.Entity<Linea>()
                .HasIndex(b => b.Nombre)
                .IsUnique();

            modelBuilder.Entity<PerfilUsuario>()
                .HasIndex(b => b.Nombre)
                .IsUnique();

            modelBuilder.Entity<Puesto>()
                .HasIndex(b => b.Nombre)
                .IsUnique();

            modelBuilder.Entity<Personal>()
                .HasIndex(b => b.Nombre)
                .IsUnique();
        }
    }
}
