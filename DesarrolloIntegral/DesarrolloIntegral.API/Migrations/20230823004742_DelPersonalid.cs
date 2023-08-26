using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class DelPersonalid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itinerarios_Personal_PersonalId",
                table: "Itinerarios");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "Itinerarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "Itinerarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Itinerarios_Personal_PersonalId",
                table: "Itinerarios",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id");
        }
    }
}
