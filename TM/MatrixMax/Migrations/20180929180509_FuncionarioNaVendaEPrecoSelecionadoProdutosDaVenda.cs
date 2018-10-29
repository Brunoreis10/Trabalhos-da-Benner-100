using Microsoft.EntityFrameworkCore.Migrations;

namespace MatrixMax.Migrations
{
    public partial class FuncionarioNaVendaEPrecoSelecionadoProdutosDaVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPreco",
                table: "ProdutosDaVenda");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Vendas",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecoSelecionado",
                table: "ProdutosDaVenda",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Usuarios_UsuarioId",
                table: "Vendas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Usuarios_UsuarioId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "PrecoSelecionado",
                table: "ProdutosDaVenda");

            migrationBuilder.AddColumn<int>(
                name: "TipoPreco",
                table: "ProdutosDaVenda",
                nullable: false,
                defaultValue: 0);
        }
    }
}
