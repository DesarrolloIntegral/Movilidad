using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addpersonal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Puestos_Nombre",
                table: "Puestos");

            migrationBuilder.DropIndex(
                name: "IX_PerfilesUsuario_Nombre",
                table: "PerfilesUsuario");

            migrationBuilder.RenameColumn(
                name: "NombreBanco",
                table: "Bancos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "EstadoBanco",
                table: "Bancos",
                newName: "Estado");

            migrationBuilder.RenameIndex(
                name: "IX_Bancos_NombreBanco",
                table: "Bancos",
                newName: "IX_Bancos_Nombre");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Puestos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "PerfilesUsuario",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    PuestoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personal_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Nombre",
                table: "Puestos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesUsuario_Nombre",
                table: "PerfilesUsuario",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personal_PuestoId",
                table: "Personal",
                column: "PuestoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropIndex(
                name: "IX_Puestos_Nombre",
                table: "Puestos");

            migrationBuilder.DropIndex(
                name: "IX_PerfilesUsuario_Nombre",
                table: "PerfilesUsuario");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Bancos",
                newName: "NombreBanco");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Bancos",
                newName: "EstadoBanco");

            migrationBuilder.RenameIndex(
                name: "IX_Bancos_Nombre",
                table: "Bancos",
                newName: "IX_Bancos_NombreBanco");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Puestos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "PerfilesUsuario",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Nombre",
                table: "Puestos",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesUsuario_Nombre",
                table: "PerfilesUsuario",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");
        }
    }
}
