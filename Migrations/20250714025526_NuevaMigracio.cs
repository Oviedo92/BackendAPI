using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppApi.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id_admin_pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S_apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identif_cuenta = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id_admin_pk);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id_empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIT_empresa = table.Column<int>(type: "int", nullable: false),
                    Fecha_origen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Correo_empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña_empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interes_empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion_Empres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono_empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais_empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad_empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cod_ref_empresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id_empresa);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id_persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cc_id_usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S_apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Despc_interes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_perfil_persona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cod_ref_usuario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id_persona);
                });

            migrationBuilder.CreateTable(
                name: "ReporteEmpresa",
                columns: table => new
                {
                    Id_reporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tematica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres_apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nomb_ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion_queja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cod_ref_empresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteEmpresa", x => x.Id_reporte);
                });

            migrationBuilder.CreateTable(
                name: "ReporteUsuario",
                columns: table => new
                {
                    Id_reporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tematica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres_apellidos_u = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular_u = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo_u = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nomb_ciudad_u = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion_queja_u = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cod_ref_usuario_u = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteUsuario", x => x.Id_reporte);
                });

            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    Id_inmueble = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Contacto_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identif_cuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_admin_pk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.Id_inmueble);
                    table.ForeignKey(
                        name: "FK_Inmuebles_Administrador_Id_admin_pk",
                        column: x => x.Id_admin_pk,
                        principalTable: "Administrador",
                        principalColumn: "Id_admin_pk");
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id_direccion_pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ubi_pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubi_dire_ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id_direccion_pk);
                    table.ForeignKey(
                        name: "FK_Direccion_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id_persona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_Identif_cuenta",
                table: "Administrador",
                column: "Identif_cuenta",
                unique: true,
                filter: "[Identif_cuenta] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_PersonaId",
                table: "Direccion",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmuebles_Id_admin_pk",
                table: "Inmuebles",
                column: "Id_admin_pk");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteUsuario_Cod_ref_usuario_u",
                table: "ReporteUsuario",
                column: "Cod_ref_usuario_u",
                unique: true,
                filter: "[Cod_ref_usuario_u] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Inmuebles");

            migrationBuilder.DropTable(
                name: "ReporteEmpresa");

            migrationBuilder.DropTable(
                name: "ReporteUsuario");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Administrador");
        }
    }
}
