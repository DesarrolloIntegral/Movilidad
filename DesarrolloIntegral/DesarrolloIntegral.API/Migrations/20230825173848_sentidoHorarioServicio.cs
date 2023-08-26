using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloIntegral.API.Migrations
{
    /// <inheritdoc />
    public partial class sentidoHorarioServicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Bancos_BancoId",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_DescuentosDetalles_Descuentos_DescuentoId",
                table: "DescuentosDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_DescuentosDetalles_Lineas_LineaId",
                table: "DescuentosDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_DescuentosOrigenDestino_DescuentosDetalles_DescuentoDetalleId",
                table: "DescuentosOrigenDestino");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioServicios_Itinerarios_ItinerarioId",
                table: "HorarioServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioServicios_Trayectos_TrayectoId",
                table: "HorarioServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Itinerarios_Rutas_RutaId",
                table: "Itinerarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_Puestos_PuestoId",
                table: "Personal");

            migrationBuilder.DropForeignKey(
                name: "FK_Rutas_Lineas_LineaId",
                table: "Rutas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarifas_Lineas_LineaId",
                table: "Tarifas");

            migrationBuilder.DropForeignKey(
                name: "FK_TarifasDetalle_Tarifas_TarifaId",
                table: "TarifasDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Trayectos_Puntos_PuntoId",
                table: "Trayectos");

            migrationBuilder.DropForeignKey(
                name: "FK_Trayectos_Rutas_RutaId",
                table: "Trayectos");

            migrationBuilder.DropForeignKey(
                name: "FK_UnidadOperadores_Lineas_LineaId",
                table: "UnidadOperadores");

            migrationBuilder.DropForeignKey(
                name: "FK_UnidadOperadores_Personal_PersonalId",
                table: "UnidadOperadores");

            migrationBuilder.DropForeignKey(
                name: "FK_UnidadOperadores_Unidades_UnidadId",
                table: "UnidadOperadores");

            migrationBuilder.AddColumn<int>(
                name: "Sentido",
                table: "HorarioServicios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Bancos_BancoId",
                table: "Cuentas",
                column: "BancoId",
                principalTable: "Bancos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DescuentosDetalles_Descuentos_DescuentoId",
                table: "DescuentosDetalles",
                column: "DescuentoId",
                principalTable: "Descuentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DescuentosDetalles_Lineas_LineaId",
                table: "DescuentosDetalles",
                column: "LineaId",
                principalTable: "Lineas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DescuentosOrigenDestino_DescuentosDetalles_DescuentoDetalleId",
                table: "DescuentosOrigenDestino",
                column: "DescuentoDetalleId",
                principalTable: "DescuentosDetalles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioServicios_Itinerarios_ItinerarioId",
                table: "HorarioServicios",
                column: "ItinerarioId",
                principalTable: "Itinerarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioServicios_Trayectos_TrayectoId",
                table: "HorarioServicios",
                column: "TrayectoId",
                principalTable: "Trayectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Itinerarios_Rutas_RutaId",
                table: "Itinerarios",
                column: "RutaId",
                principalTable: "Rutas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_Puestos_PuestoId",
                table: "Personal",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Rutas_Lineas_LineaId",
                table: "Rutas",
                column: "LineaId",
                principalTable: "Lineas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarifas_Lineas_LineaId",
                table: "Tarifas",
                column: "LineaId",
                principalTable: "Lineas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TarifasDetalle_Tarifas_TarifaId",
                table: "TarifasDetalle",
                column: "TarifaId",
                principalTable: "Tarifas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trayectos_Puntos_PuntoId",
                table: "Trayectos",
                column: "PuntoId",
                principalTable: "Puntos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trayectos_Rutas_RutaId",
                table: "Trayectos",
                column: "RutaId",
                principalTable: "Rutas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadOperadores_Lineas_LineaId",
                table: "UnidadOperadores",
                column: "LineaId",
                principalTable: "Lineas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadOperadores_Personal_PersonalId",
                table: "UnidadOperadores",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadOperadores_Unidades_UnidadId",
                table: "UnidadOperadores",
                column: "UnidadId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Bancos_BancoId",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_DescuentosDetalles_Descuentos_DescuentoId",
                table: "DescuentosDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_DescuentosDetalles_Lineas_LineaId",
                table: "DescuentosDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_DescuentosOrigenDestino_DescuentosDetalles_DescuentoDetalleId",
                table: "DescuentosOrigenDestino");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioServicios_Itinerarios_ItinerarioId",
                table: "HorarioServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioServicios_Trayectos_TrayectoId",
                table: "HorarioServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Itinerarios_Rutas_RutaId",
                table: "Itinerarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_Puestos_PuestoId",
                table: "Personal");

            migrationBuilder.DropForeignKey(
                name: "FK_Rutas_Lineas_LineaId",
                table: "Rutas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarifas_Lineas_LineaId",
                table: "Tarifas");

            migrationBuilder.DropForeignKey(
                name: "FK_TarifasDetalle_Tarifas_TarifaId",
                table: "TarifasDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Trayectos_Puntos_PuntoId",
                table: "Trayectos");

            migrationBuilder.DropForeignKey(
                name: "FK_Trayectos_Rutas_RutaId",
                table: "Trayectos");

            migrationBuilder.DropForeignKey(
                name: "FK_UnidadOperadores_Lineas_LineaId",
                table: "UnidadOperadores");

            migrationBuilder.DropForeignKey(
                name: "FK_UnidadOperadores_Personal_PersonalId",
                table: "UnidadOperadores");

            migrationBuilder.DropForeignKey(
                name: "FK_UnidadOperadores_Unidades_UnidadId",
                table: "UnidadOperadores");

            migrationBuilder.DropColumn(
                name: "Sentido",
                table: "HorarioServicios");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Bancos_BancoId",
                table: "Cuentas",
                column: "BancoId",
                principalTable: "Bancos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DescuentosDetalles_Descuentos_DescuentoId",
                table: "DescuentosDetalles",
                column: "DescuentoId",
                principalTable: "Descuentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DescuentosDetalles_Lineas_LineaId",
                table: "DescuentosDetalles",
                column: "LineaId",
                principalTable: "Lineas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DescuentosOrigenDestino_DescuentosDetalles_DescuentoDetalleId",
                table: "DescuentosOrigenDestino",
                column: "DescuentoDetalleId",
                principalTable: "DescuentosDetalles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioServicios_Itinerarios_ItinerarioId",
                table: "HorarioServicios",
                column: "ItinerarioId",
                principalTable: "Itinerarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioServicios_Trayectos_TrayectoId",
                table: "HorarioServicios",
                column: "TrayectoId",
                principalTable: "Trayectos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Itinerarios_Rutas_RutaId",
                table: "Itinerarios",
                column: "RutaId",
                principalTable: "Rutas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_Puestos_PuestoId",
                table: "Personal",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutas_Lineas_LineaId",
                table: "Rutas",
                column: "LineaId",
                principalTable: "Lineas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarifas_Lineas_LineaId",
                table: "Tarifas",
                column: "LineaId",
                principalTable: "Lineas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TarifasDetalle_Tarifas_TarifaId",
                table: "TarifasDetalle",
                column: "TarifaId",
                principalTable: "Tarifas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trayectos_Puntos_PuntoId",
                table: "Trayectos",
                column: "PuntoId",
                principalTable: "Puntos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trayectos_Rutas_RutaId",
                table: "Trayectos",
                column: "RutaId",
                principalTable: "Rutas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadOperadores_Lineas_LineaId",
                table: "UnidadOperadores",
                column: "LineaId",
                principalTable: "Lineas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadOperadores_Personal_PersonalId",
                table: "UnidadOperadores",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadOperadores_Unidades_UnidadId",
                table: "UnidadOperadores",
                column: "UnidadId",
                principalTable: "Unidades",
                principalColumn: "Id");
        }
    }
}
