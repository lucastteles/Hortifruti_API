using Microsoft.EntityFrameworkCore.Migrations;

namespace HortifrutiSF.Repo.Migrations
{
    public partial class AdicionandoPrecoCusto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoCusto",
                table: "ProdutoEntrada",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoCusto",
                table: "ProdutoEntrada");
        }
    }
}
