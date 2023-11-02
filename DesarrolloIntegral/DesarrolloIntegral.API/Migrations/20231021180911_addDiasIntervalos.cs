using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addDiasIntervalos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Domingo",
                table: "Intervalos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Jueves",
                table: "Intervalos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Lunes",
                table: "Intervalos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Martes",
                table: "Intervalos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Miercoles",
                table: "Intervalos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sabado",
                table: "Intervalos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Viernes",
                table: "Intervalos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Domingo",
                table: "Intervalos");

            migrationBuilder.DropColumn(
                name: "Jueves",
                table: "Intervalos");

            migrationBuilder.DropColumn(
                name: "Lunes",
                table: "Intervalos");

            migrationBuilder.DropColumn(
                name: "Martes",
                table: "Intervalos");

            migrationBuilder.DropColumn(
                name: "Miercoles",
                table: "Intervalos");

            migrationBuilder.DropColumn(
                name: "Sabado",
                table: "Intervalos");

            migrationBuilder.DropColumn(
                name: "Viernes",
                table: "Intervalos");
        }
    }
}
