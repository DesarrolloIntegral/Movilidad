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
    [Migration("20230712212832_nombredesc")]
    partial class nombredesc
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

                    b.Property<int?>("DescuentoDetalleId")
                        .HasColumnType("int");

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.Property<int>("DetalleId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrigenId")
                        .HasColumnType("int");

                    b.Property<int?>("PuntoDestinoId")
                        .HasColumnType("int");

                    b.Property<int?>("PuntoOrigenId")
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

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Puntos");
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
                        .HasForeignKey("DescuentoDetalleId");

                    b.HasOne("DesarrolloIntegral.Shared.Models.PuntoRecorrido", "PuntoDestino")
                        .WithMany()
                        .HasForeignKey("PuntoDestinoId");

                    b.HasOne("DesarrolloIntegral.Shared.Models.PuntoRecorrido", "PuntoOrigen")
                        .WithMany()
                        .HasForeignKey("PuntoOrigenId");

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
                });

            modelBuilder.Entity("DesarrolloIntegral.Shared.Models.Puesto", b =>
                {
                    b.Navigation("Personals");
                });
#pragma warning restore 612, 618
        }
    }
}
