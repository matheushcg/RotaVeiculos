using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class Criando_Tabela_Manutencao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manutencao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    ManutencaoRealizada = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manutencao");
        }
    }
}
