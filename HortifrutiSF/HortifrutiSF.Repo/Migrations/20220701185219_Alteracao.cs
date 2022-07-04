using Microsoft.EntityFrameworkCore.Migrations;

namespace HortifrutiSF.Repo.Migrations
{
    public partial class Alteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_ProdutoEntrada_ProdutoEntradaId",
                table: "Venda");

            migrationBuilder.RenameColumn(
                name: "ProdutoEntradaId",
                table: "Venda",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_ProdutoEntradaId",
                table: "Venda",
                newName: "IX_Venda_ProdutoId");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoVenda",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Produto_ProdutoId",
                table: "Venda",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Produto_ProdutoId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "PrecoVenda",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Venda",
                newName: "ProdutoEntradaId");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_ProdutoId",
                table: "Venda",
                newName: "IX_Venda_ProdutoEntradaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_ProdutoEntrada_ProdutoEntradaId",
                table: "Venda",
                column: "ProdutoEntradaId",
                principalTable: "ProdutoEntrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
