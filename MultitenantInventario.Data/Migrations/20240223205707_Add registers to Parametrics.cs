using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MultitenantInventario.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddregisterstoParametrics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ManufactureTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Elaborado a mano" },
                    { 2, "Elaborado a mano y máquina" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Nuevo" },
                    { 2, "Defectuoso" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ManufactureTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ManufactureTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
