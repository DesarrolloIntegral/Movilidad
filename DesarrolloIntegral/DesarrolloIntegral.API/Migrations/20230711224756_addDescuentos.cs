using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addDescuentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescuentosDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    LineaId = table.Column<int>(type: "int", nullable: false),
                    DescuentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescuentosDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescuentosDetalles_Descuentos_DescuentoId",
                        column: x => x.DescuentoId,
                        principalTable: "Descuentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescuentosDetalles_Lineas_LineaId",
                        column: x => x.LineaId,
                        principalTable: "Lineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescuentosOrigenDestino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    DetalleId = table.Column<int>(type: "int", nullable: false),
                    DescuentoDetalleId = table.Column<int>(type: "int", nullable: true),
                    OrigenId = table.Column<int>(type: "int", nullable: false),
                    PuntoOrigenId = table.Column<int>(type: "int", nullable: true),
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    PuntoDestinoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescuentosOrigenDestino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescuentosOrigenDestino_DescuentosDetalles_DescuentoDetalleId",
                        column: x => x.DescuentoDetalleId,
                        principalTable: "DescuentosDetalles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DescuentosOrigenDestino_Puntos_PuntoDestinoId",
                        column: x => x.PuntoDestinoId,
                        principalTable: "Puntos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DescuentosOrigenDestino_Puntos_PuntoOrigenId",
                        column: x => x.PuntoOrigenId,
                        principalTable: "Puntos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescuentosDetalles_DescuentoId",
                table: "DescuentosDetalles",
                column: "DescuentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DescuentosDetalles_LineaId",
                table: "DescuentosDetalles",
                column: "LineaId");

            migrationBuilder.CreateIndex(
                name: "IX_DescuentosOrigenDestino_DescuentoDetalleId",
                table: "DescuentosOrigenDestino",
                column: "DescuentoDetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_DescuentosOrigenDestino_PuntoDestinoId",
                table: "DescuentosOrigenDestino",
                column: "PuntoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_DescuentosOrigenDestino_PuntoOrigenId",
                table: "DescuentosOrigenDestino",
                column: "PuntoOrigenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescuentosOrigenDestino");

            migrationBuilder.DropTable(
                name: "DescuentosDetalles");

            migrationBuilder.DropTable(
                name: "Descuentos");
        }
    }
}
