using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addPerfiles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Perfiles",
                table: "Perfiles");

            migrationBuilder.RenameTable(
                name: "Perfiles",
                newName: "PerfilesUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Perfiles_Nombre",
                table: "PerfilesUsuario",
                newName: "IX_PerfilesUsuario_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfilesUsuario",
                table: "PerfilesUsuario",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfilesUsuario",
                table: "PerfilesUsuario");

            migrationBuilder.RenameTable(
                name: "PerfilesUsuario",
                newName: "Perfiles");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilesUsuario_Nombre",
                table: "Perfiles",
                newName: "IX_Perfiles_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perfiles",
                table: "Perfiles",
                column: "Id");
        }
    }
}
