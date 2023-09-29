using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addUnidadevento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnidadId",
                table: "EventosViaje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventosViaje_UnidadId",
                table: "EventosViaje",
                column: "UnidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosViaje_Unidades_UnidadId",
                table: "EventosViaje",
                column: "UnidadId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosViaje_Unidades_UnidadId",
                table: "EventosViaje");

            migrationBuilder.DropIndex(
                name: "IX_EventosViaje_UnidadId",
                table: "EventosViaje");

            migrationBuilder.DropColumn(
                name: "UnidadId",
                table: "EventosViaje");
        }
    }
}
