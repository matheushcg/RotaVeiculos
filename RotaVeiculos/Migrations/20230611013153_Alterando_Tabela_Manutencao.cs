using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class Alterando_Tabela_Manutencao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "NomeImagem",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Manutencao");

            migrationBuilder.AddColumn<int>(
                name: "VeiculoId",
                table: "Manutencao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_VeiculoId",
                table: "Manutencao",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo",
                table: "Manutencao",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_VeiculoId",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "Manutencao");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Manutencao",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Manutencao",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeImagem",
                table: "Manutencao",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Manutencao",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }
    }
}
