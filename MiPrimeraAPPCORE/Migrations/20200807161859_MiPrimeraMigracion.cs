using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiPrimeraAPPCORE.Migrations
{
    public partial class MiPrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cat");

            migrationBuilder.CreateTable(
                name: "Categoria",
                schema: "Cat",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria",
                schema: "Cat");
        }
    }
}
