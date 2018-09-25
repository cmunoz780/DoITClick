using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doitclick.Data.Migrations
{
    public partial class AgregarLogicaSolicitudProdMensual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolicitudMaterialesMensuales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Solicitante = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaSolicitud = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    MotivoRechazo = table.Column<string>(nullable: true),
                    FechaCierre = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudMaterialesMensuales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleSolicitudesMaterialesMensuales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaterialMensualId = table.Column<int>(nullable: true),
                    SolicitudMaterialMensualId = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleSolicitudesMaterialesMensuales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleSolicitudesMaterialesMensuales_MaterialesMensuales_Ma~",
                        column: x => x.MaterialMensualId,
                        principalTable: "MaterialesMensuales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleSolicitudesMaterialesMensuales_SolicitudMaterialesMen~",
                        column: x => x.SolicitudMaterialMensualId,
                        principalTable: "SolicitudMaterialesMensuales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitudesMaterialesMensuales_MaterialMensualId",
                table: "DetalleSolicitudesMaterialesMensuales",
                column: "MaterialMensualId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitudesMaterialesMensuales_SolicitudMaterialMensu~",
                table: "DetalleSolicitudesMaterialesMensuales",
                column: "SolicitudMaterialMensualId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleSolicitudesMaterialesMensuales");

            migrationBuilder.DropTable(
                name: "SolicitudMaterialesMensuales");
        }
    }
}
