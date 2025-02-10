using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_Campos_Imagem_Manutencao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Manutencao",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeImagem",
                table: "Manutencao",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "NomeImagem",
                table: "Manutencao");
        }
    }
}
