using DesarrolloIntegral.Shared.Models;
using DesarrolloIntegral.Shared.Pages.Rol.Itinerarios.TiemposRecorrido;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloIntegral.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CuentaBancaria> Cuentas { get; set; }

        public DbSet<Banco> Bancos { get; set; }

        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Linea> Lineas { get; set; }

        public DbSet<PerfilUsuario> PerfilesUsuario { get; set; }

        public DbSet<Puesto> Puestos { get; set; }

        public DbSet<Personal> Personal { get; set; }

        public DbSet<PuntoRecorrido> Puntos { get; set; }

        public DbSet<Descuento> Descuentos { get; set; }

        public DbSet<DescuentoDetalle> DescuentosDetalles { get; set; }

        public DbSet<DescuentoOrigenDestino> DescuentosOrigenDestino { get; set; }

        public DbSet<Tarifa> Tarifas { get; set; }

        public DbSet<TarifaDetalle> TarifasDetalle { get; set; }

        public DbSet<Ruta> Rutas { get; set; }

        public DbSet<Trayecto> Trayectos { get; set; }

        public DbSet<Unidad> Unidades { get; set; }

        public DbSet<UnidadOperador> UnidadOperadores { get; set; }

        public DbSet<Itinerario> Itinerarios { get; set; }

        public DbSet<HorarioServicio> HorarioServicios { get; set; }

        public DbSet<TiempoRecorrido> TiempoRecorridos { get; set; }

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

            modelBuilder.Entity<PuntoRecorrido>()
                .HasIndex(b => b.Nombre)
                .IsUnique();

            modelBuilder.Entity<DescuentoOrigenDestino>()
                    .HasOne(m => m.PuntoOrigen)
                    .WithMany(t => t.PuntoOrigenes)
                    .HasForeignKey(m => m.PuntoOrigenId)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DescuentoOrigenDestino>()
                    .HasOne(m => m.PuntoDestino)
                    .WithMany(t => t.PuntoDestinos)
                    .HasForeignKey(m => m.PuntoDestinoId)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tarifa>()
                    .HasIndex(b => b.Nombre)
                    .IsUnique();

            modelBuilder.Entity<Ruta>()
                    .HasIndex(b => b.Nombre)
                    .IsUnique();

            modelBuilder.Entity<TarifaDetalle>()
                    .HasOne(m => m.PuntoOrigen)
                    .WithMany(t => t.PuntoOriDetalles)
                    .HasForeignKey(m => m.PuntoOrigenId)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TarifaDetalle>()
                    .HasOne(m => m.PuntoDestino)
                    .WithMany(t => t.PuntoDesDetalles)
                    .HasForeignKey(m => m.PuntoDestinoId)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Itinerario>()
                    .HasIndex(b => b.Descripcion)
                    .IsUnique();
        }
    }
}
