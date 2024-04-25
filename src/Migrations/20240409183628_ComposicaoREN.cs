using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class ComposicaoREN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "controlador",
                table: "composicao",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_controlador",
                table: "composicao",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "justificada",
                table: "composicao",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "setor",
                table: "composicao",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "situacao",
                table: "composicao",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tecnico",
                table: "composicao",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "controlador",
                table: "composicao");

            migrationBuilder.DropColumn(
                name: "id_controlador",
                table: "composicao");

            migrationBuilder.DropColumn(
                name: "justificada",
                table: "composicao");

            migrationBuilder.DropColumn(
                name: "setor",
                table: "composicao");

            migrationBuilder.DropColumn(
                name: "situacao",
                table: "composicao");

            migrationBuilder.DropColumn(
                name: "tecnico",
                table: "composicao");
        }
    }
}
