using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addlineas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Linea",
                table: "Linea");

            migrationBuilder.RenameTable(
                name: "Linea",
                newName: "Lineas");

            migrationBuilder.RenameIndex(
                name: "IX_Linea_Nombre",
                table: "Lineas",
                newName: "IX_Lineas_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lineas",
                table: "Lineas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lineas",
                table: "Lineas");

            migrationBuilder.RenameTable(
                name: "Lineas",
                newName: "Linea");

            migrationBuilder.RenameIndex(
                name: "IX_Lineas_Nombre",
                table: "Linea",
                newName: "IX_Linea_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Linea",
                table: "Linea",
                column: "Id");
        }
    }
}
