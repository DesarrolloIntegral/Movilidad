using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class delHorarioTiempo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiempoRecorridos_HorarioServicios_HorarioServicioId",
                table: "TiempoRecorridos");

            migrationBuilder.DropIndex(
                name: "IX_TiempoRecorridos_HorarioServicioId",
                table: "TiempoRecorridos");

            migrationBuilder.RenameColumn(
                name: "HorarioServicioId",
                table: "TiempoRecorridos",
                newName: "Sentido");

            migrationBuilder.AddColumn<int>(
                name: "ItinerarioId",
                table: "TiempoRecorridos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TiempoRecorridos_ItinerarioId",
                table: "TiempoRecorridos",
                column: "ItinerarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TiempoRecorridos_Itinerarios_ItinerarioId",
                table: "TiempoRecorridos",
                column: "ItinerarioId",
                principalTable: "Itinerarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiempoRecorridos_Itinerarios_ItinerarioId",
                table: "TiempoRecorridos");

            migrationBuilder.DropIndex(
                name: "IX_TiempoRecorridos_ItinerarioId",
                table: "TiempoRecorridos");

            migrationBuilder.DropColumn(
                name: "ItinerarioId",
                table: "TiempoRecorridos");

            migrationBuilder.RenameColumn(
                name: "Sentido",
                table: "TiempoRecorridos",
                newName: "HorarioServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_TiempoRecorridos_HorarioServicioId",
                table: "TiempoRecorridos",
                column: "HorarioServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TiempoRecorridos_HorarioServicios_HorarioServicioId",
                table: "TiempoRecorridos",
                column: "HorarioServicioId",
                principalTable: "HorarioServicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
