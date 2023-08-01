﻿// <auto-generated />
using System;
using DesarrolloIntegral.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230729174322_TarifasDetalle")]
    partial class TarifasDetalle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.CuentaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BancoId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoCuenta")
                        .HasColumnType("int");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.HasIndex("NumeroCuenta", "BancoId")
                        .IsUnique();

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Descuento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Descuentos");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.DescuentoDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DescuentoId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("LineaId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DescuentoId");

                    b.HasIndex("LineaId");

                    b.ToTable("DescuentosDetalles");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.DescuentoOrigenDestino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DescuentoDetalleId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("PuntoDestinoId")
                        .HasColumnType("int");

                    b.Property<int>("PuntoOrigenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DescuentoDetalleId");

                    b.HasIndex("PuntoDestinoId");

                    b.HasIndex("PuntoOrigenId");

                    b.ToTable("DescuentosOrigenDestino");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abreviatura")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Linea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Lineas");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.PerfilUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("PerfilesUsuario");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Personal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PuestoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.HasIndex("PuestoId");

                    b.ToTable("Personal");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Puesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Puestos");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.PuntoRecorrido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abreviatura")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Latitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Venta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Puntos");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Ruta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("LineaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LineaId");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Rutas");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Tarifa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("LineaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TarifaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LineaId");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.HasIndex("TarifaId");

                    b.ToTable("Tarifas");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.TarifaDetalle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("PuntoDestinoId")
                        .HasColumnType("int");

                    b.Property<int>("PuntoOrigenId")
                        .HasColumnType("int");

                    b.Property<int>("TarifaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PuntoDestinoId");

                    b.HasIndex("PuntoOrigenId");

                    b.HasIndex("TarifaId");

                    b.ToTable("TarifasDetalle");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Trayecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("Estancia")
                        .HasColumnType("int");

                    b.Property<decimal>("Kilometros")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Minutos")
                        .HasColumnType("int");

                    b.Property<int>("Posicion")
                        .HasColumnType("int");

                    b.Property<int>("PuntoId")
                        .HasColumnType("int");

                    b.Property<int>("RutaId")
                        .HasColumnType("int");

                    b.Property<int>("Terminal")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PuntoId");

                    b.HasIndex("RutaId");

                    b.ToTable("Trayectos");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.CuentaBancaria", b =>
                {
                    b.HasOne("DesarrolloIntegral.Shared.Models.Banco", "Banco")
                        .WithMany("Cuentas")
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.DescuentoDetalle", b =>
                {
                    b.HasOne("DesarrolloIntegral.Shared.Models.Descuento", "Descuento")
                        .WithMany("DescuentoDetalles")
                        .HasForeignKey("DescuentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesarrolloIntegral.Shared.Models.Linea", "Linea")
                        .WithMany("DescuentoDetalles")
                        .HasForeignKey("LineaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Descuento");

                    b.Navigation("Linea");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.DescuentoOrigenDestino", b =>
                {
                    b.HasOne("DesarrolloIntegral.Shared.Models.DescuentoDetalle", "DescuentoDetalle")
                        .WithMany("OrigenDestinos")
                        .HasForeignKey("DescuentoDetalleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesarrolloIntegral.Shared.Models.PuntoRecorrido", "PuntoDestino")
                        .WithMany("PuntoDestinos")
                        .HasForeignKey("PuntoDestinoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DesarrolloIntegral.Shared.Models.PuntoRecorrido", "PuntoOrigen")
                        .WithMany("PuntoOrigenes")
                        .HasForeignKey("PuntoOrigenId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DescuentoDetalle");

                    b.Navigation("PuntoDestino");

                    b.Navigation("PuntoOrigen");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Personal", b =>
                {
                    b.HasOne("DesarrolloIntegral.Shared.Models.Puesto", "Puesto")
                        .WithMany("Personals")
                        .HasForeignKey("PuestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Puesto");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Ruta", b =>
                {
                    b.HasOne("DesarrolloIntegral.Shared.Models.Linea", "Linea")
                        .WithMany("Rutas")
                        .HasForeignKey("LineaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Linea");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Tarifa", b =>
                {
                    b.HasOne("DesarrolloIntegral.Shared.Models.Linea", "Linea")
                        .WithMany("Tarifas")
                        .HasForeignKey("LineaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesarrolloIntegral.Shared.Models.Tarifa", null)
                        .WithMany("Tarifas")
                        .HasForeignKey("TarifaId");

                    b.Navigation("Linea");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.TarifaDetalle", b =>
                {
                    b.HasOne("DesarrolloIntegral.Shared.Models.PuntoRecorrido", "PuntoDestino")
                        .WithMany("PuntoDesDetalles")
                        .HasForeignKey("PuntoDestinoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DesarrolloIntegral.Shared.Models.PuntoRecorrido", "PuntoOrigen")
                        .WithMany("PuntoOriDetalles")
                        .HasForeignKey("PuntoOrigenId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DesarrolloIntegral.Shared.Models.Tarifa", "Tarifa")
                        .WithMany()
                        .HasForeignKey("TarifaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PuntoDestino");

                    b.Navigation("PuntoOrigen");

                    b.Navigation("Tarifa");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Trayecto", b =>
                {
                    b.HasOne("DesarrolloIntegral.Shared.Models.PuntoRecorrido", "Punto")
                        .WithMany("Trayectos")
                        .HasForeignKey("PuntoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesarrolloIntegral.Shared.Models.Ruta", "Ruta")
                        .WithMany("Trayectos")
                        .HasForeignKey("RutaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Punto");

                    b.Navigation("Ruta");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Banco", b =>
                {
                    b.Navigation("Cuentas");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Descuento", b =>
                {
                    b.Navigation("DescuentoDetalles");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.DescuentoDetalle", b =>
                {
                    b.Navigation("OrigenDestinos");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Linea", b =>
                {
                    b.Navigation("DescuentoDetalles");

                    b.Navigation("Rutas");

                    b.Navigation("Tarifas");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Puesto", b =>
                {
                    b.Navigation("Personals");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.PuntoRecorrido", b =>
                {
                    b.Navigation("PuntoDesDetalles");

                    b.Navigation("PuntoDestinos");

                    b.Navigation("PuntoOriDetalles");

                    b.Navigation("PuntoOrigenes");

                    b.Navigation("Trayectos");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Ruta", b =>
                {
                    b.Navigation("Trayectos");
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Tarifa", b =>
                {
                    b.Navigation("Tarifas");
                });
#pragma warning restore 612, 618
        }
    }
}
