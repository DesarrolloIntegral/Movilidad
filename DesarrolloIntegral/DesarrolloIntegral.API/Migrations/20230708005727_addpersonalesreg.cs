using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addpersonalesreg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personales_Puestos_PuestoId",
                table: "Personales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personales",
                table: "Personales");

            migrationBuilder.RenameTable(
                name: "Personales",
                newName: "Personal");

            migrationBuilder.RenameIndex(
                name: "IX_Personales_PuestoId",
                table: "Personal",
                newName: "IX_Personal_PuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_Personales_Nombre",
                table: "Personal",
                newName: "IX_Personal_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personal",
                table: "Personal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_Puestos_PuestoId",
                table: "Personal",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personal_Puestos_PuestoId",
                table: "Personal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personal",
                table: "Personal");

            migrationBuilder.RenameTable(
                name: "Personal",
                newName: "Personales");

            migrationBuilder.RenameIndex(
                name: "IX_Personal_PuestoId",
                table: "Personales",
                newName: "IX_Personales_PuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_Personal_Nombre",
                table: "Personales",
                newName: "IX_Personales_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personales",
                table: "Personales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personales_Puestos_PuestoId",
                table: "Personales",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
