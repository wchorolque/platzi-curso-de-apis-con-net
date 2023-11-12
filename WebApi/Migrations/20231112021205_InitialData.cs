using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Tarea_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c01"), null, "Actividades Pendientes", 20 },
                    { new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c02"), null, "Actividades Personales", 40 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { new Guid("3ca96d4d-5b31-4637-a9e6-752395e97f01"), new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c01"), null, new DateTime(2023, 11, 11, 22, 12, 5, 546, DateTimeKind.Local).AddTicks(7937), 1, "Pago de servicios públicos" },
                    { new Guid("3ca96d4d-5b31-4637-a9e6-752395e97f02"), new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c01"), null, new DateTime(2023, 11, 11, 22, 12, 5, 546, DateTimeKind.Local).AddTicks(7982), 0, "Compra de productos" },
                    { new Guid("3ca96d4d-5b31-4637-a9e6-752395e97f03"), new Guid("3ca96d4d-5b31-4637-a9e6-752395e97c02"), null, new DateTime(2023, 11, 11, 22, 12, 5, 546, DateTimeKind.Local).AddTicks(7987), 1, "Terminar de ver series" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
