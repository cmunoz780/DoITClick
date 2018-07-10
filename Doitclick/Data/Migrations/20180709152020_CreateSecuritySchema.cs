using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doitclick.Data.Migrations
{
    public partial class CreateSecuritySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Tabla Organizacion
            migrationBuilder.CreateTable(
                name: "Organizacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("MySQL:AutoIncrement", true),
                    OrganizacionPadreId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKOrganizacion", x => x.Id);
                }
            );
            #endregion

            #region Tabla Rol
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("MySQL:AutoIncrement", true),
                    RolPadreId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(nullable: false),
                    OrganizacionId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKRol", x => x.Id);
                    table.ForeignKey(
                        name: "FKRolesOrganizacion",
                        column: x => x.OrganizacionId,
                        principalTable: "Organizacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );
            #endregion
            
            #region Tabla Usuario
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("MySQL:AutoIncrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Clave = table.Column<string>(nullable: false),
                    EstadoCuenta = table.Column<string>(nullable: false),
                    TokenRecuerdaAcceso = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKUsuario", x => x.Id);
                }
            );
            #endregion

            #region Tabla UsuarioRoles
            migrationBuilder.CreateTable(
                name: "UsuarioRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("MySQL:AutoIncrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    RolId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKUsuarioRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FKUsuarioRoles_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FKUsuarioRoles_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            #endregion

            #region Tabla UsuarioTokens
            migrationBuilder.CreateTable(
                name: "UsuarioTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("MySQL:AutoIncrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Valor = table.Column<string>(nullable: false),
                    CreadoEn = table.Column<DateTime>(nullable: false),
                    ExpiraEn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKUsuarioTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FKUsuarioTokens_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );
            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Organizacion");

            migrationBuilder.DropTable(name: "Rol");

            migrationBuilder.DropTable(name: "Usuario");

            migrationBuilder.DropTable(name: "UsuarioRoles");

            migrationBuilder.DropTable(name: "UsuarioTokens");
        }
    }
}
