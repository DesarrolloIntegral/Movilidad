using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTiempos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiempoRecorridos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Minutos = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    HorarioServicioId = table.Column<int>(type: "int", nullable: false),
                    TrayectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiempoRecorridos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiempoRecorridos_HorarioServicios_HorarioServicioId",
                        column: x => x.HorarioServicioId,
                        principalTable: "HorarioServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TiempoRecorridos_Trayectos_TrayectoId",
                        column: x => x.TrayectoId,
                        principalTable: "Trayectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TiempoRecorridos_HorarioServicioId",
                table: "TiempoRecorridos",
                column: "HorarioServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_TiempoRecorridos_TrayectoId",
                table: "TiempoRecorridos",
                column: "TrayectoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiempoRecorridos");
        }
    }
}
