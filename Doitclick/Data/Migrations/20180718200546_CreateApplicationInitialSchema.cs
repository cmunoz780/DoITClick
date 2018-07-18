using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doitclick.Data.Migrations
{
    public partial class CreateApplicationInitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialDisponible",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    UnidadMedida = table.Column<int>(nullable: false),
                    PrecioUnidad = table.Column<int>(nullable: false),
                    StockAlerta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialDisponible", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    TipoOrganizacion = table.Column<string>(nullable: false),
                    PadreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizaciones_Organizaciones_PadreId",
                        column: x => x.PadreId,
                        principalTable: "Organizaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrevisionSalud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisionSalud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    NombreInterno = table.Column<string>(nullable: true),
                    NamespaceGeneraTickets = table.Column<string>(nullable: true),
                    ClaseGeneraTickets = table.Column<string>(nullable: true),
                    MetodoGeneraTickets = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Resumen = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    ValorManoObra = table.Column<int>(nullable: false),
                    ValorMateriales = table.Column<int>(nullable: false),
                    ValorComision = table.Column<int>(nullable: false),
                    PorcentajeComision = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Identificador = table.Column<string>(nullable: true),
                    EstadoCuenta = table.Column<int>(nullable: false),
                    TokenRecuerdaAcceso = table.Column<string>(nullable: true),
                    Eliminado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoMaterialDisponoble",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroTransaccion = table.Column<string>(nullable: true),
                    TipoTransaccion = table.Column<int>(nullable: false),
                    MaterialDisponibleId = table.Column<int>(nullable: true),
                    FechaTransaccion = table.Column<DateTime>(nullable: false),
                    Resumen = table.Column<string>(nullable: true),
                    CantidadMaterial = table.Column<int>(nullable: false),
                    NumeroTicket = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoMaterialDisponoble", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoMaterialDisponoble_MaterialDisponible_MaterialDisp~",
                        column: x => x.MaterialDisponibleId,
                        principalTable: "MaterialDisponible",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    OrzanizacionId = table.Column<int>(nullable: false),
                    PadreId = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Organizaciones_OrzanizacionId",
                        column: x => x.OrzanizacionId,
                        principalTable: "Organizaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roles_Roles_PadreId",
                        column: x => x.PadreId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rut = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    TipoCliente = table.Column<int>(nullable: false),
                    EsPersonalidadJuridica = table.Column<bool>(nullable: false),
                    PrevisionSaludId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_PrevisionSalud_PrevisionSaludId",
                        column: x => x.PrevisionSaludId,
                        principalTable: "PrevisionSalud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etapas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProcesoId = table.Column<int>(nullable: false),
                    TipoEtapa = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    NombreInterno = table.Column<string>(nullable: true),
                    TipoUsuarioAsignado = table.Column<string>(nullable: false),
                    ValorUsuarioAsignado = table.Column<string>(nullable: false),
                    TipoDuracion = table.Column<string>(nullable: true),
                    ValorDuracion = table.Column<string>(nullable: true),
                    TipoDuracionRetardo = table.Column<int>(nullable: true),
                    ValorDuracionRetardo = table.Column<string>(nullable: true),
                    Secuencia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etapas_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroTicket = table.Column<string>(nullable: false),
                    ProcesoId = table.Column<int>(nullable: true),
                    Resumen = table.Column<string>(nullable: true),
                    InstanciadoPor = table.Column<string>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaTermino = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialPresupuestado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServicioId = table.Column<int>(nullable: true),
                    MaterialDisponibleId = table.Column<int>(nullable: true),
                    CantidadMaterial = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialPresupuestado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialPresupuestado_MaterialDisponible_MaterialDisponibleId",
                        column: x => x.MaterialDisponibleId,
                        principalTable: "MaterialDisponible",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialPresupuestado_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccesosUsuarios",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesosUsuarios", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AccesosUsuarios_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReclamosUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamosUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReclamosUsuarios_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TokensUsuarios",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokensUsuarios", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_TokensUsuarios_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReclamosRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamosRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReclamosRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesUsuarios",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuarios", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoContacto = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    Resumen = table.Column<string>(nullable: true),
                    EsPrincipal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacto_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaExpiracion = table.Column<DateTime>(nullable: false),
                    NumeroTicket = table.Column<string>(nullable: true),
                    Resumen = table.Column<string>(nullable: true),
                    PrecioCotizacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cotizacion_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuentaCorriente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaCorriente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentaCorriente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetaDatosCliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: true),
                    Clave = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaDatosCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaDatosCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TareaAutomatica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EtapaId = table.Column<int>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    EventoDisparador = table.Column<int>(nullable: false),
                    Namespace = table.Column<string>(nullable: true),
                    Clase = table.Column<string>(nullable: true),
                    Metodo = table.Column<string>(nullable: true),
                    Secuencia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareaAutomatica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TareaAutomatica_Etapas_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transiciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EtapaActaualId = table.Column<int>(nullable: false),
                    EtapaDestinoId = table.Column<int>(nullable: false),
                    NamespaceValidacion = table.Column<string>(nullable: true),
                    ClaseValidacion = table.Column<string>(nullable: true),
                    MetodoValidacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transiciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transiciones_Etapas_EtapaActaualId",
                        column: x => x.EtapaActaualId,
                        principalTable: "Etapas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transiciones_Etapas_EtapaDestinoId",
                        column: x => x.EtapaDestinoId,
                        principalTable: "Etapas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SolicitudId = table.Column<int>(nullable: false),
                    EtapaId = table.Column<int>(nullable: true),
                    AsignadoA = table.Column<string>(nullable: true),
                    ReasignadoA = table.Column<string>(nullable: true),
                    EjecutadoPor = table.Column<string>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaTerminoEstimada = table.Column<DateTime>(nullable: true),
                    FechaTerminoFinal = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tareas_Etapas_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tareas_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetaDatosContacto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContactoId = table.Column<int>(nullable: true),
                    Clave = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaDatosContacto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaDatosContacto_Contacto_ContactoId",
                        column: x => x.ContactoId,
                        principalTable: "Contacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCotizar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CotizacionId = table.Column<int>(nullable: true),
                    ServicioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCotizar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCotizar_Cotizacion_CotizacionId",
                        column: x => x.CotizacionId,
                        principalTable: "Cotizacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCotizar_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoCuentaCorriente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoTransanccion = table.Column<int>(nullable: false),
                    CuentaCorrienteId = table.Column<int>(nullable: true),
                    NumeroTransaccion = table.Column<string>(nullable: true),
                    FechaTransaccion = table.Column<DateTime>(nullable: false),
                    MontoTransaccion = table.Column<long>(nullable: false),
                    Resumen = table.Column<string>(nullable: true),
                    NumeroDocumento = table.Column<string>(nullable: true),
                    NumeroTicket = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoCuentaCorriente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoCuentaCorriente_CuentaCorriente_CuentaCorrienteId",
                        column: x => x.CuentaCorrienteId,
                        principalTable: "CuentaCorriente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccesosUsuarios_UserId",
                table: "AccesosUsuarios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PrevisionSaludId",
                table: "Cliente",
                column: "PrevisionSaludId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_ClienteId",
                table: "Contacto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_ClienteId",
                table: "Cotizacion",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCorriente_ClienteId",
                table: "CuentaCorriente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Etapas_ProcesoId",
                table: "Etapas",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCotizar_CotizacionId",
                table: "ItemCotizar",
                column: "CotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCotizar_ServicioId",
                table: "ItemCotizar",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPresupuestado_MaterialDisponibleId",
                table: "MaterialPresupuestado",
                column: "MaterialDisponibleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPresupuestado_ServicioId",
                table: "MaterialPresupuestado",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaDatosCliente_ClienteId",
                table: "MetaDatosCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaDatosContacto_ContactoId",
                table: "MetaDatosContacto",
                column: "ContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCuentaCorriente_CuentaCorrienteId",
                table: "MovimientoCuentaCorriente",
                column: "CuentaCorrienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoMaterialDisponoble_MaterialDisponibleId",
                table: "MovimientoMaterialDisponoble",
                column: "MaterialDisponibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizaciones_PadreId",
                table: "Organizaciones",
                column: "PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamosRoles_RoleId",
                table: "ReclamosRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamosUsuarios_UserId",
                table: "ReclamosUsuarios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_OrzanizacionId",
                table: "Roles",
                column: "OrzanizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PadreId",
                table: "Roles",
                column: "PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuarios_RoleId",
                table: "RolesUsuarios",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_InstanciadoPor",
                table: "Solicitudes",
                column: "InstanciadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_NumeroTicket",
                table: "Solicitudes",
                column: "NumeroTicket",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_ProcesoId",
                table: "Solicitudes",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_TareaAutomatica_EtapaId",
                table: "TareaAutomatica",
                column: "EtapaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_EtapaId",
                table: "Tareas",
                column: "EtapaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_SolicitudId",
                table: "Tareas",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Transiciones_EtapaActaualId",
                table: "Transiciones",
                column: "EtapaActaualId");

            migrationBuilder.CreateIndex(
                name: "IX_Transiciones_EtapaDestinoId",
                table: "Transiciones",
                column: "EtapaDestinoId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Usuarios",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Usuarios",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccesosUsuarios");

            migrationBuilder.DropTable(
                name: "ItemCotizar");

            migrationBuilder.DropTable(
                name: "MaterialPresupuestado");

            migrationBuilder.DropTable(
                name: "MetaDatosCliente");

            migrationBuilder.DropTable(
                name: "MetaDatosContacto");

            migrationBuilder.DropTable(
                name: "MovimientoCuentaCorriente");

            migrationBuilder.DropTable(
                name: "MovimientoMaterialDisponoble");

            migrationBuilder.DropTable(
                name: "ReclamosRoles");

            migrationBuilder.DropTable(
                name: "ReclamosUsuarios");

            migrationBuilder.DropTable(
                name: "RolesUsuarios");

            migrationBuilder.DropTable(
                name: "TareaAutomatica");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "TokensUsuarios");

            migrationBuilder.DropTable(
                name: "Transiciones");

            migrationBuilder.DropTable(
                name: "Cotizacion");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "CuentaCorriente");

            migrationBuilder.DropTable(
                name: "MaterialDisponible");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Etapas");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Organizaciones");

            migrationBuilder.DropTable(
                name: "Procesos");

            migrationBuilder.DropTable(
                name: "PrevisionSalud");
        }
    }
}
