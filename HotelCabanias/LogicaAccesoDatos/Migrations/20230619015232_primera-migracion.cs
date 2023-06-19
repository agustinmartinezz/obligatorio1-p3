using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class primeramigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "List<string>",
                columns: table => new
                {
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TipoCabanias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_TextoNombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCabanias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_TextoNombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mail_TextoMail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cabanias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Nombre_TextoNombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieneJacuzzi = table.Column<bool>(type: "bit", nullable: false),
                    HabilitadaReservas = table.Column<bool>(type: "bit", nullable: false),
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: false),
                    MaxPersonas = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabanias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cabanias_TipoCabanias_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoCabanias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreRealizo_TextoNombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CabaniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Cabanias_CabaniaId",
                        column: x => x.CabaniaId,
                        principalTable: "Cabanias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_Nombre_TextoNombre",
                table: "Cabanias",
                column: "Nombre_TextoNombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cabanias_TipoId",
                table: "Cabanias",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_CabaniaId",
                table: "Mantenimientos",
                column: "CabaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_NombreRealizo_TextoNombre",
                table: "Mantenimientos",
                column: "NombreRealizo_TextoNombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoCabanias_Nombre_TextoNombre",
                table: "TipoCabanias",
                column: "Nombre_TextoNombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Mail_TextoMail",
                table: "Usuarios",
                column: "Mail_TextoMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Nombre_TextoNombre",
                table: "Usuarios",
                column: "Nombre_TextoNombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "List<string>");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cabanias");

            migrationBuilder.DropTable(
                name: "TipoCabanias");
        }
    }
}
