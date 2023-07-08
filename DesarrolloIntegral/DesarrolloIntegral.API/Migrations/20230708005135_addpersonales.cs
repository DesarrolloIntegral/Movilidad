using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addpersonales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Puestos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personales",
                table: "Personales",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personales_Nombre",
                table: "Personales",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personales_Puestos_PuestoId",
                table: "Personales",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personales_Puestos_PuestoId",
                table: "Personales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personales",
                table: "Personales");

            migrationBuilder.DropIndex(
                name: "IX_Personales_Nombre",
                table: "Personales");

            migrationBuilder.RenameTable(
                name: "Personales",
                newName: "Personal");

            migrationBuilder.RenameIndex(
                name: "IX_Personales_PuestoId",
                table: "Personal",
                newName: "IX_Personal_PuestoId");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Puestos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
    }
}
