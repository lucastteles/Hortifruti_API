using Microsoft.EntityFrameworkCore.Migrations;

namespace HortifrutiSF.Repo.Migrations
{
    public partial class AdicionandoPrecoCustoEmVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoCusto",
                table: "Venda",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoCusto",
                table: "Venda");
        }
    }
}
