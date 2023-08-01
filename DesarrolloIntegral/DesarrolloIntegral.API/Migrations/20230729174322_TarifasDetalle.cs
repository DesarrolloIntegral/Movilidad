using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class TarifasDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TarifaId",
                table: "Tarifas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TarifasDetalle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    PuntoOrigenId = table.Column<int>(type: "int", nullable: false),
                    PuntoDestinoId = table.Column<int>(type: "int", nullable: false),
                    TarifaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarifasDetalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_TarifasDetalle_Puntos_PuntoDestinoId",
                        column: x => x.PuntoDestinoId,
                        principalTable: "Puntos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TarifasDetalle_Puntos_PuntoOrigenId",
                        column: x => x.PuntoOrigenId,
                        principalTable: "Puntos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TarifasDetalle_Tarifas_TarifaId",
                        column: x => x.TarifaId,
                        principalTable: "Tarifas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarifas_TarifaId",
                table: "Tarifas",
                column: "TarifaId");

            migrationBuilder.CreateIndex(
                name: "IX_TarifasDetalle_PuntoDestinoId",
                table: "TarifasDetalle",
                column: "PuntoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_TarifasDetalle_PuntoOrigenId",
                table: "TarifasDetalle",
                column: "PuntoOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_TarifasDetalle_TarifaId",
                table: "TarifasDetalle",
                column: "TarifaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarifas_Tarifas_TarifaId",
                table: "Tarifas",
                column: "TarifaId",
                principalTable: "Tarifas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarifas_Tarifas_TarifaId",
                table: "Tarifas");

            migrationBuilder.DropTable(
                name: "TarifasDetalle");

            migrationBuilder.DropIndex(
                name: "IX_Tarifas_TarifaId",
                table: "Tarifas");

            migrationBuilder.DropColumn(
                name: "TarifaId",
                table: "Tarifas");
        }
    }
}
