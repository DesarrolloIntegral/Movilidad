using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class PrecioTarifa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "TarifasDetalle",
                newName: "Id");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "TarifasDetalle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "TarifasDetalle");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TarifasDetalle",
                newName: "id");
        }
    }
}
