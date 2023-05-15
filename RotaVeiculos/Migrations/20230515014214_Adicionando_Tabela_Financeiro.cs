using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_Tabela_Financeiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeCargo",
                table: "Cargos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TiposFinanca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoFinanca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposFinanca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Financas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<double>(type: "float", maxLength: 15, nullable: false),
                    TipoFinancaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tipo_Financeiro",
                        column: x => x.TipoFinancaId,
                        principalTable: "TiposFinanca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Financas_TipoFinancaId",
                table: "Financas",
                column: "TipoFinancaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financas");

            migrationBuilder.DropTable(
                name: "TiposFinanca");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCargo",
                table: "Cargos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
