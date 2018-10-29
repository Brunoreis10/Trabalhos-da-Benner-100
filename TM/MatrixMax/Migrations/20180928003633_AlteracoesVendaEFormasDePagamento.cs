using Microsoft.EntityFrameworkCore.Migrations;

namespace MatrixMax.Migrations
{
    public partial class AlteracoesVendaEFormasDePagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoStatus",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "TipoStatusVenda",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "TipoPagamento",
                table: "Vendas",
                newName: "TipoVenda");

            migrationBuilder.RenameColumn(
                name: "DataEntrega",
                table: "Vendas",
                newName: "DataEntregaRecarga");

            migrationBuilder.AddColumn<int>(
                name: "BandeiraCartaoId",
                table: "FormasDePagamento",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCartao",
                table: "FormasDePagamento",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormasDePagamento_BandeiraCartaoId",
                table: "FormasDePagamento",
                column: "BandeiraCartaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormasDePagamento_FormasDePagamento_BandeiraCartaoId",
                table: "FormasDePagamento",
                column: "BandeiraCartaoId",
                principalTable: "FormasDePagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormasDePagamento_FormasDePagamento_BandeiraCartaoId",
                table: "FormasDePagamento");

            migrationBuilder.DropIndex(
                name: "IX_FormasDePagamento_BandeiraCartaoId",
                table: "FormasDePagamento");

            migrationBuilder.DropColumn(
                name: "BandeiraCartaoId",
                table: "FormasDePagamento");

            migrationBuilder.DropColumn(
                name: "IdCartao",
                table: "FormasDePagamento");

            migrationBuilder.RenameColumn(
                name: "TipoVenda",
                table: "Vendas",
                newName: "TipoPagamento");

            migrationBuilder.RenameColumn(
                name: "DataEntregaRecarga",
                table: "Vendas",
                newName: "DataEntrega");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoStatus",
                table: "Vendas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoStatusVenda",
                table: "Vendas",
                nullable: false,
                defaultValue: 0);
        }
    }
}
