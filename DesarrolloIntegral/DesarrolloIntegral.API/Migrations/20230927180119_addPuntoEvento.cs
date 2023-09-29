using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addPuntoEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PuntoRecorridoId",
                table: "EventosViaje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventosViaje_PuntoRecorridoId",
                table: "EventosViaje",
                column: "PuntoRecorridoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosViaje_Puntos_PuntoRecorridoId",
                table: "EventosViaje",
                column: "PuntoRecorridoId",
                principalTable: "Puntos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosViaje_Puntos_PuntoRecorridoId",
                table: "EventosViaje");

            migrationBuilder.DropIndex(
                name: "IX_EventosViaje_PuntoRecorridoId",
                table: "EventosViaje");

            migrationBuilder.DropColumn(
                name: "PuntoRecorridoId",
                table: "EventosViaje");
        }
    }
}
