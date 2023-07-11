using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addPuntos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuntoRecorrido_Lineas_LineaId",
                table: "PuntoRecorrido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PuntoRecorrido",
                table: "PuntoRecorrido");

            migrationBuilder.DropIndex(
                name: "IX_PuntoRecorrido_LineaId",
                table: "PuntoRecorrido");

            migrationBuilder.DropColumn(
                name: "LineaId",
                table: "PuntoRecorrido");

            migrationBuilder.RenameTable(
                name: "PuntoRecorrido",
                newName: "Puntos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puntos",
                table: "Puntos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Puntos_Nombre",
                table: "Puntos",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Puntos",
                table: "Puntos");

            migrationBuilder.DropIndex(
                name: "IX_Puntos_Nombre",
                table: "Puntos");

            migrationBuilder.RenameTable(
                name: "Puntos",
                newName: "PuntoRecorrido");

            migrationBuilder.AddColumn<int>(
                name: "LineaId",
                table: "PuntoRecorrido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PuntoRecorrido",
                table: "PuntoRecorrido",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoRecorrido_LineaId",
                table: "PuntoRecorrido",
                column: "LineaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PuntoRecorrido_Lineas_LineaId",
                table: "PuntoRecorrido",
                column: "LineaId",
                principalTable: "Lineas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
