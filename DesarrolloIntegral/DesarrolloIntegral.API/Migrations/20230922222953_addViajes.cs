using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class addViajes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRecorrido = table.Column<int>(type: "int", nullable: false),
                    KmsRecorrido = table.Column<int>(type: "int", nullable: false),
                    Sentido = table.Column<int>(type: "int", nullable: false),
                    FechaCaptura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraOficial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Operador1Id = table.Column<int>(type: "int", nullable: false),
                    Operador2Id = table.Column<int>(type: "int", nullable: false),
                    RolesDiariosId = table.Column<int>(type: "int", nullable: false),
                    UnidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viajes_Personal_Operador1Id",
                        column: x => x.Operador1Id,
                        principalTable: "Personal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viajes_Personal_Operador2Id",
                        column: x => x.Operador2Id,
                        principalTable: "Personal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viajes_RolesDiarios_RolesDiariosId",
                        column: x => x.RolesDiariosId,
                        principalTable: "RolesDiarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Viajes_Unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_Operador1Id",
                table: "Viajes",
                column: "Operador1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_Operador2Id",
                table: "Viajes",
                column: "Operador2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_RolesDiariosId",
                table: "Viajes",
                column: "RolesDiariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_UnidadId",
                table: "Viajes",
                column: "UnidadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viajes");
        }
    }
}
