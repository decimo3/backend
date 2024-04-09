using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class DiasUteisTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "referencia",
                table: "feriado",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "dias_uteis",
                columns: table => new
                {
                    identificador = table.Column<int>(type: "integer", nullable: false),
                    referencia = table.Column<DateOnly>(type: "date", nullable: false),
                    dias_uteis = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dias_uteis", x => x.identificador);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dias_uteis");

            migrationBuilder.DropColumn(
                name: "referencia",
                table: "feriado");
        }
    }
}
